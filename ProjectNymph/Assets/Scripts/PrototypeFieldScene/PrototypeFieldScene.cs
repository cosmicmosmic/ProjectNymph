using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PrototypeFieldScene : MonoBehaviour
{
    public Pt_UI ui;

    private List<FieldTile> listFieldTiles;

    public Action<int> onChangeGold = null;
    public int Gold
    {
        get
        {
            return gold;
        }
        set
        {
            gold = value;
            if (onChangeGold != null)
            {
                onChangeGold(gold);
            }
        }
    }
    private int gold = 0;
    private int round = 0;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        DB.Inst.Init();

        listFieldTiles = FM.Inst.fieldGen.GenerateField();
        ui.Init();

        SpawnRandomTower();
        Gold = 0;
        ui.startTimer.StartTimer(StartWave);
        ui.startTimer.gameObject.SetActive(true);
        FM.Inst.stageMgr.SetStage("1");
    }

    private void SpawnRandomTower()
    {
        if (listFieldTiles == null)
            return;

        var rnd = UnityEngine.Random.Range(0, listFieldTiles.Count);
        var tile = listFieldTiles[rnd];

        tile.SpawnRandomTower();
    }

    private void StartWave()
    {
        var isNext = FM.Inst.stageMgr.NextWave();
        if (isNext == false)
        {

        }
    }
}
