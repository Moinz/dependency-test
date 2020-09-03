using UnityEngine;
using Sirenix.OdinInspector;

namespace Torstein.VariableSystem.Core
{
	public class IDTokenHolder : MonoBehaviour
	{
			
#pragma warning disable 0414 
		
		// The field '_autoGenerateToken' is assigned but its value is never used
		[SerializeField]
		private bool _autoGenerateToken = true;
		
#pragma warning restore 0414

		[SerializeField] [HideIf("_autoGenerateToken")] [Required]
		private IDToken _identifierToken;

		public virtual IDToken IDToken
		{
			get
			{
				if (_identifierToken == null)
					return GeneratedToken;
				
				return _identifierToken;
			}
			
			set { _identifierToken = value; }
		}
		
		private IDToken _generatedToken;
		private IDToken GeneratedToken
		{
			get
			{
				if (_generatedToken == null)
				{
					_generatedToken = ScriptableObject.CreateInstance<IDToken>();
					_generatedToken.name = name;
				}

				return _generatedToken;
			}
		}

		//public BoolReference _boolRef;

		// TODO: Perhaps add an Event for when _identifierToken changes
	}
}
