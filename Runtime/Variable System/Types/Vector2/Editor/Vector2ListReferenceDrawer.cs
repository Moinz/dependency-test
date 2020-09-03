#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using Torstein.VariableSystem.Types;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Editor
{
	[CustomPropertyDrawer(typeof(ReadVector2ListReference))]
	[CustomPropertyDrawer(typeof(WriteVector2ListReference))]
	[CustomPropertyDrawer(typeof(Vector2ListReference))]
	public class Vector2ListReferenceDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			VariablesUtilities.OnGUI<Vector2>(position, property, label);
		}
	}
}
#endif