using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ScriptableDBEditor : Editor
{
    [MenuItem("Util/Create/DB")]
    public static void CreateDB()
    {
        AssetUtil.CreateScriptableObject<DBIndex>();
    }

    [MenuItem("Util/Create/Const")]
    public static void CreateConst()
    {
        AssetUtil.CreateScriptableObject<DBConst>();
    }
}
