using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MonsterHpSupporter : MonoBehaviour
{
    public TextMeshPro txtHp;

    public void SetHp(long _value)
    {
        txtHp.text = _value.ToString();
    }
}
