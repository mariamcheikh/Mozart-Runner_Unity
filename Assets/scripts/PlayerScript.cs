using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour {
    public float moveSpeed = 5f;
    public float JumpForce = 15f;
    private Rigidbody2D myRigidbody;
   // public bool Flying = false;
    public int click = 0;
    public bool grounded;
    public LayerMask whatIsGround;
    public hero h;
    public bool Flying = true;

    private Collider2D myCollider;


    private Animator myAnimator;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
            

        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);
        if ( Input.GetKeyDown(KeyCode.Space)|| Input.GetMouseButtonDown(0))
        {
            if (grounded)
            { 
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, JumpForce);
                 h.Flying = false;
                myAnimator.SetBool("Flying", false);
               // Debug.Log("Flying " + Flying);
            }

           /* click++;
            if (click > 2)
            {
                Flying = true;
                if (GameControll.instance.progressBarValue > GameControll.instance.progressMin)
                {
                    Flying = true;
                    /*Hero.velocity = Vector2.zero;
                    Hero.AddForce(new Vector2(0, UpForce));
                    GameControll.instance.healthMinus = true;*/

                  //  myAnimator.SetBool("Flying", Flying);
                    //Debug.Log("Flying " + Flying);
              //  }
            //}
        }

        myAnimator.SetFloat("Speed", myRigidbody.velocity.x);
        Debug.Log("Speed " + myRigidbody.velocity.x);
        myAnimator.SetBool("Grounded", grounded);
        Debug.Log("Grounded " + grounded);
     //   myAnimator.SetBool("Flying", false);

    }
}
