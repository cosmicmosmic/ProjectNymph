using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameType;

public class TowerAttack
{
    public E_AttackType attackType;
    public virtual void Fire(TowerAttackShooter _shooter, Transform _target)
    {

    }
}

public class BulletAttack : TowerAttack
{
    public override void Fire(TowerAttackShooter _shooter, Transform _target)
    {

    }
}

public class BombAttack : TowerAttack
{
    public override void Fire(TowerAttackShooter _shooter, Transform _target)
    {

    }
}

public class LaserAttack : TowerAttack
{
    public override void Fire(TowerAttackShooter _shooter, Transform _target)
    {

    }
}

public class TowerAttackShooter : MonoBehaviour
{
    private TowerStat stat;
    private AttackDB db;
    private AttackEffect effect;
    private TowerAttack attack;

    public E_AttackType AttackType
    {
        get
        {
            if (attack == null)
            {
                return E_AttackType.NONE;
            }
            return attack.attackType;
        }
    }

    public void InitShooter(TowerStat _stat, string _attackId)
    {
        this.stat = _stat;
        this.db = DB.Inst.GetAttackDB(_attackId);
        effect = Resources.Load<AttackEffect>(string.Concat("AttackEffect/", db.res_id));

        switch (db.attack_type)
        {
            case E_AttackType.BULLET:
                attack = new BulletAttack();
                break;
            case E_AttackType.BOMB:
                attack = new BombAttack();
                break;
            case E_AttackType.LASER:
                attack = new LaserAttack();
                break;
        }
    }

    public void Fire(Transform _target)
    {
        if (attack == null)
        {
            return;
        }
        attack.Fire(this, _target);
    }
}
