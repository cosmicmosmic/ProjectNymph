using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBConst : ScriptableObject
{
    [Header("디폴트 값")]
    public float monSpeedFactor = 0.1f;
    public float spawnDelay = 1f;

    [Header("소트오더 값")]
    public int sOrderRangedTower = 30;
    public int sOrderTower = 20;
}
