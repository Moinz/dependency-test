#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using Torstein.VariableSystem.Types;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Editor
{
	[CustomPropertyDrawer(typeof(ReadGameObjectReference))]
	[CustomPropertyDrawer(typeof(WriteGameObjectReference))]
	[CustomPropertyDrawer(typeof(GameObjectReference))]
	public class GameObjectReferenceDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			VariablesUtilities.OnGUI<GameObject>(position, property, label);
		}
	}
}
#endif