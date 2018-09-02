using UnityEngine;
using System.Collections;

public class Flower_Anim : MonoBehaviour
{
    private GameObject butt;
    private Rigidbody2D rb2d;
    private bool hit;
    private bool set;
    
    //Bring in the Nectar Timer
    private NectarTimer nectarTime;
    public float nectarRemaining;
    public float startSeconds;

  //  public bool flowerDrained;
    private bool setFlowerStatus;
    public bool flowerDrained;

    //animator

    private Animator animator;

    //flower behaviour
    public float rot;
    public int hitMeUp;



    public void Start()
    {
        
        butt = GameObject.Find("BFly_Player");
        rb2d = GetComponent<Rigidbody2D>();
        set = false;
        setFlowerStatus = true;
        flowerDrained = false;
        

        
    }

    public void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject == butt)
        {

            if (flowerDrained == false)
            {
                hit = true;
                flowerDrained = false;
                //Debug.Log("Flower Drained Anim " + flowerDrained);
                BFly_Control buttScript = butt.GetComponent<BFly_Control>();
                buttScript.speed = 22;


            }

            //TODO: 02/09/18 - Need this to set when fire is hit the first time only. Currently it is not bound to the input
            if (set == false)
            {
                SetNectarTimer();
            }


        }

    }

    public void OnTriggerExit2D(Collider2D Other)
    {
        if (Other.gameObject == butt)
        {
            hit = false;
            set = false;
            BFly_Control buttScript = butt.GetComponent<BFly_Control>();
            buttScript.speed = 80;
            if (nectarRemaining > 0)
            {
                startSeconds = (float)(startSeconds * nectarRemaining);
                //Debug.Log(startSeconds);
            }

            //Debug.Log(nectarRemaining);
        }
    }


    void FixedUpdate()
    {


        if (Input.GetButton("Fire1"))
        {
            

            if (hit == true && flowerDrained == false && setFlowerStatus == true)
            {
                rb2d.MoveRotation(rb2d.rotation + rot * Time.fixedDeltaTime);
                nectarRemaining = nectarTime.NectarProportionTimeRemain();


                if (nectarRemaining <= 0)
                {

                    if (setFlowerStatus == true)
                    {

                        flowerDrained = true;
                        setFlowerStatus = false;
                        animator = GetComponent<Animator>();
                        animator.Play("FlowerDrained");

                    }


                }

            }


        }    


    }

    public void SetNectarTimer()
    {
        set = true;
        nectarTime = GetComponent<NectarTimer>();
        nectarTime.NectarTimerReset(startSeconds);


    }



}
