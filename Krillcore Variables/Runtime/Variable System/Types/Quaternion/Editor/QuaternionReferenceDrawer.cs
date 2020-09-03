#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using Torstein.VariableSystem.Types;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Editor
{
	[CustomPropertyDrawer(typeof(ReadQuaternionReference))]
	[CustomPropertyDrawer(typeof(WriteQuaternionReference))]
	[CustomPropertyDrawer(typeof(QuaternionReference))]
	public class QuaternionReferenceDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			VariablesUtilities.OnGUI<Quaternion>(position, property, label);
		}
	}
}
#endif