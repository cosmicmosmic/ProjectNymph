using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimationEventHandler : MonoBehaviour
{
    public Action onCompleteDie = null;

    public void OnCompleteDie()
    {
        if (onCompleteDie != null)
        {
            onCompleteDie();
        }
    }
}
