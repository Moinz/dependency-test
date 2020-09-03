using UnityEngine;
using Torstein.VariableSystem.Core;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem.Types
{
    [CreateAssetMenu(menuName = "Fruitbus/Variables/GameObject/Instanced List", order = -1)]
    public class GameObjectListInstanced : InstancedList<GameObject>
    {
        protected override RuntimeSet<GameObject> GenerateListObject()
        {
            return CreateInstance<GameObjectList>();
        }
    }
}