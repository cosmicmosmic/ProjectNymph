using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TFS_TowerMaker : MonoBehaviour
{
    [SerializeField] private TFS_TowerSlot slot;
    [SerializeField] private Transform trSlot;
    private List<TFS_TowerSlot> listSlots = new List<TFS_TowerSlot>();

    public void InitMaker()
    {
        listSlots.Clear();

        var slotCount = DB.Inst.dicTowerDB.Count;

        while (trSlot.childCount < slotCount)
        {
            Instantiate(slot, trSlot);
        }

        int index = 0;
        foreach (var pair in DB.Inst.dicTowerDB)
        {
            var db = pair.Value;
            var slot = trSlot.GetChild(index).GetComponent<TFS_TowerSlot>();
            slot.SetSlot(db, OnClickSlot);

            listSlots.Add(slot);
            index++;
        }
    }

    private void OnClickSlot(TowerDB _db)
    {
        TestFieldScene.Inst.towerDropper.SpawnTower(_db);
    }
}
