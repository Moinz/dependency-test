using UnityEngine;
using BehaviorDesigner.Runtime;
using Torstein.VariableSystem;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Krillbite.CustomBehaviours.Variables
{
	[System.Serializable]
	public class SharedGameObjectReference : SharedVariable<GameObjectReference>
	{
		public override string ToString()
		{
			return mValue == null ? "null" : mValue.Value.ToString();
		}

		public static implicit operator SharedGameObjectReference(GameObjectReference value)
		{
			return new SharedGameObjectReference {mValue = value};
		}
	}
}