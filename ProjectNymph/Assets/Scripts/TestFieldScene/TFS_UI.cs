using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TFS_UI : MonoBehaviour
{
    public GameObject goBottomButtons;
    public TFS_TowerMaker towerMaker;
    public TileActionButton tileActionButton;

    public void InitUI()
    {
        towerMaker.InitMaker();
        towerMaker.gameObject.SetActive(false);
        goBottomButtons.SetActive(true);
        tileActionButton.Close();
    }

    public void Test_OnClickStart()
    {
        TestFieldScene.Inst.stageMgr.SetStage("1");
        TestFieldScene.Inst.stageMgr.StartWave(0);
    }

    public void OnClickOpenTowerMaker()
    {
        towerMaker.gameObject.SetActive(true);
        goBottomButtons.SetActive(false);
    }

    public void OnClickCloseTowerMaker()
    {
        towerMaker.gameObject.SetActive(false);
        goBottomButtons.SetActive(true);
    }
}
