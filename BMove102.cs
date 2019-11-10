using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMove102 : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public bool toTree1;
    public bool toTree2;
    public bool toTree3;
    public bool atTree1;
    public bool atTree2;
    public bool atTree3;
    public bool iterationDone;

    private float incrementor = 0;

    private float duration;

    public int tripCount;


    public GameObject tree1;
    public GameObject tree2;

    public GameObject birdHead;

    private bool gotYerButt;

    private float birdRotPos;

    private float offSet;

    public bool birdScan;

    Animator animator;

    public int curState;

    private enum State
    {
        fly,
        scan
    }


    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        toTree1 = false;
        toTree2 = true; //we be going to tree 2 first
        toTree3 = false;
        atTree1 = false;
        atTree2 = false;
        atTree3 = false;
        gotYerButt = false; 
        BirdHeadScan birdHead = GetComponent<BirdHeadScan>();
        birdScan = false;
        curState = (int)State.fly;
        tripCount = 0;
        offSet = 20f;


    }

    void FixedUpdate()
    {

        if (Time.timeSinceLevelLoad > 1.5f)
        {
            if (gotYerButt == false)
            {
                BirdyGo();
            }

        }



    }

    void BirdyGo()
    {
        Vector3 currentPos = new Vector3();

        Vector3 treePos1 = tree1.transform.position;

        Vector3 treePos2 = tree1.transform.position;

        Vector3 treePos3 = tree2.transform.position;

        //finding the centre for the arc between tree & tree1
        Vector3 centre1 = (treePos1 + treePos2) * 0.25f;
        centre1 -= new Vector3(0, -1, 0);
        Vector3 oneToTwoRelCentre = treePos1 - centre1;
        Vector3 twoToOneRelCentre = treePos2 - centre1;


        Vector3 centre2 = (treePos2 + treePos3) * 0.35f;
        centre2 -= new Vector3(0, -1, 0);
        Vector3 twoToThreeRelCentre = treePos2 - centre2;
        Vector3 threeToTwoRelCentre = treePos3 - centre2;

        Vector3 centre3 = (treePos3 + treePos1) * -1.5f;
        centre3 -= new Vector3(0, -1, 0);
        Vector3 threeToOneRelCentre = treePos3 - centre3;
        Vector3 oneToThreeRelCentre = treePos1 - centre3;

        Vector3 centre4 = (treePos1 + treePos3) * 0.25f;
        centre4 -= new Vector3(0, -2, 0);
        Vector3 oneToThreeRelCentre2 = treePos1 - centre4;
        Vector3 threeToOneRelCentre2 = treePos3 - centre4;

        currentPos = transform.position;

        duration = 1.5f;

        //fly state
        if (curState == (int)State.fly)
        {
            animator.Play("Bird_Fly");

            BirdHeadScan scanScript = birdHead.GetComponent<BirdHeadScan>();
            bool scanDone = scanScript.scanDone;

            if (toTree2 == true)
            {
                incrementor += 0.01f;
                transform.position = Vector3.Slerp(oneToTwoRelCentre, twoToOneRelCentre, incrementor / duration);
                transform.position += centre1;
                rb2d.position = (transform.position).normalized;

                //float angle = Mathf.Atan2(treePos1.y, treePos1.x) * Mathf.Rad2Deg;

                // birdRotPos = rb2d.rotation;

                transform.Rotate(0, 0, -1 * 20 * Time.fixedDeltaTime);

                if (Vector3.Distance(currentPos, treePos2) <= 0.1)
                {
                    toTree2 = false;
                    atTree2 = true;
                    curState = (int)State.scan;
                    scanScript.scanDone = false;

                }

            }

            if (toTree3 == true)
            {

                if (tripCount == 0)
                {
                    //duration = 2.0f;
                    incrementor += 0.01f;
                    transform.position = Vector3.Slerp(twoToThreeRelCentre, threeToTwoRelCentre, incrementor / duration);
                    transform.position += centre2;
                    rb2d.position = (transform.position).normalized;

                    //float angle = Mathf.Atan2(treePos3.y, treePos3.x) * Mathf.Rad2Deg;

                    //birdRotPos = rb2d.rotation;

                    transform.Rotate(0, 0, -1 * 30 * Time.fixedDeltaTime);
                }

                if (tripCount == 1)
                {
                    //duration = 1.0f;
                    incrementor += 0.01f;
                    transform.position = Vector3.Slerp(oneToThreeRelCentre2, threeToOneRelCentre2, incrementor / duration);
                    transform.position += centre4;
                    rb2d.position = (transform.position).normalized;

                    //float angle = Mathf.Atan2(treePos3.y, treePos3.x) * Mathf.Rad2Deg;

                    // birdRotPos = rb2d.rotation;

                    transform.Rotate(0, 0, -1 * 20 * Time.fixedDeltaTime);
                }


                if (Vector3.Distance(currentPos, treePos3) <= 0.1)
                {
                    toTree3 = false;
                    atTree3 = true;
                    scanScript.scanDone = false;
                    curState = (int)State.scan;

                }


            }

            if (toTree1 == true)
            {
                duration = 1.2f;
                incrementor += 0.01f;
                transform.position = Vector3.Slerp(threeToOneRelCentre, oneToThreeRelCentre, incrementor / duration);
                transform.position += centre3;
                rb2d.position = (transform.position).normalized;

                if (tripCount == 0)
                {
                    //float angle = Mathf.Atan2(treePos3.y, treePos3.x) * Mathf.Rad2Deg;

                    //birdRotPos = rb2d.rotation;

                    transform.Rotate(0, 0, -1 * 30 * Time.fixedDeltaTime);
                }

                else

                {

                    transform.Rotate(0, 0, -1 * 20 * Time.fixedDeltaTime);
                }


                if (Vector3.Distance(currentPos, treePos1) <= 0.1)
                {
                    atTree1 = true;
                    scanScript.scanDone = false;
                    curState = (int)State.scan;

                    if (tripCount == 0)
                    {
                        toTree1 = false;
                        tripCount += 1;
                    }

                    else
                    {
                        toTree1 = false;
                        tripCount -= 1;
                    }

                }


            }


        }

        //scan state
        if (curState == (int)State.scan)
        {
            animator.Play("BirdIdle");

            birdScan = true;
            //Slowly rotate enemy towards next tree

            BirdHeadScan scanScript = birdHead.GetComponent<BirdHeadScan>();
            bool scanDone = scanScript.scanDone;

            if (atTree2 == true && curState == (int)State.scan)
            {



                float angle = Vector2.Angle(transform.position, treePos3);
                float birdAngle = Vector2.Angle(transform.up, transform.position);


                if (Mathf.Round(birdAngle) != Mathf.Round(angle))
                {
                    transform.Rotate(0, 0, -1 * 20 * Time.fixedDeltaTime);

                }

                if (scanDone == true)
                {
                    incrementor = 0;
                    curState = (int)State.fly;
                    atTree2 = false;
                    toTree3 = true;
                    birdScan = false;
                }

            }

            if (atTree3 == true && curState == (int)State.scan)
            {

                float angle = Vector2.Angle(transform.position, treePos1);
                float birdAngle = Vector2.Angle(transform.up, transform.position);



                if (Mathf.Round(birdAngle) != Mathf.Round(angle))
                {
                    transform.Rotate(0, 0, -1 * 20 * Time.fixedDeltaTime);

                }

                if (scanDone == true)
                {
                    incrementor = 0;
                    curState = (int)State.fly;
                    atTree3 = false;
                    toTree1 = true;
                    birdScan = false;
                }


            }

            if (atTree1 == true && curState == (int)State.scan)
            {

                if (tripCount == 0)
                {

                    float angle = Vector2.Angle(transform.position, treePos3);

                    float birdAngle = Vector2.Angle(transform.up, transform.position);


                    if (Mathf.Round(birdAngle) != Mathf.Round(angle))
                    {
                        transform.Rotate(0, 0, -1 * 25 * Time.fixedDeltaTime);

                    }


                }

                else
                {

                    float angle = Mathf.Atan2(treePos3.y, treePos3.x) * Mathf.Rad2Deg;
                    float birdAngle = Vector2.Angle(transform.up, transform.position);


                    if (Mathf.Round(birdAngle) != Mathf.Round(angle))
                    {
                        transform.Rotate(0, 0, -1 * 25 * Time.fixedDeltaTime);

                    }
                }

                if (scanDone == true)
                {
                    incrementor = 0;
                    atTree1 = false;
                    curState = (int)State.fly;
                    birdScan = false;

                    if (tripCount == 1)
                    {
                        toTree3 = true;
                    }

                    else
                    {
                        toTree2 = true;
                    }
                }

            }





        }





    }




}

