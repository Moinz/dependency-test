using Object = UnityEngine.Object;
using System;
using Torstein.VariableSystem.Core;
using UnityEngine;
#if UNITY_EDITOR		
using UnityEditor;
using UnityEditorInternal;
#endif

namespace Torstein.VariableSystem
{
	public class VariablesUtilities
	{
		public static GameObject Instantiate(IDToken idToken, GameObject original, Transform parent, bool instantiateInWorldSpace)
		{
			// Disable GameObject to prevent Awake and OnEnable from firing before idToken has been assigned
			var activeState = original.activeSelf;
			original.SetActive(false);

			var newObject = Object.Instantiate(original, parent, instantiateInWorldSpace);

			var idTokenHolder = newObject.GetComponentInChildren<IDTokenHolder>();
			if (idTokenHolder != null)
				idTokenHolder.IDToken = idToken;

			// Reenable GameObject
			newObject.SetActive(activeState);
			original.SetActive(activeState);

			return newObject;
		}

		// TODO: Make a version of Instantiate that accepts multiple tokens and assigns them all in order, using GetComponentsInChildren

#if UNITY_EDITOR		
		#region VariableReferenceDrawer

		/// <summary>
		/// Options to display in the popup to select constant or variable.
		/// </summary>
		private static readonly string[] popupOptions =
			{ "Constant", "Global", "Instanced" };
		
		/// <summary>
		/// Actions to display in the popup
		/// </summary>
		private static readonly string[] popupActions =
			{ "Get ID token holder from parent", "Get ID token holder from children"};

		/// <summary> Cached style to use to draw the popup button. </summary>
		private static GUIStyle referenceTypePopupStyle;
		
