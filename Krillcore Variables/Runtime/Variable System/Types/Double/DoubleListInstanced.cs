using UnityEngine;
using Torstein.VariableSystem.Core;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Types
{
    [CreateAssetMenu(menuName = "Fruitbus/Variables/Double/Instanced List", order = -1)]
    public class DoubleListInstanced : InstancedList<double>
    {
        protected override RuntimeSet<double> GenerateListObject()
        {
            return CreateInstance<DoubleList>();
        }
    }
}