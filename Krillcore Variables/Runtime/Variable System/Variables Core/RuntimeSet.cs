using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace Torstein.VariableSystem.Core
{
    public class RuntimeSet<T> : GameEvent, IEnumerable<T>
    {
        /// <summary>
        /// The actual list of items
        /// </summary>
        [FormerlySerializedAs("Items")]
        [SerializeField]
        private List<T> _items = new List<T>();

        #region Core functions to emulate list/array behaviour

        public T this[int i] => _items[i];

        public int Count => _items.Count;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        #endregion

        #region Functions that modify the list and trigger the OnChanged event

        public void Replace(List<T> list)
        {
            _items = list;
            Raise(this);
        }

        public void Clear()
        {
            _items.Clear();

            Raise(this);
        }

        public bool Add(T t)
        {
            if (!_items.Contains(t))
            {
                _items.Add(t);

                Raise(this);

                return true;
            }
            else
                return false;
        }

        public bool AddRange(T[] t)
        {
            if (t == null || t.Length == 0)
                return false;

            _items.AddRange(t);

            Raise(this);

            return true;
        }

        public bool Remove(T t)
        {
            if (_items.Contains(t))
            {
                _items.Remove(t);

                Raise(this);

                return true;
            }
            else
                return false;
        }

        #endregion

        #region List utility functions

        public bool IsNullOrEmpty()
        {
            return _items == null || _items.Count == 0;
        }

        public bool Contains(T t)
        {
            return _items.Contains(t);
        }

        public List<T> ToList()
        {
            return _items.ToList();
        }

        public T[] ToArray()
        {
            return _items.ToArray();
        }

        /// <summary>
        /// Get a random element from a list.
        /// </summary>
        public T GetRandomElement()
        {
            if (_items == null || _items.Count == 0)
            {
                return default(T);
            }

            return _items[UnityEngine.Random.Range(0, _items.Count)];
        }

        #endregion

        #region LINQ syntax

        // Makes RuntimeSet<T> work with LINQ-like syntax. To add more LINQ like features, use this style (Predicate<T>)
        public bool Exists(Predicate<T> func)
        {
            return _items.Exists(func);
        }

        #endregion
    }
}