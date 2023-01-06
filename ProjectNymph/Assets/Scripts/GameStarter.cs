using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private FieldScene fieldScene;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        DB.Inst.Init();
        fieldScene.StartScene();
    }
}
