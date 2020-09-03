using UnityEngine;
using Torstein.VariableSystem.Core;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Types
{
    [CreateAssetMenu(menuName = "Fruitbus/Variables/Quaternion/Instanced List", order = -1)]
    public class QuaternionListInstanced : InstancedList<Quaternion>
    {
        protected override RuntimeSet<Quaternion> GenerateListObject()
        {
            return CreateInstance<QuaternionList>();
        }
    }
}