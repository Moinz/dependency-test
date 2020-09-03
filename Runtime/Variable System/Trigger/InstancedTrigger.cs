using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Torstein.VariableSystem.Core;

namespace Torstein.VariableSystem
{
    [CreateAssetMenu(fileName = "Instanced Trigger", menuName = "Fruitbus/Variables/Trigger/Instanced Trigger", order = -1000)]
    public class InstancedTrigger : SerializedScriptableObject
    {
        [ShowInInspector]
        private Dictionary<object, Trigger> _triggerDictionary = new Dictionary<object, Trigger>();

        public void Invoke(object key, Object caller)
        {
            GetTrigger(key).Invoke(caller);
        }

        /// <summary>
        /// This can be used to invoke a trigger from a UnityEvent, by referring to the trigger variable object and passing in an ID token holder.
        /// </summary>
        /// <param name="idTokenHolder"></param>
        public void InvokeWithTokenHolder(IDTokenHolder idTokenHolder)
        {
            GetTrigger(idTokenHolder.IDToken).Invoke(idTokenHolder);
        }

        private Trigger _cachedTrigger;

        /// <summary>
        /// Get the trigger belonging to a specific ID Token.
        /// </summary>
        /// <param name="key">ID Token</param>
        /// <returns>Cached or newly created trigger reference.</returns>
        private Trigger GetTrigger(object key)
        {
            if (_triggerDictionary.TryGetValue(key, out _cachedTrigger))
            {
                if (ReferenceEquals(_cachedTrigger, null))
                {
                    _triggerDictionary.Remove(key);
                    _cachedTrigger = CreateAndAddTrigger(key);
                }

                return _cachedTrigger;
            }
            else
                return CreateAndAddTrigger(key);
        }

        private Trigger CreateAndAddTrigger(object key)
        {
            var newObject = GenerateTriggerObject();
            _triggerDictionary.Add(key, newObject);

            return newObject;
        }

        private Trigger GenerateTriggerObject()
        {
            return CreateInstance<Trigger>();
        }

        public void RegisterListener(object key, GameEvent.GameEventHandler eventHandler, UnityEngine.Object listener)
        {
            if (ReferenceEquals(eventHandler, null))
                return;

            GetTrigger(key).RegisterListener(eventHandler, listener);
        }

        public void UnregisterListener(object key, GameEvent.GameEventHandler eventHandler)
        {
            if (ReferenceEquals(eventHandler, null))
                return;

            GetTrigger(key).UnregisterListener(eventHandler);
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

            if (_triggerDictionary.ContainsKey(_tokenToAdd))
                return false;

            return true;
        }

        [Button()]
        [ShowIf("ShowAddButton")]
        [FoldoutGroup(_manualFoldout)]
        [HideInPlayMode]
        private void AddTokenToDictionary()
        {
            var newTrigger = GenerateTriggerObject();
            _triggerDictionary.Add(_tokenToAdd, newTrigger);
        }

        #endregion
    }
}