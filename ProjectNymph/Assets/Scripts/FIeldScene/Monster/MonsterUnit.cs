using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameType;

public class MonsterUnit : MonoBehaviour
{
    public MonsterStat stat;
    [SerializeField] private Animator anim;

    public E_MonsterState State { get; private set; }
    private List<MonsterRallyPoint> listRally = new List<MonsterRallyPoint>();
    private int currRallyIndex = 0;

    public void InitMonster(MonsterDB _db, MonsterRallyPoint[] _arrRally)
    {
        anim.SetBool("isWalk", true);
        anim.speed = 1f;

        stat = new MonsterStat();
        stat.maxHealthPoint = _db.health_point;
        stat.healthPoint = _db.health_point;
        stat.defensePoint = _db.defense_point;
        stat.moveSpeed = _db.move_speed;

        State = E_MonsterState.MOVE;
        currRallyIndex = 0;
        listRally.Clear();
        if (_arrRally != null)
        {
            for (int i = 0; i < _arrRally.Length; i++)
            {
                listRally.Add(_arrRally[i]);
            }
        }

        AdjustRallyPosition(true);
    }

    private void Update()
    {
        switch (State)
        {
            case E_MonsterState.IDLE: UpdateIdle(); break;
            case E_MonsterState.MOVE: UpdateMove(); break;
        }
    }

    private void UpdateIdle()
    {

    }

    private void UpdateMove()
    {
        if (stat == null)
            return;

        var currRally = CurrentRally();
        transform.Translate(currRally.direction * DB.Inst.Const.monSpeedFactor * stat.moveSpeed);

        if (Update_IsNextRallyArrived())
        {
            AddRallyIndex();
        }
    }

    public MonsterRallyPoint CurrentRally()
    {
        if (currRallyIndex < 0 || currRallyIndex >= listRally.Count)
            return null;

        return listRally[currRallyIndex];
    }

    public MonsterRallyPoint NextRally()
    {
        var nextRallyIndex = (currRallyIndex + 1) % listRally.Count;
        if (nextRallyIndex < 0)
            return null;

        return listRally[nextRallyIndex];
    }

    private void AddRallyIndex()
    {
        currRallyIndex++;
        if (currRallyIndex >= listRally.Count)
        {
            currRallyIndex = 0;
        }
        AdjustRallyPosition();
    }

    private bool Update_IsNextRallyArrived()
    {
        var currRally = CurrentRally();
        var nextRally = NextRally();
        var dir = currRally.direction;
        var pos = transform.position;
        if (dir.x < 0)
        {
            if (nextRally.transform.position.x > pos.x)
                return true;
            else
                return false;
        }
        else if (dir.x > 0)
        {
            if (nextRally.transform.position.x < pos.x)
                return true;
            else
                return false;
        }
        else if (dir.y < 0)
        {
            if (nextRally.transform.position.y > pos.y)
                return true;
            else
                return false;
        }
        else if (dir.y > 0)
        {
            if (nextRally.transform.position.y < pos.y)
                return true;
            else
                return false;
        }

        return false;
    }

    private void AdjustRallyPosition(bool _rotationOnly = false)
    {
        var currRally = CurrentRally();

        if (_rotationOnly == false)
            transform.position = currRally.transform.position;

        if (currRally.direction.x < 0)
            transform.localScale = new Vector3(-1f, 1f, 1f);
        else if (currRally.direction.x > 0)
            transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
