using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSkin : ScriptableObject
{
    [SerializeField] private GameObject prefabShoot;
    [SerializeField] private GameObject prefabBullet;
    [SerializeField] private GameObject prefabHit;

    public GameObject Bullet()
    {
        if (prefabBullet == null)
        {
            return DB.Inst.Res.prefabDefaultBullet;
        }
        else
        {
            return prefabBullet;
        }
    }
}
