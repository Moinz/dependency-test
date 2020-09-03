#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using Torstein.VariableSystem.Types;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Editor
{
	[CustomPropertyDrawer(typeof(ReadVector4ListReference))]
	[CustomPropertyDrawer(typeof(WriteVector4ListReference))]
	[CustomPropertyDrawer(typeof(Vector4ListReference))]
	public class Vector4ListReferenceDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			VariablesUtilities.OnGUI<Vector4>(position, property, label);
		}
	}
}
#endif