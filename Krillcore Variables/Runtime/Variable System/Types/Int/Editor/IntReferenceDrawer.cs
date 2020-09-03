#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using Torstein.VariableSystem.Types;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Editor
{
	[CustomPropertyDrawer(typeof(ReadIntReference))]
	[CustomPropertyDrawer(typeof(WriteIntReference))]
	[CustomPropertyDrawer(typeof(IntReference))]
	public class IntReferenceDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			VariablesUtilities.OnGUI<int>(position, property, label);
		}
	}
}
#endif