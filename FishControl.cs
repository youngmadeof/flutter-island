using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishControl : MonoBehaviour {

    private Animator anim;

    public float speed;

    Vector3 currPos;

    Vector3 fishPos;
    //store for ripple effect
    public GameObject gameMgmt;
   // public GameObject ripEffect;

    public GameObject node01;
    public GameObject node02;
    public GameObject node03;
    public GameObject node04;
    public GameObject node05;
    public GameObject node06;
    public GameObject node07;
    public GameObject node08;
    public GameObject node09;
    public GameObject node10;

    Vector3 node01Pos;
    Vector3 node02Pos;
    Vector3 node03Pos;
    Vector3 node04Pos;
    Vector3 node05Pos;
    Vector3 node06Pos;
    Vector3 node07Pos;
    Vector3 node08Pos;
    Vector3 node09Pos;
    Vector3 node10Pos;

    private bool toNode01;
    private bool toNode02;
    private bool toNode03;
    private bool toNode04;
    private bool toNode05;
    private bool toNode06;
    private bool toNode07;
    private bool toNode08;
    private bool toNode09;
    private bool toNode10;
    // Use this for initialization

    private static Vector3 currSize;

    //public bool jump;
    //public bool land;
    public bool jumpDone;
    private int animHash;
    public float jumpTime;
    public float jumpLen;

    //used for collision
    public bool collEnabled;
    public int damageVal;

    private bool timeStopped;

    void Start ()

    {
        animHash = Animator.StringToHash("Base Layer.FishJump");
        Debug.Log(animHash + " anim Hash");

        damageVal = 4;

        node01Pos = node01.transform.position;
        node02Pos = node02.transform.position;
        node03Pos = node03.transform.position;
        node04Pos = node04.transform.position;
        node05Pos = node05.transform.position;
        node06Pos = node06.transform.position;
        node07Pos = node07.transform.position;
        node08Pos = node08.transform.position;
        node09Pos = node09.transform.position;
        node10Pos = node10.transform.position;

        toNode01 = true;

        anim = GetComponent<Animator>();

        speed = 0.02f;

       // currSize = transform.localScale;

        //
        //ripEffect.SetActive(false);

    }
	
	// Update is called once per frame
	void FixedUpdate ()

    {


        currPos = transform.position;

        
        //collision management here
        if(collEnabled == true)
        {
            if (Time.fixedTime >= (jumpTime + jumpLen) +0.5f)
            {
                collEnabled = false;
            }
        }
 


        if (toNode01 == true )
        {

            transform.position += (node01Pos - transform.position).normalized * speed;
            Vector3 relPos = (currPos - node02Pos);
            Quaternion rot = Quaternion.LookRotation(relPos, Vector3.forward);

         

            if (Vector3.Distance(currPos,node01Pos) <= 1.5f)
            {



                rot.x = 0.0f;
                rot.y = 0.0f;
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 2f);
                //transform.Rotate(0, 0, rot.z);

                if (Vector3.Distance(currPos, node01Pos) <= 0.05f)
                {
                    toNode01 = false;
                    toNode02 = true;


                }

            }

        }
        
        if(toNode02 == true)
        {
            transform.position += (node02Pos - transform.position).normalized * speed;
            Vector3 relPos = (currPos - node03Pos);
            Quaternion rot = Quaternion.LookRotation(relPos, Vector3.forward);

            //Jump scripting active only when game is running
            FlowRuntime flowRT = gameMgmt.GetComponent<FlowRuntime>();
            timeStopped = flowRT.timeStopped;

            if(timeStopped == false)
            {
                float midDist = Vector3.Distance(currPos, node02Pos) / 3;
                float curDist = Vector3.Distance(currPos, node02Pos);

                if (Mathf.Round(curDist) == Mathf.Round(midDist) && jumpDone == false)
                {
                    //speed = 0.01f;
                    //transform.localScale = new Vector3(0.3f, 0.2f);
                    anim.Play("FishJump");
                    jumpTime = Time.fixedTime;
                    AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
                    jumpLen = stateInfo.length;
                    jumpDone = true;
                    collEnabled = true;
                    //ripEffect.SetActive(true);
                }


            }


            if (Vector3.Distance(currPos,node02Pos)<= 1.5f)
            {                
                
                rot.x = 0.0f;
                rot.y = 0.0f;
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 3f);

                if (Vector3.Distance(currPos, node02Pos) <= 0.35f)
                {

                    toNode02 = false;
                    toNode03 = true;
                    Debug.Log(toNode03 + " toNode03");
                    jumpDone = false;
                    //ripEffect.SetActive(false);
                }

            }

        }

        if (toNode03 == true)
        {
            transform.position += (node03Pos - transform.position).normalized * speed;
            Vector3 relPos = (currPos - node04Pos);
            Quaternion rot = Quaternion.LookRotation(relPos, Vector3.forward);


            if (Vector3.Distance(currPos,node03Pos)<= 2f)
            {

               
                
                rot.x = 0.0f;
                rot.y = 0.0f;
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 5f);

                if (Vector3.Distance(currPos, node03Pos) <= 0.35f)
                {
                    toNode03 = false;
                    toNode04 = true;
                }
            }
  
        }

        if(toNode04 == true)
        {
            transform.position += (node04Pos - transform.position).normalized * speed;
            Vector3 relPos = (currPos - node05Pos);
            Quaternion rot = Quaternion.LookRotation(relPos, Vector3.forward);

            if (Vector3.Distance(currPos,node04Pos)<= 1f)
            {
               
                rot.x = 0.0f;
                rot.y = 0.0f;
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 5f);

                if (Vector3.Distance(currPos, node04Pos) <= 0.35f)
                {
                    toNode04 = false;
                    toNode05 = true;

                }
            }

        }

        if (toNode05 == true)
        {
            transform.position += (node05Pos - transform.position).normalized * speed;


            Vector3 relPos = (currPos - node06Pos).normalized * 0.02f;
            Quaternion rot = Quaternion.LookRotation(relPos, Vector3.forward);

            float halfDist = Vector3.Distance(currPos, node05Pos) / 2;
            float curDist = Vector3.Distance(currPos, node05Pos);

            FlowRuntime flowRT = gameMgmt.GetComponent<FlowRuntime>();
            timeStopped = flowRT.timeStopped;

            if(timeStopped == false)
            {
                if (Mathf.Round(curDist) == Mathf.Round(halfDist) && jumpDone == false)
                {
                    //speed = 0.01f;
                    //transform.localScale = new Vector3(0.3f, 0.2f);
                    anim.Play("FishJump");
                    jumpTime = Time.fixedTime;
                    AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
                    jumpLen = stateInfo.length;
                    jumpDone = true;
                    collEnabled = true;
                }

            }


            if (Vector3.Distance(currPos,node05Pos)<= 1f)
            {
                rot.x = 0.0f;
                rot.y = 0.0f;
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 10f);
                

                if (Vector3.Distance(currPos, node05Pos) <= 0.35f)
                {

                    jumpDone = false;
                    toNode05 = false;
                    toNode06 = true;


                }

            }

        }

        if (toNode06 == true)
        {
            transform.position += (node06Pos - transform.position).normalized * 0.02f;
            Vector3 relPos = (currPos - node07Pos).normalized;
            Quaternion rot = Quaternion.LookRotation(relPos, Vector3.forward);

            if (Vector3.Distance(currPos,node06Pos)<= 1f)
            {

          
                rot.x = 0.0f;
                rot.y = 0.0f;
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 10f);

                if (Vector3.Distance(currPos, node06Pos) <= 0.35f)
                {
                    toNode06 = false;
                    toNode07 = true;


                }
            }

        }

        if (toNode07 == true)
        {
            transform.position += (node07Pos - transform.position).normalized * 0.02f;
            Vector3 relPos = (currPos - node08Pos).normalized;
            Quaternion rot = Quaternion.LookRotation(relPos, Vector3.forward);
 
            if(Vector3.Distance(currPos, node07Pos)<= 1f)
            {
                rot.x = 0.0f;
                rot.y = 0.0f;
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 10f);

                if (Vector3.Distance(currPos, node07Pos) <= 0.35f)
                {
                    toNode07 = false;
                    toNode08 = true;


                }
            }

        }

        if (toNode08 == true)
        {
            transform.position += (node08Pos - transform.position).normalized * 0.02f;
            Vector3 relPos = (currPos - node09Pos).normalized;
            Quaternion rot = Quaternion.LookRotation(relPos, Vector3.forward);

            float midDist = Vector3.Distance(currPos, node08Pos) / 4;
            float curDist = Vector3.Distance(currPos, node08Pos);

            FlowRuntime flowRT = gameMgmt.GetComponent<FlowRuntime>();
            timeStopped = flowRT.timeStopped;

            if(timeStopped == false)
            {
                if (Mathf.Round(curDist) == Mathf.Round(midDist) && jumpDone == false)
                {
                    //speed = 0.01f;
                    //transform.localScale = new Vector3(0.3f, 0.2f);
                    anim.Play("FishJump");
                    jumpTime = Time.fixedTime;
                    AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
                    jumpLen = stateInfo.length;
                    jumpDone = true;
                    collEnabled = true;

                }
            }

                       

            if (Vector3.Distance(currPos,node08Pos)<=1f)
            {
                rot.x = 0.0f;
                rot.y = 0.0f;
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 10f);

                if (Vector3.Distance(currPos, node08Pos) <= 0.35f)
                {
                    toNode08 = false;
                    toNode09 = true;
                    jumpDone = false;


                }
            }
   
        }


        if (toNode09 == true)
        {
            transform.position += (node09Pos - transform.position).normalized * 0.02f;
            Vector3 relPos = (currPos - node10Pos).normalized;
            Quaternion rot = Quaternion.LookRotation(relPos, Vector3.forward);

            float midDist = Vector3.Distance(currPos, node09Pos) / 3;
            float curDist = Vector3.Distance(currPos, node09Pos);


            FlowRuntime flowRT = gameMgmt.GetComponent<FlowRuntime>();
            timeStopped = flowRT.timeStopped;

            if(timeStopped == false)
            {
                if (Mathf.Round(curDist) == Mathf.Round(midDist) && jumpDone == false)
                {
                    anim.Play("FishJump");
                    jumpTime = Time.fixedTime;
                    AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
                    jumpLen = stateInfo.length;
                    jumpDone = true;
                    collEnabled = true;
                }

            }




            if (Vector3.Distance(currPos, node09Pos)<= 1f)
            {
                rot.x = 0.0f;
                rot.y = 0.0f;
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 10f);

                if (Vector3.Distance(currPos, node09Pos) <= 0.35f)
                {
                    toNode09 = false;
                    toNode10 = true;
                    jumpDone = false;

                }

            }

        }

        if (toNode10 == true)
        {
            transform.position += (node10Pos - transform.position).normalized * 0.02f;
            Vector3 relPos = (currPos - node01Pos).normalized * 0.02f;
            Quaternion rot = Quaternion.LookRotation(relPos, Vector3.forward);
  
            if(Vector3.Distance(currPos, node10Pos)<= 1f)
            {
                rot.x = 0.0f;
                rot.y = 0.0f;
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 10f);

                if (Vector3.Distance(currPos, node10Pos) <= 0.35f)
                {
                    toNode10 = false;
                    toNode01 = true;


                }
            }
 
        }
    }


}
