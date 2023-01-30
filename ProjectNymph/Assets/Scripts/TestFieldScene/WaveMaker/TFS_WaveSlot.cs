using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TFS_WaveSlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txt;

    private WaveDB db;
    private Action<WaveDB> onClickSlot = null;
    public void SetSlot(WaveDB _db, Action<WaveDB> _onClickSlot)
    {
        this.db = _db;
        this.onClickSlot = _onClickSlot;
        txt.text = _db.id;
    }

    public void OnClickSlot()
    {
        if (onClickSlot != null)
        {
            onClickSlot(db);
        }
    }
}
