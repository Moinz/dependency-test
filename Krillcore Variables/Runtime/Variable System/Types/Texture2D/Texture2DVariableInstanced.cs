using UnityEngine;
using Torstein.VariableSystem.Core;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Types
{
	[CreateAssetMenu(menuName = "Fruitbus/Variables/Texture2D/Instanced", order = -3)]
	public class Texture2DVariableInstanced : InstancedVariable<Texture2D>
	{
		protected override GameVariable<Texture2D> GenerateVariableObject()
		{
			return CreateInstance<Texture2DVariable>();
		}
	}
}