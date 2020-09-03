using UnityEngine;
using Torstein.VariableSystem.Core;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Types
{
    [CreateAssetMenu(menuName = "Fruitbus/Variables/Collider/Instanced List", order = -1)]
    public class ColliderListInstanced : InstancedList<Collider>
    {
        protected override RuntimeSet<Collider> GenerateListObject()
        {
            return CreateInstance<ColliderList>();
        }
    }
}