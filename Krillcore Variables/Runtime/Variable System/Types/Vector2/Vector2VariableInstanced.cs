using UnityEngine;
using Torstein.VariableSystem.Core;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Types
{
	[CreateAssetMenu(menuName = "Fruitbus/Variables/Vector2/Instanced", order = -3)]
	public class Vector2VariableInstanced : InstancedVariable<Vector2>
	{
		protected override GameVariable<Vector2> GenerateVariableObject()
		{
			return CreateInstance<Vector2Variable>();
		}
	}
}