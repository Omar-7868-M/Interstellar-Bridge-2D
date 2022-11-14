using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 3f;
    public Rigidbody2D rb;    
    public bool isTouchingGround;
    public float jumpPower = 10f;
    private Vector3 moveDirection = Vector3.zero;

       
    // Start is called before the first frame update
    void Start()
    {    
        AudioManager.instance.Play("Carbon");       
        
    }
    
    void FixedUpdate()
    {
        transform.Translate(Vector2.left * (Time.deltaTime * playerSpeed)); //player move left
        if (Input.GetMouseButtonDown (0) && isTouchingGround)//Jump only when touching ground
        {
            
            rb.velocity = Vector2.up * jumpPower;
            AudioManager.instance.Play("Jump");//When jump play this sound
            rb.gravityScale = 1;//Gravity

        }  
        if (Input.GetKey(KeyCode.Space) && isTouchingGround)//Jump only when touching ground
        {
            
            rb.velocity = Vector2.up * jumpPower;
            AudioManager.instance.Play("Jump");//When jump play this sound
            rb.gravityScale = 1;//Gravity

        }         
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "Ground")
        {
            isTouchingGround = true;//Collsiion for ground = true then jump is performed
            
        }
         if(collision.transform.tag == "Enemy")
        {
           
            gameObject.SetActive(false);

            
        }
        
        
    }
    private void OnCollisionStay2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "Ground")
        {
            isTouchingGround = true;
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "Ground")
        {
            isTouchingGround = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("BV"))
        {
            Destroy(other.gameObject);
        }
                
        
    }
    
    
    
}

    
