#if UNITY_EDITOR
using System;
using System.Linq;
using System.IO;
using System.Text;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEditor;

// Some of the code here is borrowed from Trond Fasteraune's variable system

namespace Torstein.VariableSystem
{
	[CreateAssetMenu(menuName = "Fruitbus/Variables/Variable System Utilities/Variable Type Script Generator", order = -1000)]
	public class TypeGenerator : SerializedScriptableObject
	{
		private const string TemplateGroupName = "Template Files";

		[SerializeField]  private string _destinationFilepath = "Assets/Variable System/Types";

		[SerializeField] 
		private TypeTemplate[] _typeTemplates;
		
		[SerializeField]  private string[] _typeNames = new string[] { "bool", "int", "float", "string", "GameObject", "Vector3", "Texture2D", "Color" };

		private static bool _yesToAllNamespaceMessages;

		[Button(ButtonHeight = 30)]
		public void GenerateTypeScripts()
		{
			float progress = 0f;
			float step = 1f / _typeNames.Length; 
			
			_yesToAllNamespaceMessages = false;

			foreach (var typeName in _typeNames)
			{
				progress += step;
				
				EditorUtility.DisplayProgressBar("Generating Types...", typeName, progress);
				GenerateType(_destinationFilepath, typeName, true);
			}
			
			EditorUtility.ClearProgressBar();
			AssetDatabase.Refresh();
		}
 
		
		public void GenerateType(string basePath, string namespacedTypeName, bool batch = false)
		{
			if (string.IsNullOrEmpty(basePath))
				return;
			if (string.IsNullOrEmpty(namespacedTypeName))
				return;

			// Display name is capitalized, so "float" becomes "Float" and such.
			var capitalizedTypeName = char.ToUpper(namespacedTypeName[0]) + namespacedTypeName.Substring(1);
			
			var typeFolderPath = basePath + "/" + capitalizedTypeName + "/"; // Folder name keeps namespace for clarity

			string typeNamespace = null;
			
			
			bool userWantsToHandleNamespaces = DetectAndHandleNamespace(ref namespacedTypeName, ref capitalizedTypeName, ref typeNamespace);
			if (userWantsToHandleNamespaces == false && !_yesToAllNamespaceMessages) return; //skipped

			var editorPath = typeFolderPath + "/Editor/";

			ValidatePath(typeFolderPath);
			ValidatePath(editorPath);

			foreach (var template in _typeTemplates)
			{
				var path = template.pathConvention == TypeTemplate.PathConventionEnum.TypeFolder
					? typeFolderPath
					: editorPath;

				var names = GetNames(namespacedTypeName, capitalizedTypeName, template.namingConvention);
				
				CreateScriptFile(template.templateFile.text, path, names[0], names[1], template.fileNamePrefix, template.fileNamePostFix, typeNamespace);
			}
			/*
			// Generate Variable, InstancedVariable, Reference, and List types
			CreateScriptFile(_variableTemplate.text, typeFolderPath, namespacedTypeName, capitalizedTypeName, "", "Variable.cs", typeNamespace);
			CreateScriptFile(_instancedVariableTemplate.text, typeFolderPath, namespacedTypeName, capitalizedTypeName, "", "VariableInstanced.cs", typeNamespace);
			CreateScriptFile(_variableReferenceTemplate.text, typeFolderPath, namespacedTypeName, capitalizedTypeName, "", "Reference.cs", typeNamespace);
			
			CreateScriptFile(_readVariableReferenceTemplate.text, typeFolderPath, namespacedTypeName, capitalizedTypeName, "Read", "Reference.cs", typeNamespace);
			CreateScriptFile(_writeVariableReferenceTemplate.text, typeFolderPath, namespacedTypeName, capitalizedTypeName, "Write", "Reference.cs", typeNamespace);
			
			// Generate Variable, InstancedVariable, and Reference types for the newly generated List type
			//var listTypeName = displayTypeName + "List";
			//var listDisplayTypeName = char.ToUpper(listTypeName[0]) + listTypeName.Substring(1, typeNamespace);
			CreateScriptFile(_listTemplate.text, typeFolderPath, namespacedTypeName, capitalizedTypeName, "", "List.cs", typeNamespace);
			CreateScriptFile(_instancedListTemplate.text, typeFolderPath, namespacedTypeName, capitalizedTypeName, "", "ListInstanced.cs", typeNamespace);
			CreateScriptFile(_listReferenceTemplate.text, typeFolderPath, capitalizedTypeName + "List", capitalizedTypeName, "", "ListReference.cs", typeNamespace);
			CreateScriptFile(_readListReferenceTemplate.text, typeFolderPath, capitalizedTypeName + "List", capitalizedTypeName, "Read", "ListReference.cs", typeNamespace);
			CreateScriptFile(_writeListReferenceTemplate.text, typeFolderPath, capitalizedTypeName + "List", capitalizedTypeName, "Write", "ListReference.cs", typeNamespace);

			// Generate Drawer for variable
			CreateScriptFile(_referenceDrawerTemplate.text, editorPath, namespacedTypeName, capitalizedTypeName, "",  "ReferenceDrawer.cs", typeNamespace);
			// Generate Drawer for list
			CreateScriptFile(_referenceDrawerTemplate.text, editorPath, namespacedTypeName, capitalizedTypeName + "List", "",  "ReferenceDrawer.cs", typeNamespace);
			// Generate Behavior Designer type SharedVariable
			CreateScriptFile(_sharedVariableTemplate.text, typeFolderPath, namespacedTypeName, capitalizedTypeName, "",  "SharedVariable.cs", typeNamespace);
			CreateScriptFile(_sharedVariableListTemplate.text, typeFolderPath, capitalizedTypeName, capitalizedTypeName, "",  "ListSharedVariable.cs", typeNamespace);
			*/
			if(!batch)
				AssetDatabase.Refresh();
		}

