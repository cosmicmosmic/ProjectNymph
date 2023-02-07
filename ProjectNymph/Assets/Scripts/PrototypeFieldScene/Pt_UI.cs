using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pt_UI : MonoBehaviour
{
    public TileActionButton tileActionButton;
    public Pt_GoldCountChecker goldChecker;
    public Pt_StartTimerButton startTimer;


    public void Init()
    {
        goldChecker.Init();
    }
}
