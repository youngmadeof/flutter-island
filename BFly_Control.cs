using UnityEngine;
using System.Collections;


public class BFly_Control : MonoBehaviour {

    private Rigidbody2D rb2d;
    //private BoxCollider2D bxCol;

    public float speed;

    private Animator animator;

    public int curState;
    public int movState;
    public GameObject cloud;
    public GameObject birdCone;

    public GameObject buttExp;


    private bool coneCollision;
    private bool cloudCollision;


    //whack in some states
    private enum State
    {
        normal,
        interact,
        dead
    }

    private enum MoveState
    {
        move,
        idle
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
        

        if (coneCollision == true && cloudCollision == false)
        {
            curState = (int)State.dead;
        }

        else if (Input.GetButton("Fire1"))
        {
            if(coneCollision == false || cloudCollision == true)
            {
                curState = (int)State.interact;
                animator.Play("BFlyIdle");
                movState = (int)MoveState.idle;
            }
            
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
                animator.SetBool("Idle", false);
                movState = (int)MoveState.move;
                
            }
            else
            {
                animator.SetBool("Idle", true);
                movState = (int)MoveState.idle;

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
            //gameObject.SetActive(false);
            Vector3 buttPos = transform.position;
            ButtExplosion getButtBang = buttExp.GetComponent<ButtExplosion>();
            getButtBang.buttGoBang(buttPos);
            DestroyObject();
        }


    }

    void DestroyObject()
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }

}
