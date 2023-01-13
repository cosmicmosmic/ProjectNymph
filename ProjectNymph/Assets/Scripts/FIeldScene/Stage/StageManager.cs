using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MonsterSpawnInfo
{
    public int pointId;
    public string monsterId;
    public int spawnCount;
    public float spawnDelay;

    public MonsterSpawnInfo(string _rawData)
    {
        var split = _rawData.Split(":".ToCharArray(), System.StringSplitOptions.RemoveEmptyEntries);
        if (split.Length == 4)
        {
            pointId = int.Parse(split[0]);
            monsterId = split[1];
            spawnCount = int.Parse(split[2]);
            spawnDelay = float.Parse(split[3]);
        }
        else if (split.Length == 3)
        {
            pointId = int.Parse(split[0]);
            monsterId = split[1];
            spawnCount = int.Parse(split[2]);
            spawnDelay = DB.Inst.Const.spawnDelay;
        }
        else
        {
            Debug.LogError("라운드 DB 몬스터 정보 오류 " + _rawData);
            pointId = 1;
            monsterId = string.Empty;
            spawnCount = 0;
            spawnDelay = DB.Inst.Const.spawnDelay;
        }
    }
}

public class StageManager : MonoBehaviour
{
    [SerializeField] private Transform trMonsterSpawnRoot;
    public MonsterSpawnPoint[] spawnPoints;

#if UNITY_EDITOR
    [ReadOnly]
#endif
    public int waveIndex;
    private WaveDB currWaveDB;
    private StageDB currStageDB;

    public void SetStage(string _stageId)
    {
        var db = DB.Inst.GetStageDB(_stageId);
        if (db == null)
            return;

        currStageDB = db;
    }

    public void ResetWave()
    {
        waveIndex = 0;
        currWaveDB = GetWaveDB();
        StartCurrWave();
    }

    public void NextWave()
    {
        waveIndex++;
        currWaveDB = GetWaveDB();
        StartCurrWave();
    }

    public void StartWave(int _round)
    {
        waveIndex = _round;
        currWaveDB = GetWaveDB();
        StartCurrWave();
    }

    private WaveDB GetWaveDB()
    {
        if (currStageDB == null)
            return null;

        if (currStageDB.waveList.Length <= waveIndex || waveIndex < 0)
            return null;

        return DB.Inst.GetWaveDB(currStageDB.waveList[waveIndex]);
    }

    private void StartCurrWave()
    {
        if (currWaveDB == null)
            return;

        var monsters = currWaveDB.monsters;
        for (int i = 0; i < monsters.Length; i++)
        {
            StartCoroutine(CorSpawnMonsters(monsters[i]));
        }
    }

    private IEnumerator CorSpawnMonsters(string _monsters)
    {
        yield return null;
        var info = new MonsterSpawnInfo(_monsters);
        var wait = new WaitForSeconds(info.spawnDelay);
        var spawnPoint = spawnPoints[info.pointId - 1];
        for (int i = 0; i < info.spawnCount; i++)
        {
            spawnPoint.SpawnMonster(info.monsterId, trMonsterSpawnRoot);
            yield return wait;
        }
    }
}
