using UnityEngine;
using Torstein.VariableSystem.Core;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Types
{
    [CreateAssetMenu(menuName = "Fruitbus/Variables/Transform/Instanced List", order = -1)]
    public class TransformListInstanced : InstancedList<Transform>
    {
        protected override RuntimeSet<Transform> GenerateListObject()
        {
            return CreateInstance<TransformList>();
        }
    }
}