using System.Collections;
using System.Collections.Generic;
using Torstein.VariableSystem;
using UnityEngine;

namespace Torstein.VariableSystem.Core
{
    public abstract class ValueReference<T>
    {
        protected ValueReference()
        {
        }

        protected ValueReference(T constantValue)
        {
            _constantValue = constantValue;
        }

        protected ValueReference(AssignmentType type)
        {
            _assignmentType = type;
        }

        protected ValueReference(T constantValue, AssignmentType type)
        {
            _constantValue = constantValue;
            _assignmentType = type;
        }

        public enum AssignmentType
        {
            Constant = 0,
            GlobalVariable = 1,
            PersonalVariable = 2
        }

        public AssignmentType _assignmentType;

        [SerializeField]
        private IDTokenHolder _idTokenHolder;

        // TODO: REMOVE
        //[SerializeField]
        //protected bool _useConstant;

        [SerializeField]
        protected T _constantValue;

        public abstract T Value { get; set; }

        public abstract string Name { get; }
        
        public abstract string UnityFileGuid { get; }

        
        public abstract void RegisterListener(GameEvent.GameEventHandler eventHandler, Object listener);

        public abstract void UnregisterListener(GameEvent.GameEventHandler eventHandler);

        protected IDToken _overrideToken;

        public void SetOverrideToken(IDToken overrideToken)
        {
            _overrideToken = overrideToken;
        }

        protected IDToken IDToken
        {
            get
            {
                if (_overrideToken != null)
                    return _overrideToken;

                if (_idTokenHolder == null)
                    return null;
                return _idTokenHolder.IDToken;
            }
        }

        #if UNITY_EDITOR
        protected void EditorSetTokenHolder(IDTokenHolder tokenHolder)
        {
            _idTokenHolder = tokenHolder;
        }
        #endif
        
        /*
        [SerializeField]
        public GameVariable<T> _dynamicValue; // FIXME: This doesn't get serialized. Doesn't show up in editor and doesn't get saved.
        
        public T Value
        {
            get { return _useConstant ? _constantValue : _dynamicValue.Value; }
    
            set
            {
                if (_useConstant)
                    _constantValue = value;
                else
                    _dynamicValue.Value = value;
            }
        }
    
        public void RegisterListener(IGameEventListener listener, object returnArgument)
        {
            if (ReferenceEquals(listener, null))
                return;
    
            if (ReferenceEquals(_dynamicValue, null))
                return;
    
            _dynamicValue.RegisterListener(listener, returnArgument);
        }
    
        public void UnregisterListener(IGameEventListener listener)
        {
            if (ReferenceEquals(listener, null))
                return;
    
            if (ReferenceEquals(_dynamicValue, null))
                return;
    
            _dynamicValue.UnregisterListener(listener);
        }*/
    }
}