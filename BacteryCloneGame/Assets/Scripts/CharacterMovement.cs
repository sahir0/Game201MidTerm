using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 20f;    
    public float force;
    
    public Rigidbody2D rb2D;

    bool grounded = true;


    void Start()
    {
        rb2D = this.GetComponent<Rigidbody2D>();
    }


    public void  OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="Ground" && grounded == false)
        {
            grounded = true;
        }
    }
    


    void Update()
    {

        Vector3 pos = transform.position;

        jump();

        if (Input.GetKey("s"))
        {
            pos.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
        }


        transform.position = pos;

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject(0);
            bullet.SetActive(true);
            bullet.gameObject.transform.position = this.gameObject.transform.position;
        }

    }
    void jump()
    {
        if (Input.GetKeyDown("space") && grounded)
        {
            rb2D.velocity += force * Vector2.up;

            grounded = false;
        }

    }
}