#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using Torstein.VariableSystem.Types;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Editor
{
	[CustomPropertyDrawer(typeof(ReadTexture2DReference))]
	[CustomPropertyDrawer(typeof(WriteTexture2DReference))]
	[CustomPropertyDrawer(typeof(Texture2DReference))]
	public class Texture2DReferenceDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			VariablesUtilities.OnGUI<Texture2D>(position, property, label);
		}
	}
}
#endif