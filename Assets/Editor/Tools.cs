using UnityEditor;

public class Tools : Editor
{
    [MenuItem("Tools/Reserialize all assets")]
    public static void ReserializeAllAssets()
    {
        AssetDatabase.ForceReserializeAssets();
    }
}