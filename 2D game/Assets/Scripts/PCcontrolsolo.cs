using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCcontrolsolo : MonoBehaviour {

    // Player Movement Variables
    public int MoveSpeed;
    public float Jumpheight;

    // Player grounded variables
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;
    private bool DoubleJump;
    //non-slip variable
    private float moveVelocity;

    public Animator Animator;

	// animating stuff
	void Start () {
        Animator.SetBool("isWalking", false);
        Animator.SetBool("isJumping", false);
	}
	
	
	void FixedUpdate () {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}

	// Update is called once per frame
	private void Update(){

            //this code makes the character jump
        if(Input.GetKeyDown(KeyCode.UpArrow) && grounded){
                Jump(); 
            }

        //double jump
        if (grounded)
            DoubleJump = false;

        if (Input.GetKeyDown(KeyCode.UpArrow) && !DoubleJump && !grounded){
            Jump();
            DoubleJump = true;
            Animator.SetBool("isJumping", false);
        }

        //non-slip player
        moveVelocity = 0f;

        //this is the drop command
        if (Input.GetKeyDown(KeyCode.DownArrow)){
            Drop();
            }

        // this is the A&D keys ror left and right.
        if(Input.GetKey (KeyCode.RightArrow)){
            //GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            //If you want to have a no-slip character, comment out the above line, and uncomment the below line.
            moveVelocity = MoveSpeed;
            Animator.SetBool("isWalking", true);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow)){
            Animator.SetBool("isWalking", false);
        }

        if(Input.GetKey (KeyCode.LeftArrow)){
            //GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            //If you want to have a no-slip character, comment out the above line, and uncomment the below line.
            moveVelocity = -MoveSpeed;
            Animator.SetBool("isWalking", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow)){
            Animator.SetBool("isWalking", false);
        }

        //comment this out when you turn off no-slip
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

        //player flip
        if (GetComponent<Rigidbody2D>().velocity.x > 0)
            transform.localScale = new Vector3(3.5f, 3f, 1f);

        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
            transform.localScale = new Vector3(-3.5f, 3f, 1f);

    }

    public void Jump(){
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, Jumpheight);
        Animator.SetBool("isJumping", true);
    }
    public void Drop(){
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -Jumpheight);
    }
}