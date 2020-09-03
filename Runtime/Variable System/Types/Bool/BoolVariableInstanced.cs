using UnityEngine;
using Torstein.VariableSystem.Core;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Types
{
	[CreateAssetMenu(menuName = "Fruitbus/Variables/Bool/Instanced", order = -3)]
	public class BoolVariableInstanced : InstancedVariable<bool>
	{
		protected override GameVariable<bool> GenerateVariableObject()
		{
			return CreateInstance<BoolVariable>();
		}
	}
}