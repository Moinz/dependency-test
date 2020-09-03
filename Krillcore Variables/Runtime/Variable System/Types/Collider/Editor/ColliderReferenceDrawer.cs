#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using Torstein.VariableSystem.Types;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Editor
{
	[CustomPropertyDrawer(typeof(ReadColliderReference))]
	[CustomPropertyDrawer(typeof(WriteColliderReference))]
	[CustomPropertyDrawer(typeof(ColliderReference))]
	public class ColliderReferenceDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			VariablesUtilities.OnGUI<Collider>(position, property, label);
		}
	}
}
#endif