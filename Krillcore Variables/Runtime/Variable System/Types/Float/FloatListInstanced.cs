using UnityEngine;
using Torstein.VariableSystem.Core;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Types
{
    [CreateAssetMenu(menuName = "Fruitbus/Variables/Float/Instanced List", order = -1)]
    public class FloatListInstanced : InstancedList<float>
    {
        protected override RuntimeSet<float> GenerateListObject()
        {
            return CreateInstance<FloatList>();
        }
    }
}