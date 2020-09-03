using UnityEngine;
using BehaviorDesigner.Runtime;
using Torstein.VariableSystem;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Krillbite.CustomBehaviours.Variables
{
	[System.Serializable]
	public class SharedFloatListReference : SharedVariable<FloatListReference>
	{
		public override string ToString()
		{
			return mValue == null ? "null" : mValue.List.ToString();
		}

		public static implicit operator SharedFloatListReference(FloatListReference value)
		{
			return new SharedFloatListReference {mValue = value};
		}
	}
}