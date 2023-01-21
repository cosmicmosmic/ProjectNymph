using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRangeSupporter : MonoBehaviour
{
    public GameObject goDotRange;
    //TODO OutLine섀이더그래프로 표현

    public void ShowRange(bool _show)
    {
        if (_show)
        {
            goDotRange.SetActive(true);
        }
        else
        {
            goDotRange.SetActive(false);
        }
    }
}
