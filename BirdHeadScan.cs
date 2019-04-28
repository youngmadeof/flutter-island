using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BirdHeadScan : MonoBehaviour {


    private Rigidbody2D headRB;
    public float headPos;
    public bool rotateDoneRight;
    public bool rotateDoneLeft;
    public float headPosReset;
    private bool headPosStart;


    public GameObject bird;
    public GameObject cone;
    public GameObject butt;


    private Animator animator;

    private bool extractDone;
    public bool scanDone;
    //private bool retractDone;
    private int coneAnimHash;

    private int curState;

    private enum State
    {
        scan,
        scanDone
    }



    // Use this for initialization
    void Start ()

    {
        //headPos = 0f;
        rotateDoneRight = false;
        rotateDoneLeft = false;

        //bird = GameObject.Find("Bird");

        //cone = GameObject.Find("ViewCone");
        cone.SetActive(false);
        extractDone = false;
        //retractDone = false;
        headRB = GetComponent<Rigidbody2D>();
        headPosReset = headRB.transform.localEulerAngles.z;
        coneAnimHash = Animator.StringToHash("Base Layer.BirdViewConeRetract");

        //butt = GameObject.Find("BFly_Player");

    }
	
	// Update is called once per frame
	void FixedUpdate ()

    {
        headRB = GetComponent<Rigidbody2D>();
        BirdMove birdScript = bird.GetComponent<BirdMove>();



        if (birdScript.birdScan == true)
        {
        
            cone.SetActive(true);
            animator = cone.GetComponent<Animator>();

            if(extractDone == false)
            {
                
                animator.Play("BirdViewConeExtract");

                extractDone = true;
                curState = (int)State.scan;
                
                
            }



            if (curState == (int)State.scan)
            {
                if (rotateDoneRight == false)
                {

                    if (headPosStart == false)
                    {
                        headPosReset = headRB.transform.localEulerAngles.z;
                        headPosStart = true;
                    }
                    headRB.transform.Rotate(0, 0, -1 * 45 * Time.fixedDeltaTime);
                    headPos = headRB.transform.localEulerAngles.z;
                    //headPos = headRB.transform.localPosition.z;
                    //Debug.Log("BirdHead right " + headPos);

                    if (headPos <= 280.0f)
                    {
                        rotateDoneRight = true;
                        //Debug.Log("rotRight " + rotateDoneRight);

                    }



                }

                if (rotateDoneRight == true && rotateDoneLeft == false)
                {
                    headRB.transform.Rotate(0, 0, 1 * 45 * Time.fixedDeltaTime);
                    headPos = headRB.transform.localEulerAngles.z;
                    //headPos = headRB.transform.localPosition.z;
                    //Debug.Log("BirdHead left " + headPos);

                    if (headPos <= 280.0f && headPos >= 70.0f)
                    {
                        rotateDoneLeft = true;

                        //Debug.Log("rotLeft " + rotateDoneLeft);
                    }

                }

                if (rotateDoneRight == true && rotateDoneLeft == true)
                {

                    headRB.transform.Rotate(0, 0, -1 * 45 * Time.fixedDeltaTime);
                    headPos = headRB.transform.localEulerAngles.z;
                    //headPos = headRB.transform.localPosition.z;
                    //Debug.Log("BirdHead right again " + headPos);

                    if (Mathf.Round(headPos) == Mathf.Round(headPosReset))
                    {
                        //headRB.transform.localEulerAngles = new Vector3(0, 0, headPosReset);
                        //Debug.Log("head start pos: " + headPosReset);
                        animator.Play("BirdViewConeRetract");
                        curState = (int)State.scanDone;




                    }

                }
            }

            if (curState == (int)State.scanDone)
            {
                AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

                if (stateInfo.fullPathHash == coneAnimHash)
                {
                    if (stateInfo.normalizedTime >= stateInfo.length + 0.5f)
                    {
                        birdScript.birdScan = false;
                        extractDone = false;
                        rotateDoneRight = false;
                        rotateDoneLeft = false;
                        scanDone = true;
                        cone.SetActive(false);
                    }
                }
            }

        
        }
                      
        
    }


}
