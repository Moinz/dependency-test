#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using Torstein.VariableSystem.Types;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Editor
{
	[CustomPropertyDrawer(typeof(ReadColorListReference))]
	[CustomPropertyDrawer(typeof(WriteColorListReference))]
	[CustomPropertyDrawer(typeof(ColorListReference))]
	public class ColorListReferenceDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			VariablesUtilities.OnGUI<Color>(position, property, label);
		}
	}
}
#endif