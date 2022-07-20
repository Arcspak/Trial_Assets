using UnityEditor;

namespace Arcspark.Editor
{
    public class FileInitializer
    {
		[MenuItem("Window/File Util/Import File Util Examples")]
		private static void ImportExamplesContentMenu()
		{
            AssetDatabase.ImportPackage(PackagePath() + "/Package Resources/File Util Sample.unitypackage", true);
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