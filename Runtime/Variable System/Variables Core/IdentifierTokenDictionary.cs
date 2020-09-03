using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// If you need to match an instance of a prefab to an identifier token, use this.
// For example, when a player is spawned, a reference to their gameobject is stored here.
// It is matched with a reference to the corresponding identifier token.

// TODO: This class can maybe be deleted... It was made originally to solve the same problem IDTokens solve.

namespace Torstein.VariableSystem.Core
{
    [CreateAssetMenu(fileName = "Identifier Token Dictionary", menuName = "Fruitbus/Variables/ID Token/Identifier Token Dictionary", order = -1000)]
    public class IdentifierTokenDictionary : SerializedScriptableObject //, ISerializationCallbackReceiver
    {
        [LabelText("Prefab Instance / Identifier Token Dictionary")]
        [ShowInInspector]
        private Dictionary<GameObject, IDToken> _identifierDictionary = new Dictionary<GameObject, IDToken>();

        private IDToken _cachedToken = null;

        /*protected override void OnBeforeSerialize()
        {
            _identifierDictionary = new Dictionary<GameObject, IdentifierToken>();
        }*/

        public IDToken GetIdentifierToken(GameObject key)
        {
            CleanDictionary();

            _identifierDictionary.TryGetValue(key, out _cachedToken);

            return _cachedToken;
        }

        public void AddEntry(GameObject key, IDToken value, bool alsoAddAllChildren = false)
        {
            CleanDictionary();

            if (alsoAddAllChildren)
                RecursivelyAddChildren(key.transform, value);
            else
                _identifierDictionary.Add(key, value);
        }

        private void RecursivelyAddChildren(Transform keyTransform, IDToken value)
        {
            AddEntry(keyTransform.gameObject, value);

            for (int i = 0; i < keyTransform.childCount; i++)
            {
                RecursivelyAddChildren(keyTransform.GetChild(i), value);
            }
        }

        /*public void RemoveIdentifierToken(GameObject key)
        {
            _identifierDictionary.Remove(key);
        }*/

        private List<GameObject> _nullObjects = new List<GameObject>();

        private void CleanDictionary()
        {
            foreach (var keyValuePair in _identifierDictionary)
            {
                if (keyValuePair.Key == null)
                    _nullObjects.Add(keyValuePair.Key);
            }

            foreach (var nulledGo in _nullObjects)
            {
                _identifierDictionary.Remove(nulledGo);
            }

            _nullObjects.Clear();
        }
    }
}