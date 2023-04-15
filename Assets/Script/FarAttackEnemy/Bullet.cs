using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    //����Ϊ�ӵ����ʱ��
    private float lifeTimer;//�ӵ����ʱ��
    [SerializeField] private float maxLife = 2.0f;//�����ʱ��
    //����Ϊ�����ӵ�����
    [SerializeField] private Transform target;
    [SerializeField] private float moveSpeed;//�ӵ������ٶ�
    //����Ϊ�ӵ���Ч
    public GameObject destroyEffect;//�ӵ����ٵ���Ч
    public GameObject attackEffect;//��������ҵ���Ч

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();//��ȡ���λ��
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);//�������

        lifeTimer += Time.deltaTime;//��ʱ
        if (lifeTimer >= maxLife )
        {
            Instantiate(destroyEffect,transform.position,transform.rotation);//������Ч
            Destroy(gameObject);//�����ӵ�
        }
    }
    //private void OnCollsionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.tag == "Player")
    //    {
    //        Instantiate(attackEffect, transform.position, Quaternion.identity);//���ɹ�����Ч
    //        Debug.Log("Attack");
    //        Destroy(gameObject);//������Ч
    //    }
    //}
}
