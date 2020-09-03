using UnityEngine;
using Torstein.VariableSystem.Core;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Types
{
    [CreateAssetMenu(menuName = "Fruitbus/Variables/Camera/Instanced List", order = -1)]
    public class CameraListInstanced : InstancedList<Camera>
    {
        protected override RuntimeSet<Camera> GenerateListObject()
        {
            return CreateInstance<CameraList>();
        }
    }
}