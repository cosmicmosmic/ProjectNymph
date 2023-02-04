using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TFS_TowerDropper : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private TowerUnit towerGrabbed = null;

    public bool IsGrabbed()
    {
        return towerGrabbed;
    }

    public void SpawnTower(TowerDB _db)
    {
        if (towerGrabbed != null)
            return;

        towerGrabbed = TowerInstancer.Inst.InstantiateTower(_db);
        towerGrabbed.transform.SetParent(transform);
        towerGrabbed.transform.localPosition = Vector3.zero;
        if (towerGrabbed != null)
        {
            towerGrabbed.ShowRange();
        }
    }

    public void DropTower(FieldTile _tile)
    {
        if (towerGrabbed == null)
            return;

        if (_tile.DropTower(towerGrabbed))
        {
            towerGrabbed.StartWork();
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
