#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using Torstein.VariableSystem.Types;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Editor
{
	[CustomPropertyDrawer(typeof(ReadCameraListReference))]
	[CustomPropertyDrawer(typeof(WriteCameraListReference))]
	[CustomPropertyDrawer(typeof(CameraListReference))]
	public class CameraListReferenceDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			VariablesUtilities.OnGUI<Camera>(position, property, label);
		}
	}
}
#endif