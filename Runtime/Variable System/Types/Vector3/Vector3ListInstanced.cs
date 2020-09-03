using UnityEngine;
using Torstein.VariableSystem.Core;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Types
{
    [CreateAssetMenu(menuName = "Fruitbus/Variables/Vector3/Instanced List", order = -1)]
    public class Vector3ListInstanced : InstancedList<Vector3>
    {
        protected override RuntimeSet<Vector3> GenerateListObject()
        {
            return CreateInstance<Vector3List>();
        }
    }
}