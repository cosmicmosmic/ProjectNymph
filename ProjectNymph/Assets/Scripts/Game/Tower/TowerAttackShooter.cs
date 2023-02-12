using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameType;
using DG.Tweening;

public class TowerAttack
{
    public E_AttackType attackType;
    public virtual void Fire(TowerAttackShooter _shooter, MonsterUnit _target)
    {
        //Do Nothing
    }
}

public class BulletAttack : TowerAttack
{
    public override void Fire(TowerAttackShooter _shooter, MonsterUnit _target)
    {
        var towerStat = _shooter.towerStat;
        var attackDB = _shooter.attackDB;
        var skin = _shooter.skin;

        var prefab = skin.Bullet();
        var goBullet = ObjectPool.Inst.Spawn(prefab, FM.Inst.trAttackLayer);
        goBullet.transform.position = _shooter.transform.position;
        var body = goBullet.GetComponent<AttackBody>();
        var stat = new AttackStat();
        stat.attackPoint = towerStat.attackPoint + attackDB.attack_point;
        stat.bulletSpeed = attackDB.bullet_speed;

        body.isVaild = true;
        body.stat = stat;
        body.prefab = prefab;

        var dir = _target.transform.position - _shooter.transform.position;
        dir = Vector3.Normalize(dir);
        var targetPos = dir * 10 + _shooter.transform.position;
        var dist = Vector2.Distance(_shooter.transform.position, targetPos);
        var duration = dist / attackDB.bullet_speed;
        body.tween = goBullet.transform.DOMove(targetPos, duration);

        body.InitBody();
    }
}

public class SeekAttack : TowerAttack
{
    public override void Fire(TowerAttackShooter _shooter, MonsterUnit _target)
    {
        var towerStat = _shooter.towerStat;
        var attackDB = _shooter.attackDB;
        var skin = _shooter.skin;

        var prefab = skin.Bullet();
        var goBullet = ObjectPool.Inst.Spawn(prefab, FM.Inst.trAttackLayer);
        goBullet.transform.position = _shooter.transform.position;
        var body = goBullet.GetComponent<AttackBody>();
        var stat = new AttackStat();
        stat.attackPoint = towerStat.attackPoint + attackDB.attack_point;
        stat.bulletSpeed = attackDB.bullet_speed;

        body.isVaild = true;
        body.stat = stat;
        body.prefab = prefab;
        body.isSeek = true;
        body.target = _target;

        body.InitBody();
    }
}

public class BombAttack : TowerAttack
{
    public override void Fire(TowerAttackShooter _shooter, MonsterUnit _target)
    {

    }
}

public class LaserAttack : TowerAttack
{
    public override void Fire(TowerAttackShooter _shooter, MonsterUnit _target)
    {

    }
}

public class TowerAttackShooter : MonoBehaviour
{
    public TowerStat towerStat;
    public AttackDB attackDB;
    public AttackSkin skin;
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
        this.towerStat = _stat;
        this.attackDB = DB.Inst.GetAttackDB(_attackId);
        skin = Resources.Load<AttackSkin>(string.Concat("AttackSkin/", attackDB.res_id));

        switch (attackDB.attack_type)
        {
            //case E_AttackType.BULLET:
            //    attack = new BulletAttack();
            //    break;
            case E_AttackType.SEEK:
                attack = new SeekAttack();
                break;
            case E_AttackType.BOMB:
                attack = new BombAttack();
                break;
            case E_AttackType.LASER:
                attack = new LaserAttack();
                break;
        }
    }

    public void Fire(MonsterUnit _target)
    {
        if (attack == null)
        {
            return;
        }
        attack.Fire(this, _target);
    }
}
