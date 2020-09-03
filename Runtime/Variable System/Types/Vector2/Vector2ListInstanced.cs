using UnityEngine;
using Torstein.VariableSystem.Core;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Types
{
    [CreateAssetMenu(menuName = "Fruitbus/Variables/Vector2/Instanced List", order = -1)]
    public class Vector2ListInstanced : InstancedList<Vector2>
    {
        protected override RuntimeSet<Vector2> GenerateListObject()
        {
            return CreateInstance<Vector2List>();
        }
    }
}