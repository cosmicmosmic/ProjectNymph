using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldGenerator : MonoBehaviour
{
    [SerializeField] private UnitTile prefabTile;
    [SerializeField] private Vector2 startPos;
    [SerializeField] private Vector2 tileSize;

    [SerializeField] private Vector2Int gridSize;

    public List<UnitTile> GenerateField()
    {
        var x = gridSize.x;
        var y = gridSize.y;
        List<UnitTile> list = new List<UnitTile>();

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                var tile = GenerateTile(i * tileSize.x + startPos.x, j * -tileSize.y + startPos.y);
                list.Add(tile);
            }
        }

        return list;
    }

    public UnitTile GenerateTile(float _localPosX, float _localPosY)
    {
        var tile = Instantiate(prefabTile, transform);
        tile.transform.localPosition = new Vector2(_localPosX, _localPosY);
        return tile;
    }
}
