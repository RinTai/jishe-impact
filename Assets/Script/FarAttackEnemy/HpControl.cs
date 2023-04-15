using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HpControl : MonoBehaviour
{
    public Image hpImage;//Ѫ��ͼƬ
    public Image hpEffectImage;//Ѫ�����ٻ�����ЧͼƬ
    public float hp;//��ǰѪ��
    [SerializeField]private float maxHp;//���Ѫ��
    [SerializeField]private float hurtSpeed = 0.05f;//Ѫ�����ٵ��ٶ�

    void Start()
    {
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        hpImage.fillAmount = hp / maxHp;//Ѫ������ʾ
        if (hpEffectImage.fillAmount >= hpImage.fillAmount)
        {
            hpEffectImage.fillAmount -= hurtSpeed;//����Ѫ��
        }
        else
        {
            hpEffectImage.fillAmount = hpImage.fillAmount;
        }
    }
}
