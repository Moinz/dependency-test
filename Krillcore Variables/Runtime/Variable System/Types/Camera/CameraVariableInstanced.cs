using UnityEngine;
using Torstein.VariableSystem.Core;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Types
{
	[CreateAssetMenu(menuName = "Fruitbus/Variables/Camera/Instanced", order = -3)]
	public class CameraVariableInstanced : InstancedVariable<Camera>
	{
		protected override GameVariable<Camera> GenerateVariableObject()
		{
			return CreateInstance<CameraVariable>();
		}
	}
}