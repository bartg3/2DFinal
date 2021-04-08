using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerControl : MonoBehaviour
{
   public float speed;
   public float jumpForce;
   private float moveInput;

   private Rigidbody2D rb;

   private bool facingRight = true;

   private bool isGrounded;
   public Transform groundCheck;
   public float checkRadius;
   public LayerMask whatIsGround;

   private int extraJumps;
   public int extraJumpsValue;

   public GameObject bullet;

   void Start()
   {
       extraJumps = extraJumpsValue;
       rb = GetComponent<Rigidbody2D>();
   }

   void FixedUpdate ()
   {
       isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

       moveInput = Input.GetAxis("Horizontal");
       rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

       if(facingRight == false && moveInput > 0) 
       {
           Flip();
       }

       else if(facingRight == true && moveInput < 0)
       {
           Flip();
       }
   }

   void Update()
   {
       if(isGrounded == true)
       {
           extraJumps = extraJumpsValue;
       }
       if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
       {
           rb.velocity = Vector2.up * jumpForce;
           extraJumps--;
       }
       else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
       {
          rb.velocity = Vector2.up * jumpForce; 
       }
       if(Input.GetKeyDown(KeyCode.Space))
       {
           GameObject b = (GameObject)(Instantiate(bullet, transform.position + transform.up*.1f, Quaternion.identity));

           b.GetComponent<Rigidbody2D>().AddForce(transform.right * 1000);
       }
   }


   void Flip()
   {
       facingRight = !facingRight;
       Vector3 Scaler = transform.localScale;
       Scaler.x *= -1;
       transform.localScale = Scaler; 
   }
    
}
