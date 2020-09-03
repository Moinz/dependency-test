#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using Torstein.VariableSystem.Types;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Editor
{
	[CustomPropertyDrawer(typeof(ReadBoolReference))]
	[CustomPropertyDrawer(typeof(WriteBoolReference))]
	[CustomPropertyDrawer(typeof(BoolReference))]
	public class BoolReferenceDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			VariablesUtilities.OnGUI<bool>(position, property, label);
		}
	}
}
#endif