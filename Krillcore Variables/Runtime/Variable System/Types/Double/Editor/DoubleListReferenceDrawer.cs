#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using Torstein.VariableSystem.Types;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Editor
{
	[CustomPropertyDrawer(typeof(ReadDoubleListReference))]
	[CustomPropertyDrawer(typeof(WriteDoubleListReference))]
	[CustomPropertyDrawer(typeof(DoubleListReference))]
	public class DoubleListReferenceDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			VariablesUtilities.OnGUI<double>(position, property, label);
		}
	}
}
#endif