using UnityEngine;
using Torstein.VariableSystem.Core;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Types
{
	[CreateAssetMenu(menuName = "Fruitbus/Variables/Quaternion/Instanced", order = -3)]
	public class QuaternionVariableInstanced : InstancedVariable<Quaternion>
	{
		protected override GameVariable<Quaternion> GenerateVariableObject()
		{
			return CreateInstance<QuaternionVariable>();
		}
	}
}