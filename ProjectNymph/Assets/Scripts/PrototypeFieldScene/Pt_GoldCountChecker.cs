using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pt_GoldCountChecker : MonoBehaviour
{
    [SerializeField] private PrototypeFieldScene ptScene;
    [SerializeField] TextMeshProUGUI txt;

    public void Init()
    {
        ptScene.onChangeGold = OnChangeGold;
    }

    private void OnChangeGold(int _value)
    {
        txt.text = _value.ToString();
    }
}
