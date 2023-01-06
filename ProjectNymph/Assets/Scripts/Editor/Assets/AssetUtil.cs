using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AssetUtil
{
    public static void CreateScriptableObject<T>()
        where T : ScriptableObject
    {
        var asset = ScriptableObject.CreateInstance<T>();
        var path = AssetDatabase.GetAssetPath(Selection.activeObject);
        if(path.Contains("."))
        {
            path = path.Remove(path.LastIndexOf('/'));
        }
        var assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(
            string.Concat(path, "/New", typeof(T).ToString(), ".asset"));

        AssetDatabase.CreateAsset(asset, assetPathAndName);
        Selection.activeObject = asset;
        EditorUtility.FocusProjectWindow();
        AssetDatabase.SaveAssets();
    }

}
