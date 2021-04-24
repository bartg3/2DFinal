using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;
    float horizontalMove = 0f;

    bool jump = false; 

    public GameObject bullet;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));



        if (Input.GetButton("Vertical"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }


         if(Input.GetKeyDown(KeyCode.Space))
       {
           GameObject b = (GameObject)(Instantiate(bullet, transform.position + transform.up*.1f, Quaternion.identity));

           b.GetComponent<Rigidbody2D>().AddForce(transform.right * 1000);
       }

    
    }

    public void OnLanding ()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate ()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;

    }



}
