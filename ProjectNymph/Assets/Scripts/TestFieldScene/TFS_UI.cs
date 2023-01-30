using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TFS_UI : MonoBehaviour
{
    public TFS_TowerMaker towerMaker;
    public TFS_WaveMaker waveMaker;
    public TileActionButton tileActionButton;


    public void InitUI()
    {
        towerMaker.InitMaker();
        waveMaker.InitMaker();
        tileActionButton.Close();
    }

    public void OnClickResetAll()
    {
        FM.Inst.stageMgr.ClearWave();
        TestFieldScene.Inst.ClearAllTowers();
    }

    public void OnClickResetTower()
    {
        TestFieldScene.Inst.ClearAllTowers();
    }

    public void OnClickResetWave()
    {
        FM.Inst.stageMgr.ClearWave();
    }
}
