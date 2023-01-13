using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TestFieldScene : GameObjectSingleton<TestFieldScene>
{
    public FieldGenerator fieldGen;

    public StageManager stageMgr;
    public TowerDropper towerDropper;
    public TFS_UI ui;

    private List<FieldTile> listFieldTiles;

    protected override void Awake()
    {
        base.Awake();
        Application.targetFrameRate = 60;
        DB.Inst.Init();

        listFieldTiles = fieldGen.GenerateField();
        SetOnClickFieldEmptyTile(towerDropper.DropTower);
        SetOnClickFieldTowerTile(ui.tileActionButton.ShowButton);

        ui.InitUI();
    }

    public void SetOnClickFieldEmptyTile(Action<FieldTile> _onClickFieldTile)
    {
        if (listFieldTiles == null)
            return;

        for (int i = 0; i < listFieldTiles.Count; i++)
        {
            var tile = listFieldTiles[i];
            tile.onClickEmptyTile = _onClickFieldTile;
        }
    }

    public void SetOnClickFieldTowerTile(Action<FieldTile> _onClickFieldTile)
    {
        if (listFieldTiles == null)
            return;

        for (int i = 0; i < listFieldTiles.Count; i++)
        {
            var tile = listFieldTiles[i];
            tile.onClickTowerTile = _onClickFieldTile;
        }
    }
}
