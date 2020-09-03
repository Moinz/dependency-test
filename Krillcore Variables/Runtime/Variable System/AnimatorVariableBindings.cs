using System.Collections;
using System.Collections.Generic;
using Torstein.VariableSystem.Core;
using UnityEngine;
using Torstein.VariableSystem.Types;

namespace Torstein.VariableSystem
{
    public class AnimatorVariableBindings : MonoBehaviour, IGameEventListener
    {
        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private List<Binding> _bindings = new List<Binding>();

        private List<GameEvent.GameEventHandler> _eventHandlers = new List<GameEvent.GameEventHandler>();

        private void OnEnable()
        {
            _eventHandlers.Clear();

            foreach (var binding in _bindings)
            {
                var cachedBinding = binding;

                GameEvent.GameEventHandler eventHandler = () => { OnGameEvent(cachedBinding); };
                _eventHandlers.Add(eventHandler);

                binding.variable.RegisterListener(eventHandler, this);
            }
        }

        private void OnDisable()
        {
            foreach (var binding in _bindings)
            {
                foreach (var eventHandler in _eventHandlers)
                {
                    binding.variable.UnregisterListener(eventHandler);
                }
            }

            _eventHandlers.Clear();
        }

        public void OnGameEvent(object returnArgument)
        {
            var binding = (Binding) returnArgument;

            if (binding.variable as Trigger != null)
            {
                _animator.SetTrigger(binding.animatorParameter);
            }
            else if (binding.variable as BoolVariable != null)
            {
                _animator.SetBool(binding.animatorParameter, ((BoolVariable) binding.variable).Value);
            }
            else if (binding.variable as IntVariable != null)
            {
                _animator.SetInteger(binding.animatorParameter, ((IntVariable) binding.variable).Value);
            }
            else if (binding.variable as FloatVariable != null)
            {
                _animator.SetFloat(binding.animatorParameter, ((FloatVariable) binding.variable).Value);
            }
        }

        [System.Serializable]
        public class Binding
        {
            public string animatorParameter;
            public GameEvent variable;
        }
    }
}