using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameType
{
    public enum E_MonsterState
    {
        IDLE,
        MOVE
    }

    public enum E_TowerState
    {
        IDLE,
        WORK
    }

    public enum E_AttackType
    {
        //BULLET,//������������ �� ���ư�
        SEEK,//���� ����ٴϸ鼭 ������
        BOMB,
        LASER,
        NONE
    }
}