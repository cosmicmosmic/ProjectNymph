using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TileActionButton : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private RectTransform root;
    [SerializeField] private RectTransform parent;

    private FieldTile currTile = null;

    public Action onClose = null;

    private void Awake()
    {
        parent = GetComponent<RectTransform>();
    }

    public void ShowButton(FieldTile _tile)
    {
        gameObject.SetActive(true);

        var pos = cam.WorldToViewportPoint(_tile.transform.position);
        pos.x *= parent.rect.width;
        pos.y *= parent.rect.height;

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

        if (onClose != null)
        {
            onClose();
        }

        gameObject.SetActive(false);
    }
}
