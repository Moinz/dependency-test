using UnityEngine;
using Torstein.VariableSystem.Core;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Types
{
    [CreateAssetMenu(menuName = "Fruitbus/Variables/Int/Instanced List", order = -1)]
    public class IntListInstanced : InstancedList<int>
    {
        protected override RuntimeSet<int> GenerateListObject()
        {
            return CreateInstance<IntList>();
        }
    }
}