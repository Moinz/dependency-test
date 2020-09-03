#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using Torstein.VariableSystem.Types;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Editor
{
	[CustomPropertyDrawer(typeof(ReadBoolListReference))]
	[CustomPropertyDrawer(typeof(WriteBoolListReference))]
	[CustomPropertyDrawer(typeof(BoolListReference))]
	public class BoolListReferenceDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			VariablesUtilities.OnGUI<bool>(position, property, label);
		}
	}
}
#endif