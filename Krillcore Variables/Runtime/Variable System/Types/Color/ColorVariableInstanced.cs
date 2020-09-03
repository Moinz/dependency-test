using UnityEngine;
using Torstein.VariableSystem.Core;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Types
{
	[CreateAssetMenu(menuName = "Fruitbus/Variables/Color/Instanced", order = -3)]
	public class ColorVariableInstanced : InstancedVariable<Color>
	{
		protected override GameVariable<Color> GenerateVariableObject()
		{
			return CreateInstance<ColorVariable>();
		}
	}
}