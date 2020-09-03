#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using Torstein.VariableSystem.Types;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Editor
{
	[CustomPropertyDrawer(typeof(ReadColorReference))]
	[CustomPropertyDrawer(typeof(WriteColorReference))]
	[CustomPropertyDrawer(typeof(ColorReference))]
	public class ColorReferenceDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			VariablesUtilities.OnGUI<Color>(position, property, label);
		}
	}
}
#endif