using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class AttackBody : MonoBehaviour
{
#if UNITY_EDITOR
    [ReadOnly]
#endif
    public AttackStat stat;
    public Tween tween;
#if UNITY_EDITOR
    [ReadOnly]
#endif
    public GameObject prefab;

    public bool isVaild = false;//유효할때만 히트판정(이미 히트한 바디는 재사용 불가)
    public bool isSeek = false;
    public Transform trTarget;

    public const string TAG_MONSTER = "Monster";

    public void InitBody()
    {
        if (tween != null)
        {
            tween.OnComplete(DespawnBody);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isVaild == false)
            return;

        if (collision.tag == TAG_MONSTER)
        {
            if (isSeek)
            {
                if (collision.transform != trTarget)
                    return;
            }

            var mon = collision.gameObject.GetComponent<MonsterUnit>();
            if (mon != null)
            {
                HitMonster(mon);
            }
        }
    }

    private void Update()
    {
        if (isSeek)
        {
            Update_SeekTarget();
        }
    }

    private void Update_SeekTarget()
    {
        if (trTarget == null)
            return;

        var dir = trTarget.position - transform.position;
        dir = Vector3.Normalize(dir);
        var delta = dir * stat.bulletSpeed * Time.deltaTime;

        var pos = transform.position;
        pos += delta;
        transform.position = pos;
    }

    private void HitMonster(MonsterUnit _mon)
    {
        isVaild = false;
        isSeek = false;
        Calc.Damage(stat, _mon);

        if (tween != null)
        {
            tween.Kill(true);
            tween = null;
        }
        else
        {
            DespawnBody();
        }
    }

    private void DespawnBody()
    {
        ObjectPool.Inst.Despawn(prefab, gameObject);
    }
}
