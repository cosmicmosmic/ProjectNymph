using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnPoint : MonoBehaviour
{
    public int id;
    public MonsterRallyPoint[] rallyPoints;

    public MonsterUnit SpawnMonster(string _id, Transform _parent)
    {
        var db = DB.Inst.GetMonsterDB(_id);

        var unit = Instantiate(Resources.Load<MonsterUnit>(GetMonsterDir(db.resId)), _parent);
        unit.transform.position = transform.position;
        unit.InitMonster(db, rallyPoints);
        return unit;
    }

    private string GetMonsterDir(string _resId)
    {
        return string.Concat("MonsterUnits/", _resId);
    }
}
