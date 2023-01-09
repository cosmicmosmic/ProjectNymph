using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUnit : MonoBehaviour
{
    public TowerStat stat;
    [SerializeField] private LineRenderer lineRange;
    [SerializeField] private Animator anim;

    public void InitTower(TowerDB _db)
    {
        anim.SetBool("isWalk", false);
        anim.speed = 1f;

        stat = new TowerStat();
        stat.attackPoint = _db.attackPoint;
        stat.attackDelay = _db.attackDelay;
        stat.range = _db.range;

        lineRange.gameObject.SetActive(false);
    }

    [ContextMenu("Show Range")]
    public void ShowRange()
    {
        if (lineRange == null)
            return;

        lineRange.gameObject.SetActive(true);

        var steps = 50;
        var radius = stat.range;

        lineRange.positionCount = steps;
        for (int i = 0; i < steps; i++)
        {
            float progress = (float)i / steps;
            float currRad = progress * 2 * Mathf.PI;

            float xScaled = Mathf.Cos(currRad);
            float yScaled = Mathf.Sin(currRad);

            float x = xScaled * radius;
            float y = yScaled * radius;

            Vector3 currPos = new Vector3(x, y, 0f);

            lineRange.SetPosition(i, currPos);
        }
    }
}
