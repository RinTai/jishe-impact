using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotate : MonoBehaviour
{
    public float speed;//��ת�ٶ�
    void Update()
    {
        transform.Rotate(Vector2.up * speed);
    }
}
