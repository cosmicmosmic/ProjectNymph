using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameType;

public class Util
{
    public static bool IsVaildMonster(MonsterUnit _mon)
    {
        if (_mon == null || _mon.gameObject.activeSelf == false || _mon.State != E_MonsterState.MOVE)
            return false;

        return true;
    }
}
