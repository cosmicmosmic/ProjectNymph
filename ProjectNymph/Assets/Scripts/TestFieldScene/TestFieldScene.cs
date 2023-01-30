using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TestFieldScene : GameObjectSingleton<TestFieldScene>
{
    public TFS_TowerDropper towerDropper;
    public TFS_UI ui;

    private List<FieldTile> listFieldTiles;

    protected override void Awake()
    {
        base.Awake();
        Application.targetFrameRate = 60;
        DB.Inst.Init();

        listFieldTiles = FM.Inst.fieldGen.GenerateField();
        SetOnClickFieldEmptyTile(towerDropper.DropTower);

        SetOnClickFieldTowerTile((tile) =>
        {
            if (towerDropper.IsGrabbed())
                return;

            HideAllRanges();
            ui.tileActionButton.ShowButton(tile);
        });

        ui.tileActionButton.onClose = HideAllRanges;
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

    public void HideAllRanges()
    {
        for (int i = 0; i < listFieldTiles.Count; i++)
        {
            var tile = listFieldTiles[i];
            if (tile.Tower != null)
            {
                tile.Tower.HideRange();
            }
        }
    }

    public void ClearAllTowers()
    {
        for (int i = 0; i < listFieldTiles.Count; i++)
        {
            var tile = listFieldTiles[i];
            if (tile.Tower != null)
            {
                tile.RemoveTower();
            }
        }
    }
}
