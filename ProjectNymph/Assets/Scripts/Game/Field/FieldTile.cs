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

    private string defaultName;
    public void SetDefaultName(string _name)
    {
        defaultName = _name;
        gameObject.name = _name;
    }
    private void RefreshName()
    {
#if UNITY_EDITOR
        if (defaultName == null)
            return;

        string name = defaultName;

        if (Tower != null)
        {
            name = string.Concat(name, " (T)");
        }
        if (Block != null)
        {
            name = string.Concat(name, " (B)");
        }
        gameObject.name = name;
#endif
    }

    public void Refresh()
    {
        goHighlight.SetActive(false);
        goSelected.SetActive(false);
        RefreshName();

        if (Tower != null) Tower.HideRange();
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
        Refresh();
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
