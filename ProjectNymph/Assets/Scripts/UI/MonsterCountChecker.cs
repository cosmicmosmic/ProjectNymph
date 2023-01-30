using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MonsterCountChecker : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txt;

    private List<MonsterUnit> listMon;
    private int beforeCnt = -999;

    private void Awake()
    {
        listMon = FM.Inst.stageMgr.listMon;

        UpdateCount();
    }

    private void Update()
    {
        UpdateCount();
    }

    private void UpdateCount()
    {
        if (listMon == null)
            return;

        if (beforeCnt == listMon.Count)
            return;

        beforeCnt = listMon.Count;
        txt.text = beforeCnt.ToString();
    }
}
