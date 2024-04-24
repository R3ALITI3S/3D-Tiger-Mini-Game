using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Vector3 movement;
    [SerializeField] Animator animator;
    public float speedDTTranslate = 5f;
    public float speedDTRotate = 50f;
    public Rigidbody rb; // got the variable through the inspector in Unity.
    private bool canJump = true; //for the jumps

    // Update is called once per frame
    void Update()
    {
        //this was made for getting the imputs for the characters movement into the animator :))
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");

        // Acually used;
        animator.SetFloat("Speed", movement.magnitude);


        //this is for the movement, this refers to the current instance of the script, 
        //and Vector3.forward 'translates' the object on its forward axis, with the speed determined by 'speedDTTanslate'
        //and 'Time.deltaTime' makes the movement frame-rate independent, the speed is specified by the 'speedDTTranslate' variable.
         
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.forward*speedDTTranslate*Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector3.back*speedDTTranslate*Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.right*speedDTTranslate*Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector3.left*speedDTTranslate* Time.deltaTime);
        }

            /*  Another possible way to do it, but then it will rotate the character instead 
            if (Input.GetKey(KeyCode.W))
            {
                this.transform.Rotate(Vector3.up, speedDTRotate* Time.deltaTime);
            }
            */


        //this ensures that no double jump is possible
        if (canJump && Input.GetKeyDown("space"))
        {
            Jump();
        }
    }

    void Jump() // the jump void with data
    {
        rb.velocity=new Vector3(rb.velocity.x, 7f, rb.velocity.z);
        canJump = false;
    }

    void OnCollisionEnter (Collision collision) // treats the 
    {
        // checks if it is possible to jump
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Enemy"))
        {
            canJump = true;
        }

        //For killing enemies
        if (collision.gameObject.CompareTag("EnemyHead"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }

    /* This is already as a component on the gameobject, soooo.. un nececary..

    void FixedUpdate() // function for physics-related tasks, called at fixed intervals - consistency for physics sims across devices and framerates.
    {
        // Makes the rigidbody move - while the movement is consistent with Time.
       rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    */
}    
