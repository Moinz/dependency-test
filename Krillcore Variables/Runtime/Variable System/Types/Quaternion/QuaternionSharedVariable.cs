using UnityEngine;
using BehaviorDesigner.Runtime;
using Torstein.VariableSystem;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Krillbite.CustomBehaviours.Variables
{
	[System.Serializable]
	public class SharedQuaternionReference : SharedVariable<QuaternionReference>
	{
		public override string ToString()
		{
			return mValue == null ? "null" : mValue.Value.ToString();
		}

		public static implicit operator SharedQuaternionReference(QuaternionReference value)
		{
			return new SharedQuaternionReference {mValue = value};
		}
	}
}