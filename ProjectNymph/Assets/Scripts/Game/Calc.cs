using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Calc
{
    public static void Damage(AttackStat _attack, MonsterUnit _mon)
    {
        var defender = _mon.stat;
        var dmg = _attack.attackPoint;

        dmg -= defender.defensePoint;
        dmg = Math.Max(0, dmg);

        _mon.SetHealthPoint(-dmg);
    }
}
