using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRangeSupporter : MonoBehaviour
{
    public GameObject goDotRange;
    //TODO OutLine���̴��׷����� ǥ��

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
