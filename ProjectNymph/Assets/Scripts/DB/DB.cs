using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameType;
using System;

[Serializable]
public class MonsterDB
{
    public string id;
    public string res_id;
    public long health_point;
    public long defense_point;
    public float move_speed;
}

[Serializable]
public class TowerDB
{
    public string id;
    public string res_id;
    public string attack_id;

    public long attack_point;//공격력
    public float attack_delay;//딜레이
    public float range;//사거리
}

[Serializable]
public class AttackDB
{
    public string id;
    public string res_id;

    public E_AttackType attack_type;

    public long attack_point;
    public float bullet_speed;

}

[Serializable]
public class WaveDB
{
    public string id;
    public string[] monsters;
}

[Serializable]
public class StageDB
{
    public string id;
    public string[] wave_list;
}

public class DB : Singleton<DB>
{
    public DBConst Const;
    public DefaultResource Res;
    private DBIndex index;
    public Dictionary<string, MonsterDB> dicMonDB = new Dictionary<string, MonsterDB>();
    public Dictionary<string, TowerDB> dicTowerDB = new Dictionary<string, TowerDB>();
    public Dictionary<string, AttackDB> dicAttackDB = new Dictionary<string, AttackDB>();
    public Dictionary<string, StageDB> dicStageDB = new Dictionary<string, StageDB>();
    public Dictionary<string, WaveDB> dicWaveDB = new Dictionary<string, WaveDB>();

    private List<TowerDB> listTowerDB = new List<TowerDB>();

    public void Init()
    {
        Const = Resources.Load<DBConst>("DB/DBConst");
        Res = Resources.Load<DefaultResource>("DefaultResource");
        index = Resources.Load<DBIndex>("DB/DBIndex");
        LoadMonsterDB();
        LoadTowerDB();
        LoadAttackDB();
        LoadStageDB();
        LoadWaveDB();
    }

    private void LoadMonsterDB()
    {
        dicMonDB.Clear();
        var monsters = index.monsterDB;
        for (int i = 0; i < monsters.Length; i++)
        {
            var db = monsters[i];
            if (dicMonDB.ContainsKey(db.id))
            {
                Debug.LogWarning("이미 존재하는 몬스터 ID : " + db.id);
            }
            else
            {
                dicMonDB.Add(db.id, db);
            }
        }
    }

    private void LoadTowerDB()
    {
        dicTowerDB.Clear();
        listTowerDB.Clear();
        var towers = index.towerDB;
        for (int i = 0; i < towers.Length; i++)
        {
            var db = towers[i];
            if (dicTowerDB.ContainsKey(db.id))
            {
                Debug.LogWarning("이미 존재하는 타워 ID : " + db.id);
            }
            else
            {
                dicTowerDB.Add(db.id, db);
                listTowerDB.Add(db);
            }
        }
    }

    private void LoadAttackDB()
    {
        dicAttackDB.Clear();
        var attacks = index.attackDB;
        for (int i = 0; i < attacks.Length; i++)
        {
            var db = attacks[i];
            if (dicAttackDB.ContainsKey(db.id))
            {
                Debug.LogWarning("이미 존재하는 공격 ID : " + db.id);
            }
            else
            {
                dicAttackDB.Add(db.id, db);
            }
        }
    }

    private void LoadStageDB()
    {
        dicStageDB.Clear();
        var stages = index.stageDB;
        for (int i = 0; i < stages.Length; i++)
        {
            var db = stages[i];
            if (dicStageDB.ContainsKey(db.id))
            {
                Debug.LogWarning("이미 존재하는 스테이지 : " + db.id);
            }
            else
            {
                dicStageDB.Add(db.id, db);
            }
        }
    }

    private void LoadWaveDB()
    {
        dicWaveDB.Clear();
        var waves = index.waveDB;
        for (int i = 0; i < waves.Length; i++)
        {
            var db = waves[i];
            if (dicWaveDB.ContainsKey(db.id))
            {
                Debug.LogWarning("이미 존재하는 웨이브 : " + db.id);
            }
            else
            {
                dicWaveDB.Add(db.id, db);
            }
        }
    }

    public MonsterDB GetMonsterDB(string _id)
    {
        if (dicMonDB.ContainsKey(_id))
        {
            return dicMonDB[_id];
        }
        else
        {
            return null;
        }
    }

    public TowerDB GetTowerDB(string _id)
    {
        if (dicTowerDB.ContainsKey(_id))
        {
            return dicTowerDB[_id];
        }
        else
        {
            return null;
        }
    }

    public TowerDB GetRandomTowerDB()
    {
        var cnt = listTowerDB.Count;
        var rnd = UnityEngine.Random.Range(0, cnt);
        return listTowerDB[rnd];
    }

    public AttackDB GetAttackDB(string _id)
    {
        if (dicAttackDB.ContainsKey(_id))
        {
            return dicAttackDB[_id];
        }
        else
        {
            return null;
        }
    }

    public StageDB GetStageDB(string _id)
    {
        if (dicStageDB.ContainsKey(_id))
        {
            return dicStageDB[_id];
        }
        else
        {
            return null;
        }
    }

    public WaveDB GetWaveDB(string _id)
    {
        if (dicWaveDB.ContainsKey(_id))
        {
            return dicWaveDB[_id];
        }
        else
        {
            return null;
        }
    }
}
