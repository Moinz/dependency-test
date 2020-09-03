using UnityEngine;
using BehaviorDesigner.Runtime;
using Torstein.VariableSystem;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Krillbite.CustomBehaviours.Variables
{
	[System.Serializable]
	public class SharedTexture2DListReference : SharedVariable<Texture2DListReference>
	{
		public override string ToString()
		{
			return mValue == null ? "null" : mValue.List.ToString();
		}

		public static implicit operator SharedTexture2DListReference(Texture2DListReference value)
		{
			return new SharedTexture2DListReference {mValue = value};
		}
	}
}