using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDropper : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private TowerUnit towerGrabbed = null;

    public void SpawnTower(TowerDB _db)
    {
        if (towerGrabbed != null)
            return;

        towerGrabbed = Instantiate(Resources.Load<TowerUnit>(GetTowerDir(_db.resId)), transform);
        if (towerGrabbed != null)
        {
            towerGrabbed.InitTower(_db);
            towerGrabbed.ShowRange();
        }
    }

    public void DropTower(FieldTile _tile)
    {
        if (towerGrabbed == null)
            return;

        if (_tile.DropTower(towerGrabbed))
        {
            towerGrabbed = null;
        }
    }

    public void RemoveGrabbed()
    {
        if (towerGrabbed == null)
            return;

        Destroy(towerGrabbed.gameObject);
        towerGrabbed = null;
    }

    private string GetTowerDir(string _resId)
    {
        return string.Concat("TowerUnits/", _resId);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RemoveGrabbed();
            return;
        }

        if (towerGrabbed != null)
        {
            var pos = cam.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0f;
            towerGrabbed.transform.position = pos;
        }
    }
}
