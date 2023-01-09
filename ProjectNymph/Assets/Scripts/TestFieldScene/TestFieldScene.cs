using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFieldScene : GameObjectSingleton<TestFieldScene>
{
    public FieldGenerator fieldGen;
    public StageManager stageMgr;
    public TowerDropper towerDropper;
    public TFS_UI ui;

    protected override void Awake()
    {
        base.Awake();
        Application.targetFrameRate = 60;
        DB.Inst.Init();

        fieldGen.GenerateField();
        ui.InitUI();
    }
}
