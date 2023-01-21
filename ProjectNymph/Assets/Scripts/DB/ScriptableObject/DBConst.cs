using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBConst : ScriptableObject
{
    [Header("����Ʈ ��")]
    public float monSpeedFactor = 0.1f;
    public float spawnDelay = 1f;

    [Header("��Ʈ���� ��")]
    public int sOrderRangedTower = 30;
    public int sOrderTower = 20;
}
