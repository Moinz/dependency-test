using UnityEngine;
using Torstein.VariableSystem.Core;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Types
{
	[CreateAssetMenu(menuName = "Fruitbus/Variables/String/Instanced", order = -3)]
	public class StringVariableInstanced : InstancedVariable<string>
	{
		protected override GameVariable<string> GenerateVariableObject()
		{
			return CreateInstance<StringVariable>();
		}
	}
}