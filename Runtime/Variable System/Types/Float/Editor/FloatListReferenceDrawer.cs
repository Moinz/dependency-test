#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using Torstein.VariableSystem.Types;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Editor
{
	[CustomPropertyDrawer(typeof(ReadFloatListReference))]
	[CustomPropertyDrawer(typeof(WriteFloatListReference))]
	[CustomPropertyDrawer(typeof(FloatListReference))]
	public class FloatListReferenceDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			VariablesUtilities.OnGUI<float>(position, property, label);
		}
	}
}
#endif