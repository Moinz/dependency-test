using UnityEngine;
using Torstein.VariableSystem.Core;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Types
{
	[CreateAssetMenu(menuName = "Fruitbus/Variables/Double/Instanced", order = -3)]
	public class DoubleVariableInstanced : InstancedVariable<double>
	{
		protected override GameVariable<double> GenerateVariableObject()
		{
			return CreateInstance<DoubleVariable>();
		}
	}
}