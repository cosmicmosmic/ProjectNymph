using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class TowerStat
{
    public long attackPoint;
    public float attackDelay;
    public float range;
}

[Serializable]
public class AttackStat
{
    public long attackPoint;
    public float bulletSpeed;
}