using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Pt_StartTimerButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtTimer;

    private float timeNextWave;
    private bool isTimerOn = false;

    public Action onClickStart;

    private void Update()
    {
        if (isTimerOn)
        {
            timeNextWave -= Time.deltaTime;
            txtTimer.text = timeNextWave.ToString("n0");
            if (timeNextWave < 0f)
            {
                isTimerOn = false;
                OnClickStart();
            }
        }
    }

    public void StartTimer(Action _onClickStart)
    {
        this.onClickStart = _onClickStart;
        timeNextWave = 15f;
        isTimerOn = true;
    }

    public void OnClickStart()
    {
        if (onClickStart != null)
        {
            gameObject.SetActive(false);
            isTimerOn = false;
            onClickStart();
            onClickStart = null;
        }
    }
}
