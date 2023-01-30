using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TFS_WaveMaker : MonoBehaviour
{
    [SerializeField] private TFS_WaveSlot slot;
    [SerializeField] private Transform trSlot;
    private List<TFS_WaveSlot> listSlots = new List<TFS_WaveSlot>();

    public void InitMaker()
    {
        listSlots.Clear();

        var slotCount = DB.Inst.dicWaveDB.Count;

        while (trSlot.childCount < slotCount)
        {
            Instantiate(slot, trSlot);
        }

        int index = 0;
        foreach (var pair in DB.Inst.dicWaveDB)
        {
            var db = pair.Value;
            var slot = trSlot.GetChild(index).GetComponent<TFS_WaveSlot>();
            slot.SetSlot(db, OnClickSlot);

            listSlots.Add(slot);
            index++;
        }
    }

    private void OnClickSlot(WaveDB _db)
    {
        FM.Inst.stageMgr.StartWave(_db);
    }
}
