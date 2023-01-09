using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDropper : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private TowerUnit towerGrabbed = null;

    public void SpawnTower(TowerDB _db)
    {
        towerGrabbed = Instantiate(Resources.Load<TowerUnit>(GetTowerDir(_db.resId)), transform);
    }

    private string GetTowerDir(string _resId)
    {
        return string.Concat("TowerUnits/", _resId);
    }

    private void Update()
    {
        if (towerGrabbed != null)
        {
            var pos = cam.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0f;
            towerGrabbed.transform.position = pos;
        }
    }
}
