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


   // private void Awake()
    //{
   //     flowerDrained = false;
   // }

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



            hit = true;
            //TODO: NEED TO LOOK AT THIS AS FLOWERDRAINED IS RESETTING 
            flowerDrained = false;
            //Debug.Log("Flower Drained Anim " + flowerDrained);


            if (set == false)
            {
                SetNectarTimer();
            }

            //Debug.Log(hit);
        }
    }

    void OnTriggerExit2D(Collider2D Other)
    {
        if (Other.gameObject == butt)
        {
            hit = false;
            set = false;
            //Debug.Log(hit);
            if (nectarRemaining > 0)
            {
                startSeconds = (float)(startSeconds * nectarRemaining);
                //Debug.Log(startSeconds);
            }

            //Debug.Log(nectarRemaining);
        }
    }

    public void Update()
    {

        if (hit == true && flowerDrained == false && setFlowerStatus == true)
        {
            BFly_Control buttScript = butt.GetComponent<BFly_Control>();
            buttScript.speed = 22;
            rb2d.MoveRotation(rb2d.rotation + rot * Time.fixedDeltaTime);
            nectarRemaining = nectarTime.NectarProportionTimeRemain();


            if (nectarRemaining <= 0)
            {

                if (setFlowerStatus == true)
               {
                    
                    flowerDrained = true;
                    //Debug.Log("Flower Drained Anim " + flowerDrained);
                    setFlowerStatus = false;
                    animator = GetComponent<Animator>();
                    animator.Play("FlowerDrained");
                    
                   
               }


            }
        }

        else if (hit == false)
        {
            BFly_Control buttScript = butt.GetComponent<BFly_Control>();
            buttScript.speed = 80;
        }
    }

    public void SetNectarTimer()
    {
        set = true;
        nectarTime = GetComponent<NectarTimer>();
        nectarTime.NectarTimerReset(startSeconds);


    }



}
