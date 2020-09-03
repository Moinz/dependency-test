using UnityEngine;
using Torstein.VariableSystem.Core;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Types
{
	[CreateAssetMenu(menuName = "Fruitbus/Variables/Rigidbody/Instanced", order = -3)]
	public class RigidbodyVariableInstanced : InstancedVariable<Rigidbody>
	{
		protected override GameVariable<Rigidbody> GenerateVariableObject()
		{
			return CreateInstance<RigidbodyVariable>();
		}
	}
}