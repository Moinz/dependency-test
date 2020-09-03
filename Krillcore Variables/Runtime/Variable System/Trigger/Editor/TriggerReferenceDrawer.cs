#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Editor
{
	[CustomPropertyDrawer(typeof(WriteTriggerReference))]
	[CustomPropertyDrawer(typeof(ReadTriggerReference))]
	[CustomPropertyDrawer(typeof(TriggerReference))]
	public class TriggerReferenceDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			VariablesUtilities.OnGUI<Trigger>(position, property, label);
		}
	}
}
#endif