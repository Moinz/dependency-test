using UnityEngine;
using Torstein.VariableSystem.Core;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Types
{
	[CreateAssetMenu(menuName = "Fruitbus/Variables/Collider/Instanced", order = -3)]
	public class ColliderVariableInstanced : InstancedVariable<Collider>
	{
		protected override GameVariable<Collider> GenerateVariableObject()
		{
			return CreateInstance<ColliderVariable>();
		}
	}
}