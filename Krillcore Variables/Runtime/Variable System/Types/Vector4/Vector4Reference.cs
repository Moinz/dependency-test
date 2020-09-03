using UnityEngine;
using Torstein.VariableSystem.Types;
using Torstein.VariableSystem.Core;

// This file is auto-generated TypeGenerator.cs. Never edit this directly.

namespace Torstein.VariableSystem
{
	[System.Serializable]
	public class Vector4Reference : ValueReference<Vector4>
	{
		[SerializeField]
		private Vector4Variable _globalVariable;
		[SerializeField]
		private Vector4VariableInstanced _instancedVariable;

		public Vector4Reference() : base()
		{
		}

		public Vector4Reference(Vector4 constantValue) : base(constantValue)
		{
			_constantValue = constantValue;
		}

		public Vector4Reference(AssignmentType type) : base(type)
		{
			_assignmentType = type;
		}
	
		public Vector4Reference(Vector4 constantValue, AssignmentType type) : base(constantValue, type)
		{
			_constantValue = constantValue;
			_assignmentType = type;
		}

		public override Vector4 Value
		{
			get
			{
				switch (_assignmentType)
				{
					case AssignmentType.PersonalVariable:
						return _instancedVariable.GetValue(IDToken);

					case AssignmentType.GlobalVariable:
						return _globalVariable.Value;

					case AssignmentType.Constant:
					default:
						return _constantValue;
				}
			}

			set
			{
				switch (_assignmentType)
				{
					case AssignmentType.PersonalVariable:
						_instancedVariable.SetValue(IDToken, value);
						break;

					case AssignmentType.GlobalVariable:
						_globalVariable.Value = value;
						break;

					case AssignmentType.Constant:
					default:
						_constantValue = value;
						break;
				}
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
        
        public override string Name
        {
        	get
        	{
        		switch (_assignmentType)
        		{
        			case AssignmentType.Constant: return $"Constant Vector4";
        			case AssignmentType.GlobalVariable: return _globalVariable.name;
        			case AssignmentType.PersonalVariable: return _instancedVariable.name;
        			default:
        				throw new System.ArgumentOutOfRangeException();
        		}
        	}
        }
        
        public override string UnityFileGuid
        {
	        get
	        {
		        switch (_assignmentType)
		        {
			        case AssignmentType.Constant: return $"Constant Vector4";
			        case AssignmentType.GlobalVariable: return _globalVariable.UnityFileGuid;
			        case AssignmentType.PersonalVariable: return _instancedVariable.UnityFileGuid;
			        default:
				        throw new System.ArgumentOutOfRangeException();
		        }
	        }
        }
        
        public bool IsDefaultValue()
        {
        	switch (_assignmentType)
        	{
        		case AssignmentType.Constant: return false;
        		case AssignmentType.GlobalVariable: return _globalVariable.IsDefaultValue();
        		case AssignmentType.PersonalVariable: return _instancedVariable.GetVariable(IDToken).IsDefaultValue();
        		default:
        			throw new System.ArgumentOutOfRangeException();
        	}
        }
        
        public void ResetValueToDefault()
        {
        	switch (_assignmentType)
        	{
        		case AssignmentType.Constant: break;
        		case AssignmentType.GlobalVariable: _globalVariable.ResetValueToDefault(); break;
        		case AssignmentType.PersonalVariable: _instancedVariable.GetVariable(IDToken).ResetValueToDefault(); break;
        		default:
        		    throw new System.ArgumentOutOfRangeException();
        	}
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
		
#if UNITY_EDITOR
   		public void EditorSetVariableData(Vector4Variable global, Vector4VariableInstanced instanced, Vector4 constant,
   			AssignmentType type, IDTokenHolder tokenHolder)
   		{
   			_assignmentType = type;
   			EditorSetTokenHolder(tokenHolder);
   			
   			switch (type)
   			{
   				case AssignmentType.Constant:
   					_constantValue = constant;
   					break;
   				case AssignmentType.GlobalVariable:
   					_globalVariable = global;
   					break;
   				case AssignmentType.PersonalVariable:
   					_instancedVariable = instanced;
   					break;
   			}
   		}
#endif
	}
}