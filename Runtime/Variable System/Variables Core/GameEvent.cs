using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEditor;
using Object = UnityEngine.Object;

namespace Torstein.VariableSystem.Core
{
//using Debug = System.Diagnostics.Debug;

//[CreateAssetMenu(fileName = "Game Event", menuName = "Krillbite/Authoring/Game Event", order = 8)]
	public abstract class GameEvent : SerializedScriptableObject
	{
		/// <summary>
		/// This function is called externally to reset all variable back to default
		/// This is primarily called on game restarts, or load new save
		/// Otherwise the variable data will carry over and have unexpected consequences 
		/// </summary>
		public static Action OnGameVariableResetToDefault; 
		
		public delegate void GameEventHandler();

		[FoldoutGroup("Debug", false)]
		[SerializeField]
		//[ReadOnly]
		protected Dictionary<GameEventHandler, Object> _listeners = new Dictionary<GameEventHandler, Object>();

		/*[SerializeField]
		[InspectorButton("DoDebugRaiseEvent")]
		public bool RaiseEvent;
		public void DoDebugRaiseEvent() { Raise(this); }*/

		// GOTCHA: Listeners can not have any unresolved generic properties or whatever. Problems mostly arise when deserializing.
		// So deserializing a GameVariable<T> will probably fail.

		private List<GameEventHandler> _cachedHandlers = new List<GameEventHandler>();
		
		[FoldoutGroup("Debug", false)]
		[ShowInInspector]
		protected bool _eventIsBeingRaised;

		protected void Raise(Object raiser)
		{
			#if UNITY_EDITOR
			if (!Application.isPlaying)
				return;
			#endif
			
			if (_eventIsBeingRaised)
			{
				Debug.LogWarning($"Feedback loop? <b>'{raiser.name}'</b> tried to raise event '{name}' while it was already being raised. (This usually means that the listener of a variable tries to also SET the same variable in response, causing a loop.)");
				return;
			}

			_eventIsBeingRaised = true;

			if (_listeners == null)
				_listeners = new Dictionary<GameEventHandler, Object>();

			//Changed for only getting the keys into its own list, to also check if the value is null, which might happen on reset, if not all scripts does unlisten
			_cachedHandlers.Clear();
			_cachedHandlers.AddRange(_listeners.Keys); // FIXME: Probably generates a lot of garbage

			foreach (var handler in _cachedHandlers)
			{
				// Currently, if any code throws an exception, and it is called by a variable change or 
				// or by a Trigger, it can have some pretty bad consequences.
				// Something like this try-catch would be nice to prevent total meltdown, but it's very expensive.
				//try
				//{

				//Changed for only getting the keys into its own list, to also check if the value is null, which might happen on reset, if not all scripts does unlisten
				if (_listeners[handler] != null)
					handler?.Invoke();
				//}
				//catch (Exception e)
				//{
				//	Debug.LogError(e);
				//}
			}

			_eventIsBeingRaised = false;
		}

		public void RegisterListener(GameEventHandler eventHandler, Object listener)
		{
			if (ReferenceEquals(eventHandler, null))
				return;

			if (!HasListener(eventHandler))
			{
				_listeners.Add(eventHandler, listener);
			}
		}

		public void UnregisterListener(GameEventHandler eventHandler)
		{
			if (ReferenceEquals(eventHandler, null))
				return;

			if (HasListener(eventHandler))
			{
				_listeners.Remove(eventHandler);
			}
		}

		protected bool HasListener(GameEventHandler eventHandler)
		{
			return _listeners.ContainsKey(eventHandler);
		}


		[FoldoutGroup("Debug", false)]
		[Button("Reset EventIsBeingRaised")]
		private void DebugReset()
		{
			_eventIsBeingRaised = false;
		}
		
		private void OnEnable()
		{
			// We probably don't need this anymore, but I'm leaving it in for the historians. - Bjørnar (2020 07 30)
			HackyInit();

			OnGameVariableResetToDefault += OnResetVariable;
			OnInitialize();
		}

		/// <summary>
		/// Previously implemented in Trigger.cs, this code makes sure _eventIsBeingRaised is false and the _listeners list is empty when starting the game.
		/// It's currently unknown why this is necessary, as _eventIsBeingRaised should initialize to false. Could be an issue with some inspector code for scriptable object variables.
		/// Stay tuned for further updates. - Bjørnar (2020 07 29)
		/// </summary>
		private void HackyInit()
		{
			// For some reason this is sometimes lingering as True when we enter play mode. 
			// This hack used to be in Trigger.cs, but we have encountered the problem elsewhere so we have moved it to this base class.
			_eventIsBeingRaised = false;
			
			// We have added a check that disallows registering of listeners outside of play mode, so will now test if everything works fine without this hacky clearing.
			// _listeners?.Clear();
		}

		protected virtual void OnInitialize()
		{ }
        
		private void OnDisable()
		{
			_eventIsBeingRaised = false;
			OnGameVariableResetToDefault -= OnResetVariable;
		}

		protected virtual void OnResetVariable()
		{
			_eventIsBeingRaised = false;
		}
		
		protected override void OnBeforeSerialize()
		{
#if UNITY_EDITOR		
			if (string.IsNullOrEmpty(_unityFileGuid))
			{
				RefreshUnityFileGuid();
			}
#endif
			
			base.OnBeforeSerialize(); 
		}
		
		[FoldoutGroup("Debug", false)]
		[SerializeField]
		protected string _unityFileGuid;

#if UNITY_EDITOR
		protected void RefreshUnityFileGuid()
		{
			UnityEditor.AssetDatabase.TryGetGUIDAndLocalFileIdentifier(GetInstanceID(), out _unityFileGuid, out long x);
		}
#endif


        public string UnityFileGuid => _unityFileGuid;
	}
}
