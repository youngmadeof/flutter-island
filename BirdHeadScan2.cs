using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdHeadScan2 : MonoBehaviour
{
    private Rigidbody2D headRB;
    public float headPos;
    public bool rotateDoneRight;
    public bool rotateDoneLeft;
    public float headPosReset;
    private bool headPosStart;


    public GameObject bird;
    public GameObject cone;
    public GameObject butt;

    public GameObject gameManage;
    private string levelStr;

    private Animator animator;

    private bool scanInit;
    private bool extractDone;
    public bool scanDone;
    //private bool retractDone;
    private int coneAnimHash;

    public int speed;

    private int curState;

    private enum State
    {
        scan,
        scanDone
    }



    // Use this for initialization
    void Start()

    {
        rotateDoneRight = false;
        rotateDoneLeft = false;

        cone.SetActive(false);
        extractDone = false;
        headRB = GetComponent<Rigidbody2D>();
        headPosReset = headRB.transform.localEulerAngles.z;
        coneAnimHash = Animator.StringToHash("Base Layer.BirdViewConeRetract");

        FlowRuntime getLevel = gameManage.GetComponent<FlowRuntime>();
        levelStr = getLevel.levelNo;


    }

    // Update is called once per frame
    void FixedUpdate()

    {
        headRB = GetComponent<Rigidbody2D>();

        //Need to call this depending on level number


        if (levelStr == "101")
        {

            BMove101 birdScript = bird.GetComponent<BMove101>();
            scanInit = birdScript.birdScan;
        }

        else if (levelStr == "102")
        {
            BMove102 birdScript = bird.GetComponent<BMove102>();
            scanInit = birdScript.birdScan;
        }

        else if (levelStr == "103")
        {

            BirdMove birdScript = bird.GetComponent<BirdMove>();
            scanInit = birdScript.birdScan;
        }

        else if(levelStr == "104")
        {
            BMove104_2 birdScript = bird.GetComponent<BMove104_2>();
            scanInit = birdScript.birdScan;
        }

        else if(levelStr == "105")
        {
            BMove105_2 birdScript = bird.GetComponent<BMove105_2>();
            scanInit = birdScript.birdScan;
        }




        if (scanInit == true)
        {

            cone.SetActive(true);
            animator = cone.GetComponent<Animator>();

            if (extractDone == false)
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
                    headRB.transform.Rotate(0, 0, -1 * speed * Time.fixedDeltaTime);
                    headPos = headRB.transform.localEulerAngles.z;

                    if (headPos <= 280.0f)
                    {
                        rotateDoneRight = true;

                    }



                }

                if (rotateDoneRight == true && rotateDoneLeft == false)
                {
                    headRB.transform.Rotate(0, 0, 1 * speed * Time.fixedDeltaTime);
                    headPos = headRB.transform.localEulerAngles.z;

                    if (headPos <= 280.0f && headPos >= 70.0f)
                    {
                        rotateDoneLeft = true;

                    }

                }

                if (rotateDoneRight == true && rotateDoneLeft == true)
                {

                    headRB.transform.Rotate(0, 0, -1 * speed * Time.fixedDeltaTime);
                    headPos = headRB.transform.localEulerAngles.z;

                    if (Mathf.Round(headPos) == Mathf.Round(headPosReset))
                    {
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
                        if (levelStr == "101")
                        {

                            BMove101 birdScript = bird.GetComponent<BMove101>();
                            birdScript.birdScan = false;
                        }

                        else if (levelStr == "102")
                        {
                            BMove102 birdScript = bird.GetComponent<BMove102>();
                            birdScript.birdScan = false;
                        }

                        else if (levelStr == "103")
                        {

                            BirdMove birdScript = bird.GetComponent<BirdMove>();
                            birdScript.birdScan = false;
                        }

                        else if(levelStr == "104")
                        {
                            BMove104_2 birdScript = bird.GetComponent<BMove104_2>();
                            birdScript.birdScan = false;
                        }

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
