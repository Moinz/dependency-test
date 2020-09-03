using UnityEngine;
using Torstein.VariableSystem.Core;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Types
{
	[CreateAssetMenu(menuName = "Fruitbus/Variables/Vector4/Instanced", order = -3)]
	public class Vector4VariableInstanced : InstancedVariable<Vector4>
	{
		protected override GameVariable<Vector4> GenerateVariableObject()
		{
			return CreateInstance<Vector4Variable>();
		}
	}
}