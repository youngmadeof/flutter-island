﻿using UnityEngine;
using System.Collections;

public class Flower_Anim : MonoBehaviour
{
    public GameObject butt;
    private Rigidbody2D rb2d;
    public bool hit;
    public static bool blInteract;
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
    private int bloomHash;
    public bool animDone;

    //flower behaviour
    public float rot;
    public int hitMeUp;

    public int flowID; //Red = 0, Yellow = 1, Blue = 2, Black (destroy) = 3


    public void Start()
    {
        
        
        rb2d = GetComponent<Rigidbody2D>();
        set = false;
        setFlowerStatus = true;
        flowerDrained = false;
        

        if(flowID == 0)
        {
            bloomHash = Animator.StringToHash("Base Layer.RedFlowerBloom1");

        }

        else if (flowID == 1)
        {
            bloomHash = Animator.StringToHash("Base Layer.YellFlowerBloom");
        }

        else if (flowID == 2)
        {
            bloomHash = Animator.StringToHash("Base Layer.BluFlowerBloom");
        }
       
        //TODO: NEVER HAD A YELLOW FLOWER SPAWN FIRST SO NEE TO GRAB YELLOW BLOOM HASH TO USE FOR ANIMDONE
        //Debug.Log("bloom " + bloomHash);
        animDone = false;
        
       
    }


    public void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject == butt)
        {

            if (flowerDrained == false)
            {
                hit = true;
                blInteract = true;
                flowerDrained = false;
                //Debug.Log("Flower Drained Anim " + flowerDrained);
                BFly_Control buttScript = butt.GetComponent<BFly_Control>();
                buttScript.speed = 22;
                animator.SetBool("Coll", true);
            }
            

        }

    }

    public void OnTriggerExit2D(Collider2D Other)
    {
        if (Other.gameObject == butt)
        {
            hit = false;
            blInteract = false;
            //set = false;
            BFly_Control buttScript = butt.GetComponent<BFly_Control>();
            buttScript.speed = 80;
            animator.SetBool("Coll", false);


        }
    }


    void Update()
    {
        animator = GetComponent<Animator>();
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        //Debug.Log("Full path Hash " + stateInfo.fullPathHash);
        if (stateInfo.fullPathHash == bloomHash)
        {
            if(stateInfo.normalizedTime >= stateInfo.length -1f && animDone == false)
            {
                
                animDone = true;
                animator.SetBool("Idle", true);


            }

        }


        if (Input.GetButton("Fire1") && hit == true && flowerDrained == false && setFlowerStatus == true)
        {

            //Debug.Log(startSeconds);
            rb2d.MoveRotation(rb2d.rotation + rot * Time.fixedDeltaTime);

            if (set == false)
            {
                SetNectarTimer();
            }


            nectarRemaining = nectarTime.NectarProportionTimeRemain();

 
            if (nectarRemaining <= 0)
            {

                if (setFlowerStatus == true)
                {                    
                    flowerDrained = true;
                    blInteract = false;
                    setFlowerStatus = false;
                    animator = GetComponent<Animator>();
                    BFly_Control buttScript = butt.GetComponent<BFly_Control>();
                    buttScript.speed = 80;

                }


            }




        }

        else if (Input.GetButtonUp("Fire1") && hit == true && flowerDrained == false && setFlowerStatus == true && set == true)
        {
           if (nectarRemaining > 0)
            {
                startSeconds = (float)(startSeconds * nectarRemaining);
                //Debug.Log("reset start secs" + startSeconds);
                set = false;
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
