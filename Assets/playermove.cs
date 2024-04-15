using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playermove : MonoBehaviour
{ 
public float maxSpeed;
public float jumppower;
    bool isJumping;
    Rigidbody2D rigid;
void Awake()
{
    rigid = GetComponent<Rigidbody2D>();
    isJumping = false;
 }
void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
     if (rigid.velocity.x > maxSpeed) // right max speed
      {
           rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
      }
      else if (rigid.velocity.x < maxSpeed * (-1))// left max speed
     {
         rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
     }

    }
    void Update()
    {
        //Jump
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            isJumping = true;
            rigid.AddForce(Vector2.up * jumppower, ForceMode2D.Impulse);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        { //tag가 Floor인 오브젝트와 충돌했을 때
            isJumping = false; //isJumping을 다시 false로
        }
    }
}
