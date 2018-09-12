using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCcontrol : MonoBehaviour {

    // Player Movement Variables
    public int MoveSpeed;
    public float Jumpheight;

    // Player grounded variables
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

	// Use this for initialization
	void Start () {
		
	}
	
	
	void FixedUpdate () {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}

	// Update is called once per frame
	private void Update(){

            //this code makes the character jump
        if(Input.GetKeyDown(KeyCode.W) && grounded){
                Jump(); 
            }

        // this is the A&D keys ror left and right.
        if(Input.GetKey (KeyCode.D)){
            GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);

        }
        if(Input.GetKey (KeyCode.A)){
            GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);

        }
    }

    public void Jump(){
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, Jumpheight);
    }

}