		/// <summary> Cached style to use to draw the inspect button. </summary>
		private static GUIStyle inspectPopupStyle;

		
		// Taken from RoboRyanTron.Unite2017.Variables
		public static void OnGUI<T>(Rect position, SerializedProperty property, GUIContent label)
		{
			var prevColor = GUI.color;

			if (referenceTypePopupStyle == null)
			{
				referenceTypePopupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"));
				referenceTypePopupStyle.imagePosition = ImagePosition.ImageOnly;
			}

			if (inspectPopupStyle == null)
			{
				inspectPopupStyle = new GUIStyle(EditorStyles.label);
				inspectPopupStyle.alignment = TextAnchor.MiddleCenter;
				
				var tex = EditorGUIUtility.Load($"Icons/PropertyDrawer{(InternalEditorUtility.HasPro() ? "_Pro" : "")}.png") as Texture2D;

				inspectPopupStyle.onNormal.background = tex;
				inspectPopupStyle.onActive.background = tex;
				inspectPopupStyle.onFocused.background = tex;
				inspectPopupStyle.onHover.background = tex;
				inspectPopupStyle.normal.background = tex;
				inspectPopupStyle.active.background = tex;
				inspectPopupStyle.focused.background = tex;
				inspectPopupStyle.hover.background = tex;
				
				inspectPopupStyle.imagePosition = ImagePosition.ImageOnly;			
			}

			label = EditorGUI.BeginProperty(position, label, property);
			
			position = EditorGUI.PrefixLabel(position, label);

			EditorGUI.BeginChangeCheck();

			// Get properties
			//SerializedProperty useConstant = property.FindPropertyRelative("_useConstant");
			SerializedProperty assignmentType = property.FindPropertyRelative("_assignmentType");
			SerializedProperty constantValue = property.FindPropertyRelative("_constantValue");
			SerializedProperty globalVariable = property.FindPropertyRelative("_globalVariable");
			
			SerializedProperty instancedVariable = property.FindPropertyRelative("_instancedVariable");
			SerializedProperty idTokenHolder = property.FindPropertyRelative("_idTokenHolder");

			// Calculate rect for configuration button
			Rect buttonRect = new Rect(position);
			buttonRect.yMin += referenceTypePopupStyle.margin.top;
			buttonRect.width = referenceTypePopupStyle.fixedWidth + referenceTypePopupStyle.margin.right;
			position.xMin = buttonRect.xMax;
			
			position.width -= buttonRect.width;//Removed the width of the last pop up actions button

			
			// Store old indent level and set it to 0, the PrefixLabel takes care of it
			int indent = EditorGUI.indentLevel;
			EditorGUI.indentLevel = 0;
			
			
			// Inspect button
			
			int assType = assignmentType.enumValueIndex;
			
			if (assType != 0 && (assType == 1 && globalVariable.objectReferenceValue || assType == 2 && instancedVariable.objectReferenceValue ) )
			{
				var ow = buttonRect.width;

				buttonRect.y -= EditorGUIUtility.standardVerticalSpacing;
				buttonRect.width = 16;
				buttonRect.x -= buttonRect.width;
				
				if (GUI.Button(buttonRect, "●", inspectPopupStyle))
				{
					PopupWindow.Show(buttonRect,
						new VariablePopupInspector<T>(
							position,
							assignmentType,
							constantValue,
							globalVariable,
							instancedVariable,
							idTokenHolder
						));
				}
				buttonRect.y += EditorGUIUtility.standardVerticalSpacing;

				buttonRect.x += buttonRect.width;
				buttonRect.width = ow;
			}

			
			// Settings popup

			int result = EditorGUI.Popup(buttonRect, assignmentType.enumValueIndex, popupOptions, referenceTypePopupStyle);
			assignmentType.enumValueIndex = result;
			
			switch (assignmentType.enumValueIndex)
			{
				case 0:
					EditorGUI.PropertyField(position, constantValue, GUIContent.none);
					break;
				case 1:
					EditorGUI.PropertyField(position, globalVariable, GUIContent.none);
					break;
				case 2:
					var leftPosition = position;
					leftPosition.width *= 0.5f;
					var rightPosition = leftPosition;
					rightPosition.x += rightPosition.width;
					EditorGUI.PropertyField(leftPosition, instancedVariable, GUIContent.none);
					
					if (ReferenceEquals(idTokenHolder.objectReferenceValue, null))
					{
						GUI.color = Color.red;
					}
					
					EditorGUI.PropertyField(rightPosition, idTokenHolder, GUIContent.none);

					break;
			}

			//Pop up for actions like getting id handler from parent, or create new variable
			buttonRect.x = position.x + position.width;
			int action = EditorGUI.Popup(buttonRect, -1, popupActions, referenceTypePopupStyle);
			var behaviour = property.serializedObject.targetObject as MonoBehaviour;
			switch (action)
			{
				case 0: 
					if (behaviour != null)
					{
						var tokenHolder = behaviour.GetComponentInParent<IDTokenHolder>();
						idTokenHolder.objectReferenceValue = tokenHolder;
					}
					break;
				case 1: 
					if (behaviour != null)
					{
						var tokenHolder = behaviour.GetComponentInChildren<IDTokenHolder>();
						idTokenHolder.objectReferenceValue = tokenHolder;
					}
					break;
			}
			
			if (EditorGUI.EndChangeCheck())
				property.serializedObject.ApplyModifiedProperties();

			EditorGUI.indentLevel = indent;
			EditorGUI.EndProperty();

			GUI.color = prevColor;
		}

		#endregion
		
		#region VariablePopupInspector
		/// <summary>
		/// Popup window that can show the inspector of game variables, even instanced
		/// ones, from the regular inspector where a variable reference field is drawn.
		/// This is nice to use, because otherwise we would have to select the instanced
		/// variable in the project, and then dig our way into the dictionary to find the value we care about.
		/// </summary>
		/// <typeparam name="T">The type of the variable we're looking for. Required for casting.</typeparam>
		private class VariablePopupInspector<T> : PopupWindowContent
		{
			
			// There's some commented-out code in here, relating to scriptable object/property, that I couldn't get to work,
			// but it would allow for a more elegant popup window. The issue I had was that when applying modified properties
			// the _runtimeValue is overwritten by _serializedValue...
			// So for now we just straight up create a new inspector for the GameVariable<T> that we find.
			
