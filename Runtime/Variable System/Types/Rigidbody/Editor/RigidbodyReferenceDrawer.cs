#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using Torstein.VariableSystem.Types;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Editor
{
	[CustomPropertyDrawer(typeof(ReadRigidbodyReference))]
	[CustomPropertyDrawer(typeof(WriteRigidbodyReference))]
	[CustomPropertyDrawer(typeof(RigidbodyReference))]
	public class RigidbodyReferenceDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			VariablesUtilities.OnGUI<Rigidbody>(position, property, label);
		}
	}
}
#endif