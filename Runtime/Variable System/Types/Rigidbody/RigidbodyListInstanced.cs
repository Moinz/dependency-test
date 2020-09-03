using UnityEngine;
using Torstein.VariableSystem.Core;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Types
{
    [CreateAssetMenu(menuName = "Fruitbus/Variables/Rigidbody/Instanced List", order = -1)]
    public class RigidbodyListInstanced : InstancedList<Rigidbody>
    {
        protected override RuntimeSet<Rigidbody> GenerateListObject()
        {
            return CreateInstance<RigidbodyList>();
        }
    }
}