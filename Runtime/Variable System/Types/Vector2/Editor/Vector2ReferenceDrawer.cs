#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using Torstein.VariableSystem.Types;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Editor
{
	[CustomPropertyDrawer(typeof(ReadVector2Reference))]
	[CustomPropertyDrawer(typeof(WriteVector2Reference))]
	[CustomPropertyDrawer(typeof(Vector2Reference))]
	public class Vector2ReferenceDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			VariablesUtilities.OnGUI<Vector2>(position, property, label);
		}
	}
}
#endif