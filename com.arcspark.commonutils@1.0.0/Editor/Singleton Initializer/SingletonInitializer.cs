using UnityEditor;

namespace Arcspark.Editor
{
    public class SingletonInitializer
    {
        [InitializeOnLoadMethod]
        private static void SingletonInit()
        {
            AssetDatabase.ImportPackage(PackagePath() + "/Package Resources/Singleton T4 Source Code.unitypackage", false);
        }

        private static string PackagePath()
        {
            if (!string.IsNullOrEmpty(packagePath))
                return packagePath;

            packagePath = FolderUtil.GetPackageFullPath("com.arcspark.commonutils");
            return packagePath;
        }

        private static string packagePath;
    }
}