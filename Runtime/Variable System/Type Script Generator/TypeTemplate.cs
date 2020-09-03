using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Torstein.VariableSystem
{
    [CreateAssetMenu(menuName = "Type Template")]
    public class TypeTemplate : ScriptableObject
    {
        public enum NamingConventionEnum
        {
            NamespacedCapitalized,
            NamespacedCapitalizedList,
            CapitalizedListCapitalized,
        }

        public enum PathConventionEnum
        {
            TypeFolder,
            Editor
        }

        [FormerlySerializedAs("_templateFile")] 
        public TextAsset templateFile;

        [FormerlySerializedAs("_pathConvention")] 
        public PathConventionEnum pathConvention = PathConventionEnum.TypeFolder;
        [FormerlySerializedAs("_namingConvention")] 
        public NamingConventionEnum namingConvention = NamingConventionEnum.NamespacedCapitalized;

        [FormerlySerializedAs("FileNamePrefix")] 
        public string fileNamePrefix;
        [FormerlySerializedAs("FileNamePostFix")] 
        public string fileNamePostFix = ".cs";

        [Button("Auto Name")]
        public void AutoName()
        {
            if (!templateFile)
                return;

            var templateRemoved = templateFile.name.Replace("Template", "");
            fileNamePostFix = templateRemoved + ".cs";
        }
    }
}