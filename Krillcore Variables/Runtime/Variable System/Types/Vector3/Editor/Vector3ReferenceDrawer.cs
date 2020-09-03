#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using Torstein.VariableSystem.Types;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Editor
{
	[CustomPropertyDrawer(typeof(ReadVector3Reference))]
	[CustomPropertyDrawer(typeof(WriteVector3Reference))]
	[CustomPropertyDrawer(typeof(Vector3Reference))]
	public class Vector3ReferenceDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			VariablesUtilities.OnGUI<Vector3>(position, property, label);
		}
	}
}
#endif