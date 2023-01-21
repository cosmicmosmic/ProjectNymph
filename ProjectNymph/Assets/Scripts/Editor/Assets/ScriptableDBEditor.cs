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

    [MenuItem("Util/Create/AttackEffect")]
    public static void CreateAttackEffect()
    {
        AssetUtil.CreateScriptableObject<AttackEffect>();
    }

    [MenuItem("Util/Create/DefaultRes")]
    public static void CreateDefaultRes()
    {
        AssetUtil.CreateScriptableObject<DefaultResource>();
    }
}
