using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private float lifetimer;
    void Start()
    {
        Destroy(gameObject,lifetimer);
    }
}
