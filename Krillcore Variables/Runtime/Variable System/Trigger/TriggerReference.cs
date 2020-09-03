using Torstein.VariableSystem.Core;
using UnityEngine;
using Torstein.VariableSystem.Types;

namespace Torstein.VariableSystem
{
	[System.Serializable]
	public class TriggerReference
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

		[SerializeField]
		private Trigger _constantValue; // HACKY...
		[SerializeField]
		private Trigger _globalVariable;
		[SerializeField]
		private InstancedTrigger _instancedVariable;

		public void Invoke(Object caller)
		{
			switch (_assignmentType)
			{
				case AssignmentType.PersonalVariable:
					if (ReferenceEquals(_instancedVariable, null) || ReferenceEquals(IDToken, null))
						return;
					_instancedVariable.Invoke(IDToken, caller);
					break;

				case AssignmentType.GlobalVariable:
					if (ReferenceEquals(_globalVariable, null))
						return;
					_globalVariable.Invoke(caller);
					break;

				case AssignmentType.Constant:
				default:
					return;
			}
		}
		
		public bool HasReference
		{
			get
			{
				switch (_assignmentType)
				{
					case AssignmentType.Constant: return true;
					case AssignmentType.GlobalVariable: return !ReferenceEquals(_globalVariable, null);
					case AssignmentType.PersonalVariable: return !ReferenceEquals(_instancedVariable, null);
					default:
						throw new System.ArgumentOutOfRangeException();
				}
			}
		}
		
		public string Name
		{
			get
			{
				switch (_assignmentType)
				{
					case AssignmentType.Constant: return $"Constant Bool";
					case AssignmentType.GlobalVariable: return _globalVariable.name;
					case AssignmentType.PersonalVariable: return _instancedVariable.name;
					default:
						throw new System.ArgumentOutOfRangeException();
				}
			}
		}


		public void RegisterListener(GameEvent.GameEventHandler eventHandler, UnityEngine.Object listener)
		{
			//if (ReferenceEquals(listener, null))
			//	return;

			switch (_assignmentType)
			{
				case AssignmentType.PersonalVariable:
					if (ReferenceEquals(_instancedVariable, null) || ReferenceEquals(IDToken, null))
						return;
					_instancedVariable.RegisterListener(IDToken, eventHandler, listener);
					break;

				case AssignmentType.GlobalVariable:
					if (ReferenceEquals(_globalVariable, null))
						return;
					_globalVariable.RegisterListener(eventHandler, listener);
					break;

				case AssignmentType.Constant:
				default:
					return;
			}
		}

		public void UnregisterListener(GameEvent.GameEventHandler eventHandler)
		{
			//if (ReferenceEquals(listener, null))
			//	return;

			switch (_assignmentType)
			{
				case AssignmentType.PersonalVariable:
					if (ReferenceEquals(_instancedVariable, null) || ReferenceEquals(IDToken, null))
						return;
					_instancedVariable.UnregisterListener(IDToken, eventHandler);
					break;

				case AssignmentType.GlobalVariable:
					if (ReferenceEquals(_globalVariable, null))
						return;
					_globalVariable.UnregisterListener(eventHandler);
					break;

				case AssignmentType.Constant:
				default:
					return;
			}
		}
	}
}