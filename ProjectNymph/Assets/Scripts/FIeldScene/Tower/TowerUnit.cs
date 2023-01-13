using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUnit : MonoBehaviour
{
    public TowerStat stat;
    [SerializeField] private TowerRangeViewer rangeView;
    [SerializeField] private Animator anim;

    public void InitTower(TowerDB _db)
    {
        anim.SetBool("isWalk", false);
        anim.speed = 1f;

        stat = new TowerStat();
        stat.attackPoint = _db.attackPoint;
        stat.attackDelay = _db.attackDelay;
        stat.range = _db.range;

        rangeView = GetComponent<TowerRangeViewer>();
        if (rangeView == null)
        {
            rangeView = Instantiate(Resources.Load<TowerRangeViewer>("TowerUnits/Etc/RangeView"), transform);
        }
        rangeView.transform.localPosition = Vector3.zero;
        rangeView.HideRange();
    }

    public void ShowRange()
    {
        rangeView.ShowRange(stat.range);
    }

    public void HideRange()
    {
        rangeView.HideRange();
    }
}
