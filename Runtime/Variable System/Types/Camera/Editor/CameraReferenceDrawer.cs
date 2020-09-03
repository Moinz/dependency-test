#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using Torstein.VariableSystem.Types;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Editor
{
	[CustomPropertyDrawer(typeof(ReadCameraReference))]
	[CustomPropertyDrawer(typeof(WriteCameraReference))]
	[CustomPropertyDrawer(typeof(CameraReference))]
	public class CameraReferenceDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			VariablesUtilities.OnGUI<Camera>(position, property, label);
		}
	}
}
#endif