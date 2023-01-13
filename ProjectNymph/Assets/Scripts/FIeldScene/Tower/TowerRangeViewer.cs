using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRangeViewer : MonoBehaviour
{
    [SerializeField] private LineRenderer line;
    [SerializeField] private SpriteRenderer spr;

    public void ShowRange(float _range)
    {
        gameObject.SetActive(true);

        //line
        var steps = 50;
        var radius = _range;

        line.positionCount = steps;
        for (int i = 0; i < steps; i++)
        {
            float progress = (float)i / steps;
            float currRad = progress * 2 * Mathf.PI;

            float xScaled = Mathf.Cos(currRad);
            float yScaled = Mathf.Sin(currRad);

            float x = xScaled * radius;
            float y = yScaled * radius;

            Vector3 currPos = new Vector3(x, y, 0f);

            line.SetPosition(i, currPos);
        }

        //sprite
        var scale = _range * 2f;
        spr.transform.localScale = Vector3.one * scale;
    }

    public void HideRange()
    {
        gameObject.SetActive(false);
    }
}
