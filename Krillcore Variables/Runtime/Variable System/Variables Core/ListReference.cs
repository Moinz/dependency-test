using System.Collections;
using System.Collections.Generic;
using Torstein.VariableSystem;
using UnityEngine;

namespace Torstein.VariableSystem.Core
{
    public abstract class ListReference<T>
    {
        public enum AssignmentType
        {
            Constant = 0,
            GlobalVariable = 1,
            PersonalVariable = 2
        }

        public AssignmentType _assignmentType;

        [SerializeField]
        private IDTokenHolder _idTokenHolder;

        public abstract T List
        {
            get;
            //set;
        }

        public abstract void RegisterListener(GameEvent.GameEventHandler eventHandler, UnityEngine.Object listener);

        public abstract void UnregisterListener(GameEvent.GameEventHandler eventHandler);

        protected IDToken IDToken
        {
            get
            {
                if (_idTokenHolder == null)
                    return null;
                return _idTokenHolder.IDToken;
            }
        }
    }
}