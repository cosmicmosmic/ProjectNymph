using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FieldTile : MonoBehaviour
{
    [SerializeField] private GameObject goHighlight;
    [SerializeField] private GameObject goSelected;

    public Action<FieldTile> onClickEmptyTile;
    public Action<FieldTile> onClickTowerTile;
    public Action<FieldTile> onClickBlockTile;

    public TowerUnit Tower { get; private set; }
    public Block Block { get; private set; }

    public void Refresh()
    {
        goHighlight.SetActive(false);
        goSelected.SetActive(false);
    }

    public void SpawnTower()
    {

    }

    public void RemoveTower()
    {
        if (Tower == null)
            return;

        Destroy(Tower.gameObject);
        Tower = null;

        Refresh();
    }

    public bool DropTower(TowerUnit _tower)
    {
        if (_tower == null)
            return false;

        if (Tower != null)
            return false;

        _tower.transform.SetParent(this.transform);
        _tower.transform.localPosition = Vector3.zero;
        Tower = _tower;
        Tower.HideRange();
        return true;
    }

    public void SelectTile(bool _value)
    {
        goSelected.SetActive(_value);
    }

    private void OnMouseDown()
    {
        if (Tower != null)
        {
            onClickTowerTile?.Invoke(this);
        }
        else if (Block != null)
        {
            onClickBlockTile?.Invoke(this);
        }
        else
        {
            onClickEmptyTile?.Invoke(this);
        }
    }

    private void OnMouseEnter()
    {
        if (goHighlight != null)
            goHighlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        if (goHighlight != null)
            goHighlight.SetActive(false);
    }
}
