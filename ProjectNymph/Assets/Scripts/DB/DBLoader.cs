using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DBLoader : GameObjectSingleton<DBLoader>
{
    [Header("시작 시 구글시트 로드")]
    public bool loadGoogleSheetOnStart = false;

    public MonsterDB[] monsterDB;
    public TowerDB[] towerDB;
    public AttackDB[] attackDB;
    public StageDB[] stageDB;
    public WaveDB[] waveDB;

    private void Start()
    {
        RefreshDB();

        if (loadGoogleSheetOnStart)
        {
            LoadGoogleSheetDBAll();
        }
    }

    private void RefreshDB()
    {
        monsterDB = DB.Inst.arrMonDB;
        towerDB = DB.Inst.arrTowerDB;
        attackDB = DB.Inst.arrAttackDB;
        stageDB = DB.Inst.arrStageDB;
        waveDB = DB.Inst.arrWaveDB;
    }

    public void LoadGoogleSheetDBAll()
    {
        DB.Inst.LoadGoogleSheetDBAll();
    }
}
