using System;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Torstein.VariableSystem.Core
{
    public abstract class GameVariable<T> : GameEvent, ISerializationCallbackReceiver
    {
        [LabelText("$RuntimeValueLabel")]
        [DisableInEditorMode]
        [ShowInInspector]
        private T _runtimeValue;

        [LabelText("$SerializedValueLabel")]
        [SerializeField]
        [DisableInPlayMode]
//	[HideIf("SaveRuntimeValue")]
        private T _serializedValue;

        [HideInEditorMode] [ShowInInspector] private T _defaultValue;

        [FoldoutGroup("Debug")]
        [SerializeField] private bool _logOnChanged;
        

        public T Value
        {
            get
            {
                if (_logOnChanged)
                {
                    Debug.Log($"On variable changed: {name} |Get: {_runtimeValue}");
                }
                
                return _runtimeValue;
            }

            set
            {
                if (_logOnChanged)
                {
                    Debug.Log($"On variable changed: {name} |Set: {value}");
                }
                
                if (_runtimeValue != null)
                    if (_runtimeValue.Equals(value))
                        return;

                _runtimeValue = value;

                Raise(this);
            }
        }

        public bool IsDefaultValue()
        {
            return Value.Equals(_defaultValue);
        }

        public void ResetValueToDefault()
        {
            Value = _defaultValue;
        }

        [SerializeField]
        private bool _savePlaymodeChanges = false;

        private bool SaveRuntimeValue => _savePlaymodeChanges && Application.isPlaying;
        private string RuntimeValueLabel => "Runtime Value";
        private string SerializedValueLabel => "Serialized Value";

        protected override void OnBeforeSerialize()
        {
            if (SaveRuntimeValue)
            {
                Debug.Log($" {this} serializing runtime value '{_runtimeValue}' (Old serialized value was {_serializedValue})");
                _serializedValue = _runtimeValue;
            }
            
#if UNITY_EDITOR		
            if (string.IsNullOrEmpty(_unityFileGuid))
            {
                RefreshUnityFileGuid();
            }
#endif
        }

        protected override void OnAfterDeserialize()
        {
            _runtimeValue = _serializedValue;
        }
        
        protected override void OnInitialize()
        {
            base.OnInitialize();
            _defaultValue = Value;
        }

        protected override void OnResetVariable()
        {
            base.OnResetVariable();
            Value = _defaultValue;
        }
        
        /*
	private void OnValidate()
	{
		// Not sure why this is here. Removing to see if it has any adverse effects!  -Bjørnar
//		Raise(this);
	}
*/

        // Interesting thing here where it raises the event as soon as the game starts.
        // But in practice no one would be subscribed to the event yet?
        // FIXME: Called on compile in editor... Sort of accidentally works...
        /*private void OnEnable()
        {
            //GameCallbacks.OnGameLateStart -= OnGameLateStart;
            //GameCallbacks.OnGameLateStart += OnGameLateStart;
        }
    
        private void OnGameLateStart()
        {
            if (_resetOnLoad)
                _value = _savedValue;
    
            Raise(this);
        }*/
    }
}