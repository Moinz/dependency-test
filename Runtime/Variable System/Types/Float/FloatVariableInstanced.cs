using UnityEngine;
using Torstein.VariableSystem.Core;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Types
{
	[CreateAssetMenu(menuName = "Fruitbus/Variables/Float/Instanced", order = -3)]
	public class FloatVariableInstanced : InstancedVariable<float>
	{
		protected override GameVariable<float> GenerateVariableObject()
		{
			return CreateInstance<FloatVariable>();
		}
	}
}