using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    [SerializeField] private float speed;
    void Update()
    {
        var rot = transform.localRotation.eulerAngles;
        rot.z += speed;
        transform.localRotation = Quaternion.Euler(rot);
    }
}
