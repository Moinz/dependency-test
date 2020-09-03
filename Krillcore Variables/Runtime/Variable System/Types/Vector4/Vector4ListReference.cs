using UnityEngine;
using Torstein.VariableSystem.Types;
using Torstein.VariableSystem.Core;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem
{
	[System.Serializable]
	public class Vector4ListReference : ListReference<Vector4List>
	{
		[SerializeField]
		private Vector4List _constantValue;
		[SerializeField]
		private Vector4List _globalVariable;
		[SerializeField]
		private Vector4ListInstanced _instancedVariable;

		public override Vector4List List
		{
			get
			{
				switch (_assignmentType)
				{
					case AssignmentType.PersonalVariable:
						return (Vector4List)_instancedVariable.GetList(IDToken);

					case AssignmentType.GlobalVariable:
						return _globalVariable;

					case AssignmentType.Constant:
					    default:
						return _constantValue;
				}
			}

//			set
//			{
//				switch (_assignmentType)
//				{
//					case AssignmentType.PersonalVariable:
//						_instancedVariable.SetValue(IDToken, value);
//						break;
//
//					case AssignmentType.GlobalVariable:
//						_globalVariable.Value = value;
//						break;
//
//					case AssignmentType.Constant:
//					default:
//						_constantValue = value;
//						break;
//				}
//			}
		}

		// TODO: I wish these could be in base class ValueReference...
		public override void RegisterListener(GameEvent.GameEventHandler eventHandler, UnityEngine.Object listener)
		{
		    #if UNITY_EDITOR
		    if(!Application.isPlaying)
		    {
		        return;
		    }
		    #endif

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

		public override void UnregisterListener(GameEvent.GameEventHandler eventHandler)
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