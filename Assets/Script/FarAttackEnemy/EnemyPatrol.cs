using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    private Rigidbody2D rb_FarAttackEnemy;
    //����Ϊ��޷�Χ����
    [SerializeField] private float attackRange;//��޷�Χ   
    private Transform target;//���λ��
    //����ΪѲ�߲���
    public Transform wayPoint01;//Ѳ�߹̶���
    public Transform wayPoint02;
    private Transform wayPointTarget;//��ǰѲ��Ŀ��
    [SerializeField] private float speed;//Ѳ���ٶ�
    //����Ϊ�����ӵ�����
    public GameObject bullet;
    public Transform shotPlace;
    //����Ϊ��ʱ��
    public float timer;
    public float HP;

    void Start()
    {
        rb_FarAttackEnemy = GetComponent<Rigidbody2D>();
        wayPointTarget = wayPoint01;//��ʼ������
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();//�ҵ���ҵ�λ��

    }
    void Update()
    {
        rb_FarAttackEnemy.velocity += Vector2.down * 9.8f * Time.deltaTime;//ʩ������
        timer += Time.deltaTime;//��ʱ

        if (Vector2.Distance(target.position, transform.position) > attackRange)
        {
            Patrol();//Ѳ��
        }
        else
        {
            Shot();//���
        }
    }

    void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPointTarget.position, speed * Time.deltaTime);//����Ŀ���Ѳ���ƶ�

        if (Vector2.Distance(transform.position, wayPoint01.position) < 0.5f)//�жϾ���
        {
            Vector3 localTemp = transform.localScale;
            localTemp.x *= -1;
            transform.localScale = localTemp;//ͼƬ��ת
            wayPointTarget = wayPoint02;//�л�Ѳ�߶���
        }
        if (Vector2.Distance(transform.position, wayPoint02.position) < 0.5f)
        {
            Vector3 localTemp = transform.localScale;
            localTemp.x *= -1;
            transform.localScale = localTemp;
            wayPointTarget = wayPoint01;
        }
    }
    void Shot()
    {
        if(timer % 1.5 > 1&&timer %1.5 <1.01) 
        {
            Debug.Log("�����ӵ�");
            timer = 0;
            Instantiate(bullet, shotPlace.position, transform.rotation);//�����ӵ�������֡��120�������Ϊ����һ���ӵ���
        }       
    }
    private void OnCollisionEnter2D(Collision2D collision)//��ҵ��ܻ�
    {
        if(collision.gameObject.tag == "Hitbox")
        {
            this.GetComponentInChildren<HpControl>().hp -= 25; //Ѫ������
        }
    }
}
