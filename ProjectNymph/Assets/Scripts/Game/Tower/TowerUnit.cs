using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameType;

public class TowerUnit : MonoBehaviour
{
    public TowerStat stat;
    [SerializeField] private TowerAttackShooter shooter;
    [SerializeField] private Animator anim;

    public E_TowerState State { get; private set; }
    private TowerRangeSupporter rangeSupport;
    private SpriteRenderer spr;

    private float currDelayTime = 0f;
    private MonsterUnit followingTarget = null;

    public void InitTower(TowerDB _db)
    {
        gameObject.name = _db.id;
        spr = anim.GetComponent<SpriteRenderer>();

        anim.SetBool("isWalk", false);
        anim.speed = 1f;

        stat = new TowerStat();
        stat.attackPoint = _db.attack_point;
        stat.attackDelay = _db.attack_delay;
        stat.range = _db.range;

        rangeSupport = GetComponent<TowerRangeSupporter>();
        if (rangeSupport == null)
        {
            rangeSupport = Instantiate(DB.Inst.Res.prefabRangeSupporter, transform);
        }
        rangeSupport.transform.localPosition = Vector3.zero;
        rangeSupport.HideRange();

        shooter = GetComponentInChildren<TowerAttackShooter>();
        if (shooter == null)
        {
            shooter = gameObject.AddComponent<TowerAttackShooter>();
        }
        shooter.InitShooter(stat, _db.attack_id);

        State = E_TowerState.IDLE;
    }

    public void StartWork()
    {
        State = E_TowerState.WORK;
    }

    private void Update()
    {
        if (State == E_TowerState.IDLE)
            return;

        Update_FindAndShoot();
    }

    private void Update_FindAndShoot()
    {
        currDelayTime -= Time.deltaTime;
        if (currDelayTime > 0f)
            return;

        currDelayTime -= Time.deltaTime;

        MonsterUnit target;
        if (followingTarget != null && IsRangedTarget(followingTarget))
        {
            target = followingTarget;
        }
        else
        {
            target = FindNearestTarget();
            followingTarget = target;
        }

        if (target != null)
        {
            shooter.Fire(target);
            currDelayTime = stat.attackDelay;
        }
    }

    private bool IsRangedTarget(MonsterUnit _mon)
    {
        if (Util.IsVaildMonster(_mon) == false)
            return false;

        var range = stat.range;
        var dist = Vector2.Distance(transform.position, _mon.transform.position);
        if (dist <= range)
            return true;
        else
            return false;
    }

    private MonsterUnit FindNearestTarget()
    {
        var range = stat.range;
        var list = FM.Inst.stageMgr.listMon;
        float nearestDist = 99999f;
        MonsterUnit nearestMon = null;
        for (int i = 0; i < list.Count; i++)
        {
            var mon = list[i];
            if (Util.IsVaildMonster(mon) == false)
                continue;

            var dist = Vector2.Distance(transform.position, mon.transform.position);
            if (dist <= range && dist < nearestDist)
            {
                nearestDist = dist;
                nearestMon = mon;
            }
        }

        return nearestMon;
    }

    public void ShowRange()
    {
        rangeSupport.ShowRange(stat.range);
        var order = DB.Inst.Const.sOrderRangedTower;
        spr.sortingOrder = order;
        rangeSupport.SetSortingOrder(order - 1);
    }

    public void HideRange()
    {
        rangeSupport.HideRange();
        var order = DB.Inst.Const.sOrderTower;
        spr.sortingOrder = order;
        rangeSupport.SetSortingOrder(order - 1);
    }

#if UNITY_EDITOR

    [ContextMenu("Find Target")]
    public void DebugFindTarget()
    {
        var mon = FindNearestTarget();
        if (mon == null)
        {
            Debug.Log("사거리내에 타겟없음");
        }
        else
        {
            Debug.Log(mon.name + ", " + Vector2.Distance(transform.position, mon.transform.position));
        }
    }
#endif
}
