using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldScene : GameObjectSingleton<FieldScene>
{
    public void StartScene()
    {
        FM.Inst.fieldGen.GenerateField();
    }
}
