using Sirenix.OdinInspector;
using Torstein.VariableSystem.Core;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Torstein.VariableSystem
{
    [CreateAssetMenu(fileName = "Global Trigger", menuName = "Fruitbus/Variables/Trigger/Global Trigger", order = -1000)]
    public class Trigger : GameEvent
    {
        [ShowInInspector]
        private int _triggerCount;
        
        public void Invoke(Object caller)
        {
            _triggerCount++;
            
            Raise(caller);
        }
    }
}