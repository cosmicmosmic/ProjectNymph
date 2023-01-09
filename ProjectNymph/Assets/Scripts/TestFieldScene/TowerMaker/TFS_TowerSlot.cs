using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TFS_TowerSlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txt;

    private TowerDB db;
    private Action<TowerDB> onClickSlot = null;
    public void SetSlot(TowerDB _db, Action<TowerDB> _onClickSlot)
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
