#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using Torstein.VariableSystem.Types;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Editor
{
	[CustomPropertyDrawer(typeof(ReadIntListReference))]
	[CustomPropertyDrawer(typeof(WriteIntListReference))]
	[CustomPropertyDrawer(typeof(IntListReference))]
	public class IntListReferenceDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			VariablesUtilities.OnGUI<int>(position, property, label);
		}
	}
}
#endif