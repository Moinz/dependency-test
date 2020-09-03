using UnityEngine;
using Torstein.VariableSystem.Core;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Types
{
	[CreateAssetMenu(menuName = "Fruitbus/Variables/GameObject/Instanced", order = -3)]
	public class GameObjectVariableInstanced : InstancedVariable<GameObject>
	{
		protected override GameVariable<GameObject> GenerateVariableObject()
		{
			return CreateInstance<GameObjectVariable>();
		}
	}
}