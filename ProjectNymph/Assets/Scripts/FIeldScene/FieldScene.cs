using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldScene : GameObjectSingleton<FieldScene>
{
    public FieldGenerator fieldGen;
    public StageManager stageMgr;

    public void StartScene()
    {
        fieldGen.GenerateField();
    }
}
