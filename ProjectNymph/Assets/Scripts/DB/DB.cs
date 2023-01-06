using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class MonsterDB
{
    public string id;
    public string resId;
    public long healthPoint;
    public long defensePoint;
    public float moveSpeed;
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
    public string[] waveList;
}

public class DB : Singleton<DB>
{
    public DBConst Const;
    private DBIndex index;
    public Dictionary<string, MonsterDB> dicMonDB = new Dictionary<string, MonsterDB>();
    public Dictionary<string, StageDB> dicStageDB = new Dictionary<string, StageDB>();
    public Dictionary<string, WaveDB> dicWaveDB = new Dictionary<string, WaveDB>();


    public void Init()
    {
        Const = Resources.Load<DBConst>("DB/DBConst");
        index = Resources.Load<DBIndex>("DB/DBIndex");
        LoadMonsterDB();
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