		public string[] GetNames(string namespacedTypeName, string capitalizedTypeName,
			TypeTemplate.NamingConventionEnum namingConvention)
		{
			switch (namingConvention)
			{
				case TypeTemplate.NamingConventionEnum.NamespacedCapitalized:
					return new []{namespacedTypeName, capitalizedTypeName};
				
				case TypeTemplate.NamingConventionEnum.NamespacedCapitalizedList:
					return new []{namespacedTypeName, capitalizedTypeName + "List"};
				
				case TypeTemplate.NamingConventionEnum.CapitalizedListCapitalized:
					return new []{capitalizedTypeName + "List", capitalizedTypeName};
				
				default:
					throw new ArgumentOutOfRangeException(nameof(namingConvention), namingConvention, null);
			}
		}
		/// <summary>
		/// Checks if type name contains a period and, if it does, derives (very stupidly) a namespace from the type name.
		/// </summary>
		/// <param name="typeName"></param>
		/// <param name="displayTypeName"></param>
		/// <param name="typeNamespace"></param>
		/// <returns></returns>
		private static bool DetectAndHandleNamespace(ref string typeName, ref string displayTypeName, ref string typeNamespace)
		{
			string fullTypeName = displayTypeName;

			if (typeName.Contains("."))
			{
				// Namespace = type name until last period
				typeNamespace = typeName.Substring(0, typeName.LastIndexOf(".")); 

				// Type names = type name AFTER last period
				displayTypeName = displayTypeName.Split('.').Last();
				typeName = typeName.Split('.').Last();

				if (_yesToAllNamespaceMessages) return true;
				
				// Inform user that we found a namespace and give them the option
				// Note that the IF here checks if the user clicks "Skip Type"
				var result = EditorUtility.DisplayDialogComplex(
					$"{fullTypeName} - Namespace Detected",
					$"Type name {fullTypeName} contains a period, so it's probably in a namespace.\n\nDo you want to insert the following namespace in the 'using' list of the generated file?\n\n{typeNamespace}",
					"OK",
					"Skip Type",
					"Yes to All");

				if (result == 0)
				{
					
				}
				else if(result == 1)
				{
					// User pressed "Skip Type", canceling generation of this type
					return false;
				}
				else if (result == 2)
				{
					_yesToAllNamespaceMessages = true;
				}
			}

			// All good, will not skip
			return true;
		}

		private void ValidatePath(string path)
		{
			if (!Directory.Exists(path))
				Directory.CreateDirectory(path);

			foreach (var file in new DirectoryInfo(path).GetFiles())
			{
				if (file.Extension.Contains("meta"))
				{
					continue;
				}

				file.Delete();
			}
		}

