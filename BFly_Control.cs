using UnityEngine;
using System.Collections;


public class BFly_Control : MonoBehaviour {

    private Rigidbody2D rb2d;
    //private BoxCollider2D bxCol;

    public float speed;

    private Animator animator;

    public bool dontMove;

    public int movState;


    public enum MoveState
    {
        move,
        idle
    }
  
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        speed = 80;
        animator = GetComponent<Animator>();

    }

  



    void FixedUpdate ()
    {                
                 

        float MoveButtY = Input.GetAxisRaw("Horizontal");
        float MoveButtX = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(MoveButtY, MoveButtX);

        

        if (Input.GetButton("Fire1"))
        {
            movState = (int)MoveState.idle;
            dontMove = true;
            animator.SetBool("Idle", true);
        }

        else dontMove = false;

        if (MoveButtY > 0  || MoveButtX > 0  || MoveButtX < 0  || MoveButtY < 0)
        {
            if(dontMove == false)
            {
                animator.SetBool("Idle", false);
                movState = (int)MoveState.move;
            }
            
                
        }
        else
        {
            animator.SetBool("Idle", true);
            movState = (int)MoveState.idle;

        }


            //8 directional movement
        if (movState == (int)MoveState.move && dontMove == false)
        {
            rb2d.AddForce(movement * speed);

            if (MoveButtY > 0 && MoveButtX > 0)
            {
                rb2d.MoveRotation(-45);
            }

            else if (MoveButtY < 0 && MoveButtX > 0)
            {
                rb2d.MoveRotation(45);
            }

            else if (MoveButtY > 0 && MoveButtX < 0)
            {
                rb2d.MoveRotation(-135);
            }

            else if (MoveButtY < 0 && MoveButtX < 0)
            {
                rb2d.MoveRotation(135);
            }
            else if (MoveButtY > 0)
            {
                rb2d.MoveRotation(-90);
            }
            else if (MoveButtY < 0)
            {

                rb2d.MoveRotation(90);
            }
            else if (MoveButtX > 0)
            {
                rb2d.MoveRotation(0);
            }
            else if (MoveButtX < 0)
            {
                rb2d.MoveRotation(180);
            }

        }
           

        




    }



}
