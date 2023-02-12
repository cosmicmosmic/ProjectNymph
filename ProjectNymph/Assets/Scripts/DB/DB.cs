using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UGS;
using GoogleSheet;
using System;

public class DB : Singleton<DB>
{
    public DBConst Const;
    public DefaultResource Res;

    public MonsterDB[] arrMonDB;
    public TowerDB[] arrTowerDB;
    public AttackDB[] arrAttackDB;
    public StageDB[] arrStageDB;
    public WaveDB[] arrWaveDB;

    public Dictionary<string, MonsterDB> dicMonDB = new Dictionary<string, MonsterDB>();
    public Dictionary<string, TowerDB> dicTowerDB = new Dictionary<string, TowerDB>();
    public Dictionary<string, AttackDB> dicAttackDB = new Dictionary<string, AttackDB>();
    public Dictionary<string, StageDB> dicStageDB = new Dictionary<string, StageDB>();
    public Dictionary<string, WaveDB> dicWaveDB = new Dictionary<string, WaveDB>();

    public void Init()
    {
        Const = Resources.Load<DBConst>("DB/DBConst");
        Res = Resources.Load<DefaultResource>("DefaultResource");

        LoadLocalDB();
    }

    public void LoadLocalDB()
    {
        UnityGoogleSheet.LoadAllData();
        LoadMonsterDB(ModifyBaseDB<MonsterDB, SheetData.MonsterDB>(SheetData.MonsterDB.GetList()));
        LoadTowerDB(ModifyBaseDB<TowerDB, SheetData.TowerDB>(SheetData.TowerDB.GetList()));
        LoadAttackDB(ModifyBaseDB<AttackDB, SheetData.AttackDB>(SheetData.AttackDB.GetList()));
        LoadStageDB(ModifyBaseDB<StageDB, SheetData.StageDB>(SheetData.StageDB.GetList()));
        LoadWaveDB(ModifyBaseDB<WaveDB, SheetData.WaveDB>(SheetData.WaveDB.GetList()));
    }

    public void LoadGoogleSheetDBAll()
    {
        LoadSheetDB<MonsterDB, SheetData.MonsterDB>(LoadMonsterDB);
        LoadSheetDB<TowerDB, SheetData.TowerDB>(LoadTowerDB);
        LoadSheetDB<AttackDB, SheetData.AttackDB>(LoadAttackDB);
        LoadSheetDB<StageDB, SheetData.StageDB>(LoadStageDB);
        LoadSheetDB<WaveDB, SheetData.WaveDB>(LoadWaveDB);
    }

    public T[] ModifyBaseDB<T, U>(List<U> _list) where U : ITable where T : BaseDB, new()
    {
        var list = _list;
        if (list != null)
        {
            var arr = new T[list.Count];
            for (int i = 0; i < arr.Length; i++)
            {
                var db = new T();
                db.OverwriteSheetDB(list[i]);
                arr[i] = db;
            }

            return arr;
        }
        else
        {
            return null;
        }
    }

    public void LoadSheetDB<T, U>(Action<T[]> _onCompleteLoad) where U : ITable where T : BaseDB, new()
    {
        UnityGoogleSheet.LoadFromGoogle<string, U>((list, map) =>
        {
            if (list != null)
            {
                var arr = new T[list.Count];
                for (int i = 0; i < arr.Length; i++)
                {
                    var db = new T();
                    db.OverwriteSheetDB(list[i]);
                    arr[i] = db;
                }

                if (_onCompleteLoad != null)
                {
                    _onCompleteLoad(arr);
                    Debug.Log("구글시트 로드 : " + typeof(T));
                }
            }

        }, true);
    }

    private void LoadMonsterDB(MonsterDB[] _arr)
    {
        dicMonDB.Clear();
        var monsters = _arr;
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

        arrMonDB = _arr;
        if (DBLoader.Inst != null) DBLoader.Inst.monsterDB = _arr;
    }

    private void LoadTowerDB(TowerDB[] _arr)
    {
        dicTowerDB.Clear();
        var towers = _arr;
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
            }
        }

        arrTowerDB = _arr;
        if (DBLoader.Inst != null) DBLoader.Inst.towerDB = _arr;
    }

    private void LoadAttackDB(AttackDB[] _arr)
    {
        dicAttackDB.Clear();
        var attacks = _arr;
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

        arrAttackDB = _arr;
        if (DBLoader.Inst != null) DBLoader.Inst.attackDB = _arr;
    }

    private void LoadStageDB(StageDB[] _arr)
    {
        dicStageDB.Clear();
        var stages = _arr;
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

        arrStageDB = _arr;
        if (DBLoader.Inst != null) DBLoader.Inst.stageDB = _arr;
    }

    private void LoadWaveDB(WaveDB[] _arr)
    {
        dicWaveDB.Clear();
        var waves = _arr;
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

        arrWaveDB = _arr;
        if (DBLoader.Inst != null) DBLoader.Inst.waveDB = _arr;
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
        var len = arrTowerDB.Length;
        var rnd = UnityEngine.Random.Range(0, len);
        return arrTowerDB[rnd];
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
