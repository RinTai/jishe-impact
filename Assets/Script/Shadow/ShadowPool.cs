using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPool : MonoBehaviour
{
    public static ShadowPool instance;//��������ɵ���

    public GameObject shadowPrefab;//������Ϸ������,������е�Ԥ����

    public int shadowCount;//���ٸ���Ӱ

    private Queue<GameObject> availableObjects = new Queue<GameObject>();
    void Awake()
    {
        instance = this;

        //��ʼ�������
        FillPool();
    }
    void Update()
    {
        
    }
    public void FillPool()//�������
    {
        for(int i = 0; i < shadowCount; i++)
        {
            var newShadow = Instantiate(shadowPrefab);//��ʱ��������ÿһ�����ɵ�Ԥ���嶼��ShadowPool��Ϊ������
            newShadow.transform.SetParent(transform);

            //ȡ�����ã����ض����
            ReturnPool(newShadow);
        }
    }

    public void ReturnPool(GameObject gameObject)
    {
        gameObject.SetActive(false);//ȡ������GameObject

        availableObjects.Enqueue(gameObject);//�����β���Ԫ��
    }

    public GameObject GetFormPool() 
    {
        if (availableObjects.Count == 0)//���գ�����������CountΪ0���ٴν������
        {
            FillPool();
        }

        var outShadow = availableObjects.Dequeue();//�Ӷ��������ѡ��һ�����岢��������ʾ����
        outShadow.SetActive(true);//����

        return outShadow;//������ʱ����
    }
}
