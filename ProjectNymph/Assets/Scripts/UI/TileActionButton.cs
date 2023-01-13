using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileActionButton : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private RectTransform root;
    [SerializeField] private float width = 900f;
    [SerializeField] private float height = 1850f;

    private FieldTile currTile = null;

    public void ShowButton(FieldTile _tile)
    {
        gameObject.SetActive(true);

        var pos = cam.WorldToViewportPoint(_tile.transform.position);
        pos.x *= width;
        pos.y *= height;

        root.anchoredPosition = pos;

        if (_tile.Tower != null)
            _tile.Tower.ShowRange();

        currTile = _tile;
    }

    public void OnClickRemoveTower()
    {
        if (currTile == null)
            return;

        currTile.RemoveTower();
        Close();
    }

    public void Close()
    {
        if (currTile != null && currTile.Tower != null)
        {
            currTile.Tower.HideRange();
        }
        currTile = null;
        gameObject.SetActive(false);
    }
}
