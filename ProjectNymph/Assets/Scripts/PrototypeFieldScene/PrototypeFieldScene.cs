using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeFieldScene : MonoBehaviour
{
    public Pt_UI ui;

    private List<FieldTile> listFieldTiles;

    private int gold = 0;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        DB.Inst.Init();

        listFieldTiles = FM.Inst.fieldGen.GenerateField();

        SpawnRandomTower();
    }

    private void SpawnRandomTower()
    {
        if (listFieldTiles == null)
            return;

        var rnd = Random.Range(0, listFieldTiles.Count);
        var tile = listFieldTiles[rnd];

        tile.SpawnRandomTower();
    }
}
