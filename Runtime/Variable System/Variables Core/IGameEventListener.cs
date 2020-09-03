using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Torstein.VariableSystem.Core
{
    public interface IGameEventListener
    {
        // When an object subscribes to an event, they supply the return argument themselves.
        // So the subscriber should know the type of what is being returned. They assigned it.
        void OnGameEvent(object returnArgument);
    }
}