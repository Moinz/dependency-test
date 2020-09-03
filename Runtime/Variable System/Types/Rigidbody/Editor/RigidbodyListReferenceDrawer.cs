#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using Torstein.VariableSystem.Types;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Editor
{
	[CustomPropertyDrawer(typeof(ReadRigidbodyListReference))]
	[CustomPropertyDrawer(typeof(WriteRigidbodyListReference))]
	[CustomPropertyDrawer(typeof(RigidbodyListReference))]
	public class RigidbodyListReferenceDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			VariablesUtilities.OnGUI<Rigidbody>(position, property, label);
		}
	}
}
#endif