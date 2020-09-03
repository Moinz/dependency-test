using UnityEngine;
using Torstein.VariableSystem.Core;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Types
{
	[CreateAssetMenu(menuName = "Fruitbus/Variables/Transform/Instanced", order = -3)]
	public class TransformVariableInstanced : InstancedVariable<Transform>
	{
		protected override GameVariable<Transform> GenerateVariableObject()
		{
			return CreateInstance<TransformVariable>();
		}
	}
}