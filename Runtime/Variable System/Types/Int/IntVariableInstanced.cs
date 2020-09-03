using UnityEngine;
using Torstein.VariableSystem.Core;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Types
{
	[CreateAssetMenu(menuName = "Fruitbus/Variables/Int/Instanced", order = -3)]
	public class IntVariableInstanced : InstancedVariable<int>
	{
		protected override GameVariable<int> GenerateVariableObject()
		{
			return CreateInstance<IntVariable>();
		}
	}
}