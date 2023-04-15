using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSprite : MonoBehaviour
{
    private Transform player;//��λ��ҵ�λ��

    private SpriteRenderer thisSprite;//��ǰλ��Sprite
    private SpriteRenderer playerSprite;//��ҵ�Sprite

    private Color color;//��ɫ����

    [Header("ʱ����Ʋ���")]
    public float activeTime;//��ʾʱ��
    public float activeStart;//��ʼ��ʱ���

    [Header("��͸���ȿ���")]
    private float alpha;//������ʾʱ����ȱ仯�ı���
    public float alphaSet;//��ʼ��͸����
    public float alphaMultiplier;//�仯������

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        thisSprite = GetComponent<SpriteRenderer>();
        playerSprite = player.GetComponent<SpriteRenderer>();

        alpha = alphaSet;
        thisSprite.sprite = playerSprite.sprite;

        transform.position = player.position;
        transform.rotation = player.rotation;
        transform.localScale = player.localScale;

        activeStart = Time.time;
    }

    void Update()
    {
        alpha *= alphaMultiplier;

        color = new Color(0.2157f,0.65f,1,alpha);//��ɫ
        thisSprite.color = color;//��ֵ

        if(Time.time >= activeStart + activeTime)
        {
            //���ض����
            ShadowPool.instance.ReturnPool(this.gameObject);//���ö����
        }
    }
}
