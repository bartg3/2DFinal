using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject maincharacter;

    

    void Update()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
           
            maincharacter.GetComponent<Animator>().Play("RunAnimation");
            Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 1.0f, 1.0f);
            transform.position = transform.position + horizontal * Time.deltaTime;
           
        }


        if (Input.GetButtonDown("Vertical"))
        {
            maincharacter.GetComponent<Animator>().Play("JumpAnimation");
        }

    }

}
