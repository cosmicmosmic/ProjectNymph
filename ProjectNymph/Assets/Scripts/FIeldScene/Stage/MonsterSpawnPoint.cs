using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnPoint : MonoBehaviour
{
    public MonsterRallyPoint[] rallyPoints;

    private static int indexSpawn = 0;
    public MonsterUnit SpawnMonster(string _id, Transform _parent)
    {
        var db = DB.Inst.GetMonsterDB(_id);

        var unit = Instantiate(Resources.Load<MonsterUnit>(GetMonsterDir(db.res_id)), _parent);
        unit.transform.position = transform.position;
        unit.InitMonster(db, rallyPoints, indexSpawn);
        indexSpawn += 2;
        return unit;
    }

    private string GetMonsterDir(string _resId)
    {
        return string.Concat("MonsterUnits/", _resId);
    }
}
