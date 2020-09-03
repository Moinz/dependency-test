using UnityEngine;
using Torstein.VariableSystem.Core;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Types
{
    [CreateAssetMenu(menuName = "Fruitbus/Variables/Bool/Instanced List", order = -1)]
    public class BoolListInstanced : InstancedList<bool>
    {
        protected override RuntimeSet<bool> GenerateListObject()
        {
            return CreateInstance<BoolList>();
        }
    }
}