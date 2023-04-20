using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMent : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;
    Vector2 PlayerInput;
    float LinearDrag=40f;
    float targetSpeed=20f;
    float acceleration=50f;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput=Getinput();
    }
    private void FixedUpdate()
    {
         
        
    }
    private Vector2 Getinput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    void ApplyLinerDrag()
    {
        if(Mathf.Abs(PlayerInput.x)<0.4f)
        {
            m_Rigidbody.drag = LinearDrag;
        }
        else
        {
            m_Rigidbody.drag = 0f;
        }
    }
    void MoveMet()
    {
        m_Rigidbody.AddForce(new Vector2(PlayerInput.x, 0) * acceleration);
        if (Mathf.Abs(m_Rigidbody.velocity.x) > targetSpeed)
        {
            m_Rigidbody.velocity = new Vector2(Mathf.Sign(m_Rigidbody.velocity.x) * targetSpeed, m_Rigidbody.velocity.y);
        }
        ApplyLinerDrag();
    }
}
