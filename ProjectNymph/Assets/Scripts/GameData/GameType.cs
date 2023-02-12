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
        //BULLET,//직선방향으로 쭉 나아감
        SEEK,//적을 따라다니면서 유도함
        BOMB,
        LASER,
        NONE
    }
}