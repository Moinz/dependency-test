using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Torstein.VariableSystem.Core
{
    public abstract class InstancedVariable<T> : SerializedScriptableObject, ISerializationCallbackReceiver
    {
        [LabelText("$RuntimeValueLabel")]
        [HideInEditorMode]
        [ShowInInspector]
        private Dictionary<object, GameVariable<T>> _runtimeVariables = new Dictionary<object, GameVariable<T>>();

        [LabelText("$SerializedValueLabel")]
        [SerializeField]
        [HideIf("ShowOnlyRuntimeValue")]
        private Dictionary<object, GameVariable<T>> _serializedVariables = new Dictionary<object, GameVariable<T>>();

        [SerializeField]
        private bool _savePlaymodeChanges = false;

        [SerializeField]
        [ShowIf("TypeIsScriptableObject")]
        private bool _autoGenerateNewEntries = false;

        private bool ShowOnlyRuntimeValue
        {
            get { return _savePlaymodeChanges && Application.isPlaying; }
        }

        private string RuntimeValueLabel
        {
            get { return ShowOnlyRuntimeValue ? "Variables (r)" : "Variables (Runtime)"; }
        }

        private string SerializedValueLabel
        {
            get { return !Application.isPlaying ? "Variables (s)" : "Variables (Serialized)"; }
        }

        private bool TypeIsScriptableObject => typeof(ScriptableObject).IsAssignableFrom(typeof(T));

        protected override void OnBeforeSerialize()
        {
            if (ShowOnlyRuntimeValue)
                _serializedVariables = new Dictionary<object, GameVariable<T>>(_runtimeVariables);

#if UNITY_EDITOR		
            if (string.IsNullOrEmpty(_unityFileGUID))
            {
                RefreshUnityFileGUID();
            }
#endif
        }

        protected override void OnAfterDeserialize()
        {
            _runtimeVariables = new Dictionary<object, GameVariable<T>>(_serializedVariables);
        }

        [SerializeField]
        private string _unityFileGUID;
        
        public string UnityFileGuid => _unityFileGUID;
        
#if UNITY_EDITOR		
        private void RefreshUnityFileGUID()
        {
            var assetPath = UnityEditor.AssetDatabase.GetAssetPath(this);
            _unityFileGUID = UnityEditor.AssetDatabase.AssetPathToGUID(assetPath);
        }
#endif
        
        //private static readonly T nullValue;

        public T GetValue(object key)
        {
            return GetVariable(key).Value;
        }

        public void SetValue(object key, T value)
        {
            GetVariable(key).Value = value;
        }

        private GameVariable<T> _cachedVariable;

        public GameVariable<T> GetVariable(object key)
        {
            if (_runtimeVariables.TryGetValue(key, out _cachedVariable))
            {
                if (ReferenceEquals(_cachedVariable, null))
                {
                    _runtimeVariables.Remove(key);
                    _cachedVariable = CreateAndAddVariable(key);
                }

                return _cachedVariable;
            }
            else
                return CreateAndAddVariable(key);
        }

        private GameVariable<T> CreateAndAddVariable(object key)
        {
            var newVariable = GenerateVariableObject();
            _runtimeVariables.Add(key, newVariable);

            // This is implemented for VirtualGamepad
            if (newVariable.Value == null && _autoGenerateNewEntries && TypeIsScriptableObject)
            {
                // HACK: This is very, very dirty code :(
                newVariable.Value = (T) (object) CreateInstance(typeof(T));
            }
            // End of VirtualGamepad thingy

// #if UNITY_EDITOR
            // Add key name as prefix.
            // Will return variable objects named like this: "Player 1 ID Token's [Player Is Driving]"
            // TODO: Check performance impact of this casting. It's purely a decorative/debug thing.
            string prefix = 
                key is Object unityObj ?
                $"{unityObj.name}'s" 
                : "";
            newVariable.name = $"{prefix}[{name}]";
            
            // Uncomment this to see variable names being initialized
            // Debug.Log("var init: " + newVariable.name);
// #endif

            return newVariable;
        }

        protected abstract GameVariable<T> GenerateVariableObject();

        public void RegisterListener(object key, GameEvent.GameEventHandler eventHandler, UnityEngine.Object listener)
        {
            if (ReferenceEquals(eventHandler, null))
                return;

            GetVariable(key).RegisterListener(eventHandler, listener);
        }

        public void UnregisterListener(object key, GameEvent.GameEventHandler eventHandler)
        {
            if (ReferenceEquals(eventHandler, null))
                return;

            GetVariable(key).UnregisterListener(eventHandler);
        }

        #region Editor Stuff

        private const string _manualFoldout = "Use this to manually add tokens in editor";

        [SerializeField]
        [FoldoutGroup(_manualFoldout)]
        [HideInPlayMode]
        private IDToken _tokenToAdd;

        private bool ShowAddButton()
        {
            if (_tokenToAdd == null)
                return false;

            if (_serializedVariables.ContainsKey(_tokenToAdd))
                return false;

            return true;
        }

        [Button()]
        [ShowIf("ShowAddButton")]
        [FoldoutGroup(_manualFoldout)]
        [HideInPlayMode]
        private void AddTokenToDictionary()
        {
            var newVariable = GenerateVariableObject();
            _serializedVariables.Add(_tokenToAdd, newVariable);
        }

        #endregion
    }
}
