#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using Torstein.VariableSystem.Types;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Editor
{
	[CustomPropertyDrawer(typeof(ReadTransformReference))]
	[CustomPropertyDrawer(typeof(WriteTransformReference))]
	[CustomPropertyDrawer(typeof(TransformReference))]
	public class TransformReferenceDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			VariablesUtilities.OnGUI<Transform>(position, property, label);
		}
	}
}
#endif