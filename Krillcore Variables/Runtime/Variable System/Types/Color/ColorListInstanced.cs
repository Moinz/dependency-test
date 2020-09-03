using UnityEngine;
using Torstein.VariableSystem.Core;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Types
{
    [CreateAssetMenu(menuName = "Fruitbus/Variables/Color/Instanced List", order = -1)]
    public class ColorListInstanced : InstancedList<Color>
    {
        protected override RuntimeSet<Color> GenerateListObject()
        {
            return CreateInstance<ColorList>();
        }
    }
}