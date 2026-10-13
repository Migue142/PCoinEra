using UnityEditor;
using UnityEngine;
using System.IO;

public static class ImportTMPResources
{
    [MenuItem("Tools/Import TMP Resources")]
    public static void Import()
    {
        string cache = Path.GetFullPath(
            Path.Combine(Application.dataPath,
            "..", "Library", "PackageCache"));

        foreach (string dir in Directory.GetDirectories(cache))
        {
            string file = Path.Combine(
                dir, "Package Resources",
                "TMP Essential Resources.unitypackage");

            if (File.Exists(file))
            {
                AssetDatabase.ImportPackage(file, false);
                Debug.Log("Importación de TMP iniciada: " + file);
                return;
            }
        }

        Debug.LogError(
            "No se encontró TMP Essential Resources.unitypackage");
    }
}
