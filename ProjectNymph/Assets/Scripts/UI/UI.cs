using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : GameObjectSingleton<UI>
{
    public void Test_OnClickStart()
    {
        FieldScene.Inst.stageMgr.SetStage("1");
        FieldScene.Inst.stageMgr.StartWave(0);
    }
}
