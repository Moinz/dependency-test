using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Torstein.VariableSystem.Core
{
    public abstract class InstancedList<T> : SerializedScriptableObject, ISerializationCallbackReceiver
    {
        [LabelText("$RuntimeValueLabel")]
        [HideInEditorMode]
        [ShowInInspector]
        private Dictionary<object, RuntimeSet<T>> _runtimeLists = new Dictionary<object, RuntimeSet<T>>();

        [LabelText("$SerializedValueLabel")]
        [SerializeField]
        [HideIf("ShowOnlyRuntimeValue")]
        private Dictionary<object, RuntimeSet<T>> _serializedLists = new Dictionary<object, RuntimeSet<T>>();

        [SerializeField]
        private bool _savePlaymodeChanges = false;

        private bool ShowOnlyRuntimeValue
        {
            get { return _savePlaymodeChanges && Application.isPlaying; }
        }

        private string RuntimeValueLabel
        {
            get { return ShowOnlyRuntimeValue ? "Lists (r)" : "Lists (Runtime)"; }
        }

        private string SerializedValueLabel
        {
            get { return !Application.isPlaying ? "Lists (s)" : "Lists (Serialized)"; }
        }

        protected override void OnBeforeSerialize()
        {
            if (ShowOnlyRuntimeValue)
                _serializedLists = new Dictionary<object, RuntimeSet<T>>(_runtimeLists);
        }

        protected override void OnAfterDeserialize()
        {
            _runtimeLists = new Dictionary<object, RuntimeSet<T>>(_serializedLists);
        }

        //private static readonly T nullValue;

        public RuntimeSet<T> GetList(object key)
        {
            return GetListInternal(key);
        }

        public bool ListExists(object key)
        {
            return _runtimeLists.TryGetValue(key, out _cachedVariable);
        }

//	public void SetList(object key, T value)
//	{
//		GetListInternal(key).Value = value;
//	}

        private RuntimeSet<T> _cachedVariable;

        private RuntimeSet<T> GetListInternal(object key)
        {
            if (_runtimeLists.TryGetValue(key, out _cachedVariable))
            {
                if (ReferenceEquals(_cachedVariable, null))
                {
                    _runtimeLists.Remove(key);
                    _cachedVariable = CreateAndAddList(key);
                }

                return _cachedVariable;
            }
            else
                return CreateAndAddList(key);
        }

        private RuntimeSet<T> CreateAndAddList(object key)
        {
            var newVariable = GenerateListObject();
            _runtimeLists.Add(key, newVariable);
            return newVariable;
        }

        protected abstract RuntimeSet<T> GenerateListObject();

        public void RegisterListener(object key, GameEvent.GameEventHandler eventHandler, Object listener)
        {
            if (ReferenceEquals(eventHandler, null))
                return;

            GetList(key).RegisterListener(eventHandler, listener);
        }

        public void UnregisterListener(object key, GameEvent.GameEventHandler eventHandler)
        {
            if (ReferenceEquals(eventHandler, null))
                return;

            GetList(key).UnregisterListener(eventHandler);
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

            if (_serializedLists.ContainsKey(_tokenToAdd))
                return false;

            return true;
        }

        [Button()]
        [ShowIf("ShowAddButton")]
        [FoldoutGroup(_manualFoldout)]
        [HideInPlayMode]
        private void AddTokenToDictionary()
        {
            var newVariable = GenerateListObject();
            _serializedLists.Add(_tokenToAdd, newVariable);
        }

        #endregion
    }
}