			public VariablePopupInspector(Rect rect,
				SerializedProperty _assignmentType,
				SerializedProperty _constantValue,
				SerializedProperty _globalVariable,
				SerializedProperty _instancedVariable,
				SerializedProperty _idTokenHolder)
			{
				this.rect = rect;
				this.assignmentType = _assignmentType;
				this.constantValue = _constantValue;
				this.globalVariable = _globalVariable;
				this.instancedVariable = _instancedVariable;
				this.idTokenHolder = _idTokenHolder;
			}

			Rect rect;
			
			SerializedProperty assignmentType;
			SerializedProperty constantValue;
			SerializedProperty globalVariable;
			SerializedProperty instancedVariable;
			SerializedProperty idTokenHolder;

			private static UnityEditor.Editor _editor;
			private GameVariable<T> _gameVariable;
			private RuntimeSet<T> _runtimeSet;
			
/*
			private static SerializedObject _serializedVariableObject;
			private SerializedProperty _runtimeValue;
			private SerializedProperty _serializedValue;
*/

			private bool _noReference = false;
			
			public override Vector2 GetWindowSize()
			{
				// A bit of a random number. We just want to have enough lines to show the inspector.
				// Might want to make this dynamic in the future, since I doubt lists will draw nicely now...
				int count = 8;

				float width = Math.Max(350, rect.width);
				float height = EditorGUIUtility.singleLineHeight * count + EditorGUIUtility.standardVerticalSpacing * count + 1;
				
				return new Vector2(width, height);
			}

			public override void OnOpen()
			{
				if (assignmentType.enumValueIndex == 0) // Constant value, we have all we need, just create the editor
				{
					_editor = UnityEditor.Editor.CreateEditor(constantValue.objectReferenceValue);
				}
				else if (assignmentType.enumValueIndex == 1) // Global. Pretty easy, just get the global variable object and cast it to GameVariable<T>
				{
					_gameVariable = globalVariable.objectReferenceValue as GameVariable<T>;
					
					if (_gameVariable != null)
					{
						_editor = UnityEditor.Editor.CreateEditor(_gameVariable);
					}
					else
					{
						_runtimeSet = globalVariable.objectReferenceValue as RuntimeSet<T>;

						if (_runtimeSet != null)
							_editor = UnityEditor.Editor.CreateEditor(_runtimeSet);
						else
							_noReference = true;
					}
				}
				else if (assignmentType.enumValueIndex == 2) // instanced
				{
					var variable = instancedVariable.objectReferenceValue as InstancedVariable<T>;

					if (variable != null)
					{
						var token = (idTokenHolder.objectReferenceValue as IDTokenHolder)?.IDToken;
						_gameVariable = variable.GetVariable(token);
						_editor = UnityEditor.Editor.CreateEditor(_gameVariable);
					}
					else 
					{
						var list = instancedVariable.objectReferenceValue as InstancedList<T>;

						if (list != null)
						{					
							var token = (idTokenHolder.objectReferenceValue as IDTokenHolder)?.IDToken;
							_runtimeSet = list.GetList(token);
							_editor = UnityEditor.Editor.CreateEditor(_runtimeSet);
						}
						else
						{
							_noReference = true;
						}
					}
				}
				
				base.OnOpen();
			}

			public override void OnClose()
			{
				Object.DestroyImmediate(_editor);
				base.OnClose();
			}

			public override void OnGUI(Rect rect)
			{
				rect.height = EditorGUIUtility.singleLineHeight;
				rect.y += rect.height* 2;
				EditorGUI.BeginChangeCheck();

				switch (assignmentType.enumValueIndex) 
				{
					case 0: // constant (we're not actually showing this right now)
						_editor.OnInspectorGUI();
						break;
					case 1: // global
						EditorGUIUtility.labelWidth = 100;
						_editor.OnInspectorGUI();

						EditorGUIUtility.labelWidth = 0;
						break;
					case 2: // instanced
						if (_noReference)
						{
							GUILayout.Label("Not Intitialized / Lists not supported yet");
						}
						else
						{
							EditorGUIUtility.labelWidth = 100;
							_editor.OnInspectorGUI();
							EditorGUIUtility.labelWidth = 0;
						}
						break;
				}
			}
		}
		
		#endregion
#endif
	}
}
