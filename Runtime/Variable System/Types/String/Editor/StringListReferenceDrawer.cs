#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using Torstein.VariableSystem.Types;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Editor
{
	[CustomPropertyDrawer(typeof(ReadStringListReference))]
	[CustomPropertyDrawer(typeof(WriteStringListReference))]
	[CustomPropertyDrawer(typeof(StringListReference))]
	public class StringListReferenceDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			VariablesUtilities.OnGUI<string>(position, property, label);
		}
	}
}
#endif