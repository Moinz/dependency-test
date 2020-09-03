using UnityEngine;
using Torstein.VariableSystem.Core;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Types
{
	[CreateAssetMenu(menuName = "Fruitbus/Variables/Vector3/Instanced", order = -3)]
	public class Vector3VariableInstanced : InstancedVariable<Vector3>
	{
		protected override GameVariable<Vector3> GenerateVariableObject()
		{
			return CreateInstance<Vector3Variable>();
		}
	}
}