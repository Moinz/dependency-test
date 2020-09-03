#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using Torstein.VariableSystem.Types;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Editor
{
	[CustomPropertyDrawer(typeof(ReadQuaternionListReference))]
	[CustomPropertyDrawer(typeof(WriteQuaternionListReference))]
	[CustomPropertyDrawer(typeof(QuaternionListReference))]
	public class QuaternionListReferenceDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			VariablesUtilities.OnGUI<Quaternion>(position, property, label);
		}
	}
}
#endif