#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using Torstein.VariableSystem.Types;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Editor
{
	[CustomPropertyDrawer(typeof(ReadTexture2DListReference))]
	[CustomPropertyDrawer(typeof(WriteTexture2DListReference))]
	[CustomPropertyDrawer(typeof(Texture2DListReference))]
	public class Texture2DListReferenceDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			VariablesUtilities.OnGUI<Texture2D>(position, property, label);
		}
	}
}
#endif