using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCcontrol : MonoBehaviour {

    //variables are containers
    // Player Movement Variables
    public int MoveSpeed;
    public float Jumpheight;
    private bool DoubleJump;
    // Player grounded variables
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;
    //non-slip player variable
    private float moveVelocity;

	// Use this for initialization
	void Start () {
		
	}
	
	void FixedUpdate (){
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}

	// Update is called once per frame
	private void Update(){

            //this code makes the character jump
        if(Input.GetKeyDown(KeyCode.W) && grounded){
                Jump(); 
            }

        //double jump
        if(grounded)
            DoubleJump = false;

        if(Input.GetKeyDown (KeyCode.W)&& !DoubleJump && !grounded){
            Jump();
            DoubleJump = true;
        }

        //non-slip player
        moveVelocity = 0f;

        // this is the A&D keys for left and right.
        if(Input.GetKey (KeyCode.D)){
            //GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            //non-slip code
            moveVelocity = MoveSpeed;
        }
        if(Input.GetKey (KeyCode.A)){
            //GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            //non-slip code
            moveVelocity = -MoveSpeed;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

        //player flip
        if (GetComponent<Rigidbody2D>().velocity.x > 0)
            transform.localScale = new Vector3(-5f, 5f, 1f);

        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
            transform.localScale = new Vector3(-5f, 5f, 1f);
    }

    public void Jump(){
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, Jumpheight);
    }

}
