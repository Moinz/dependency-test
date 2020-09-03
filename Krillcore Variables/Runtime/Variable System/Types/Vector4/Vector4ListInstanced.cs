using UnityEngine;
using Torstein.VariableSystem.Core;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Types
{
    [CreateAssetMenu(menuName = "Fruitbus/Variables/Vector4/Instanced List", order = -1)]
    public class Vector4ListInstanced : InstancedList<Vector4>
    {
        protected override RuntimeSet<Vector4> GenerateListObject()
        {
            return CreateInstance<Vector4List>();
        }
    }
}