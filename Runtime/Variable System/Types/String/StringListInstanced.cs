using UnityEngine;
using Torstein.VariableSystem.Core;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Types
{
    [CreateAssetMenu(menuName = "Fruitbus/Variables/String/Instanced List", order = -1)]
    public class StringListInstanced : InstancedList<string>
    {
        protected override RuntimeSet<string> GenerateListObject()
        {
            return CreateInstance<StringList>();
        }
    }
}