		private static void CreateScriptFile(string content, string path, string typeName, string name, string fileNamePrefix = "", string fileNamePostfix = "", string fileNamespace = null)
		{
			using (var fs = File.Create(path + fileNamePrefix + name + fileNamePostfix))
			{
				if (!string.IsNullOrEmpty(fileNamespace))
				{
					// \r added for CRLF endings (windows standard). The templates use this, so we would otherwise get warnings for inconsistent endings - Bjørnar
					content = content.Insert(0, $"using {fileNamespace};\r\n");
				}

				content = content.Replace("#TYPE#", typeName);
				content = content.Replace("#NAME#", name);

				// Normalize line endings
				content = content
					.Replace("\r\n", "\n")
					.Replace("\n\r", "\n")
					.Replace("\r", "\n")
					.Replace("\n", "\r\n");
				 
				var info = new UTF8Encoding(true).GetBytes(content);
				fs.Write(info, 0, info.Length);
			}
		}
		
		#region Templates
		/*
		public static readonly string variableTemplate =
@"using UnityEngine;

namespace Torstein.VariableSystem.Types
{
	[CreateAssetMenu(menuName = ""Scriptable Objects/Variable System/Global Variable/#NAME#"")]
	public class #NAME#Variable : GameVariable<#TYPE#>
	{
	}
}";

		public static readonly string instancedVariableTemplate =
@"using UnityEngine;

namespace Torstein.VariableSystem.Types
{
	[CreateAssetMenu(menuName = ""Scriptable Objects/Variable System/Instanced Variable/#NAME#"")]
	public class #NAME#VariableInstanced : InstancedVariable<#TYPE#>
	{
		protected override GameVariable<#TYPE#> GenerateVariableObject()
		{
			return CreateInstance<#NAME#Variable>();
		}
	}
}";

		public static readonly string listTemplate =
@"using UnityEngine;
using Torstein.VariableSystem.Types;

namespace Torstein.VariableSystem
{
	[CreateAssetMenu(menuName = ""Scriptable Objects/Variable System/Global List/#NAME#"")]
	public class #NAME#List : RuntimeSet<#TYPE#>
	{
	}
}";

		public static readonly string referenceTemplate =
@"using UnityEngine;
using Torstein.VariableSystem.Types;

namespace Torstein.VariableSystem
{
	[System.Serializable]
	public class #NAME#Reference : ValueReference<#TYPE#>
	{
		[SerializeField]
		private #NAME#Variable _globalVariable;
		[SerializeField]
		private #NAME#VariableInstanced _instancedVariable;

		public override #TYPE# Value
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

		// TODO: I wish these could be in base class ValueReference...
		public override void RegisterListener(IGameEventListener listener, object returnArgument)
		{
			if (ReferenceEquals(listener, null))
				return;

			switch (_assignmentType)
			{
				case AssignmentType.PersonalVariable:
					if (ReferenceEquals(_instancedVariable, null) || ReferenceEquals(IDToken, null))
						return;
					_instancedVariable.RegisterListener(IDToken, listener, returnArgument);
					break;

				case AssignmentType.GlobalVariable:
					if (ReferenceEquals(_globalVariable, null))
						return;
					_globalVariable.RegisterListener(listener, returnArgument);
					break;

				case AssignmentType.Constant:
				default:
					return;
			}
		}

		public override void UnregisterListener(IGameEventListener listener)
		{
			if (ReferenceEquals(listener, null))
				return;

			switch (_assignmentType)
			{
				case AssignmentType.PersonalVariable:
					if (ReferenceEquals(_instancedVariable, null) || ReferenceEquals(IDToken, null))
						return;
					_instancedVariable.UnregisterListener(IDToken, listener);
					break;

				case AssignmentType.GlobalVariable:
					if (ReferenceEquals(_globalVariable, null))
						return;
					_globalVariable.UnregisterListener(listener);
					break;

				case AssignmentType.Constant:
				default:
					return;
			}
		}
	}
}";

		public static readonly string referenceDrawerTemplate =
@"using UnityEditor;
using UnityEngine;

namespace Torstein.VariableSystem.Editor
{
	[CustomPropertyDrawer(typeof(#NAME#Reference))]
	public class #NAME#ReferenceDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			VariablesUtilities.OnGUI(position, property, label);
		}
	}
}";
		*/
		#endregion
	}
}

#endif