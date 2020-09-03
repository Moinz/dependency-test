using UnityEngine;
using Torstein.VariableSystem.Core;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Types
{
    [CreateAssetMenu(menuName = "Fruitbus/Variables/Texture2D/Instanced List", order = -1)]
    public class Texture2DListInstanced : InstancedList<Texture2D>
    {
        protected override RuntimeSet<Texture2D> GenerateListObject()
        {
            return CreateInstance<Texture2DList>();
        }
    }
}