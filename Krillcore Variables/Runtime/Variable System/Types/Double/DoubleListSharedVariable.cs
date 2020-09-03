using UnityEngine;
using BehaviorDesigner.Runtime;
using Torstein.VariableSystem;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Krillbite.CustomBehaviours.Variables
{
	[System.Serializable]
	public class SharedDoubleListReference : SharedVariable<DoubleListReference>
	{
		public override string ToString()
		{
			return mValue == null ? "null" : mValue.List.ToString();
		}

		public static implicit operator SharedDoubleListReference(DoubleListReference value)
		{
			return new SharedDoubleListReference {mValue = value};
		}
	}
}