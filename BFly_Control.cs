using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BFly_Control : MonoBehaviour {

    private Rigidbody2D rb2d;
    //private BoxCollider2D bxCol;

    public float speed;

    private Animator animator;

    public int curState;
    public GameObject cloud;
    public GameObject birdCone;

    private bool coneCollision;
    private bool cloudCollision;

    //whack in some states
    private enum State
    {
        normal,
        interact,
        dead
    }
  
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        speed = 80;
        animator = GetComponent<Animator>();
        curState = (int)State.normal;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == birdCone)
        {
            if(cloudCollision == false)
            {
                coneCollision = true;
            }
            
            
        }

        if (collision.gameObject == cloud)
        {
            cloudCollision = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject == cloud)
        {
            cloudCollision = false;
        }

    }



    void FixedUpdate ()
	{
    
        if (Input.GetButton("Fire1"))
        {
            curState = (int)State.interact;
            animator.Play("BFlyIdle");
        }

        else if (coneCollision == true & cloudCollision == false)
        {
            curState = (int)State.dead;
        }

        else
        {
            curState = (int)State.normal;
        }


        if(curState == (int)State.normal)
        {
            float MoveButtY = Input.GetAxisRaw("Horizontal");
            float MoveButtX = Input.GetAxisRaw("Vertical");

            Vector2 movement = new Vector2(MoveButtY, MoveButtX);

            rb2d.AddForce(movement * speed);

            if (MoveButtY > 0 || MoveButtX > 0 || MoveButtX < 0 || MoveButtY < 0)
            {
                animator.Play("BFlyMove");
            }
            else
            {
                animator.Play("BFlyIdle");
            }
            //8 directional movement

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

        if(curState == (int)State.dead)
        {
            SceneManager.LoadScene("GameIsDoneded");
        }


    }



}
