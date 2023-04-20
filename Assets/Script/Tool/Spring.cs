using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    Vector2 Direction;
    bool isok = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
      
    }
    // Update is called once per frame
    void Update()
    {
            Direction = (this.transform.parent.transform.position - this.transform.position).normalized;
            Debug.Log(Direction);
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            collision.rigidbody.AddForce(new Vector2(20f,0), ForceMode2D.Impulse) ;
        }
    }
}
