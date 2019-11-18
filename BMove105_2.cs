using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMove105_2 : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public bool toTree1;
    public bool toTree2;
    public bool toTree3;
    public bool toTree4;
    public bool atTree1;
    public bool atTree2;
    public bool atTree3;
    public bool atTree4;
    public bool iterationDone;

    private float incrementor = 0;

    private float duration;

    public int tripCount;


    public GameObject tree1;
    public GameObject tree2;
    public GameObject tree3;
    public GameObject tree4;

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
        BirdHeadScan2 birdHead = GetComponent<BirdHeadScan2>();
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

        Vector3 treePos2 = tree2.transform.position;

        Vector3 treePos3 = tree3.transform.position;

        Vector3 treePos4 = tree4.transform.position;

        //finding the centre for the arc between tree & tree1
        Vector3 centre1 = (treePos1 + treePos2) * 0.15f;
        centre1 -= new Vector3(0, -1, 0);
        Vector3 oneToTwoRelCentre = treePos1 - centre1;
        Vector3 twoToOneRelCentre = treePos2 - centre1;


        Vector3 centre2 = (treePos2 + treePos3) * 0.35f;
        centre2 -= new Vector3(0, -1, 0);
        Vector3 twoToThreeRelCentre = treePos2 - centre2;
        Vector3 threeToTwoRelCentre = treePos3 - centre2;

        Vector3 centre3 = (treePos3 + treePos4) * 1.5f;
        centre3 -= new Vector3(0, -1, 0);
        Vector3 threeToFourRelCentre = treePos3 - centre3;
        Vector3 fourToThreeRelCentre = treePos4 - centre3;

        Vector3 centre4 = (treePos4 + treePos1) * 0.25f;
        centre4 -= new Vector3(0, 1, 0);
        Vector3 oneToFourRelCentre = treePos1 - centre4;
        Vector3 fourToOneRelCentre = treePos4 - centre4;

        currentPos = transform.position;

        duration = 1.2f;

        //fly state
        if (curState == (int)State.fly)
        {
            animator.Play("Bird_Fly");

            BirdHeadScan2 scanScript = birdHead.GetComponent<BirdHeadScan2>();
            bool scanDone = scanScript.scanDone;

            if (toTree2 == true)
            {
                incrementor += 0.01f;
                transform.position = Vector3.Slerp(oneToTwoRelCentre, twoToOneRelCentre, incrementor / duration);
                transform.position += centre1;
                rb2d.position = (transform.position).normalized;

                //float angle = Mathf.Atan2(treePos1.y, treePos1.x) * Mathf.Rad2Deg;

                // birdRotPos = rb2d.rotation;

                transform.Rotate(0, 0, 1 * 10 * Time.fixedDeltaTime);

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


                //duration = 2.0f;
                incrementor += 0.01f;
                transform.position = Vector3.Slerp(twoToThreeRelCentre, threeToTwoRelCentre, incrementor / duration);
                transform.position += centre2;
                rb2d.position = (transform.position).normalized;

                transform.Rotate(0, 0, 1 * 30 * Time.fixedDeltaTime);
                 

                if (Vector3.Distance(currentPos, treePos3) <= 0.1)
                {
                    toTree3 = false;
                    atTree3 = true;
                    scanScript.scanDone = false;
                    curState = (int)State.scan;

                }


            }

            if(toTree4 == true)
            {
                duration = 1.2f;
                incrementor += 0.01f;
                transform.position = Vector3.Slerp(threeToFourRelCentre, fourToThreeRelCentre, incrementor / duration);
                transform.position += centre3;
                rb2d.position = (transform.position).normalized;

                transform.Rotate(0, 0, 1 * 10 * Time.fixedDeltaTime);

                if (Vector3.Distance(currentPos, treePos4) <= 0.1)
                {
                    toTree4 = false;
                    atTree4 = true;
                    scanScript.scanDone = false;
                    curState = (int)State.scan;

                }

            }
            if (toTree1 == true)
            {
                duration = 1.2f;
                incrementor += 0.01f;
                transform.position = Vector3.Slerp(fourToOneRelCentre, oneToFourRelCentre, incrementor / duration);
                transform.position += centre4;
                rb2d.position = (transform.position).normalized;


                transform.Rotate(0, 0, 1 * 30 * Time.fixedDeltaTime);
        


                if (Vector3.Distance(currentPos, treePos1) <= 0.1)
                {
                    toTree1 = false;
                    atTree1 = true;
                    scanScript.scanDone = false;
                    curState = (int)State.scan;

                }


            }


        }

        //scan state
        if (curState == (int)State.scan)
        {
            animator.Play("BirdIdle");

            birdScan = true;
            //Slowly rotate enemy towards next tree

            Vector3 Pos01Trans = treePos1;
            Vector3 Pos02Trans = treePos2;
            Vector3 Pos03Trans = treePos3;
            Vector3 Pos04Trans = treePos4;

            float dx01 = Pos01Trans.x - transform.position.x;
            float dy01 = Pos01Trans.y - transform.position.y;

            float dx02 = Pos02Trans.x - transform.position.x;
            float dy02 = Pos02Trans.y - transform.position.y;

            float dx03 = Pos03Trans.x - transform.position.x;
            float dy03 = Pos03Trans.y - transform.position.y;

            float dx04 = Pos04Trans.x - transform.position.x;
            float dy04 = Pos04Trans.y - transform.position.y;

            float cx = transform.up.x;
            float cy = transform.up.y;


            float pos01Angle = Mathf.Atan2(dy01, dx01);
            float pos02Angle = Mathf.Atan2(dy02, dx02);
            float pos03Angle = Mathf.Atan2(dy03, dx03);
            float pos04Angle = Mathf.Atan2(dy04, dx04);

            float currentAngle = Mathf.Atan2(cy, cx);

            BirdHeadScan2 scanScript = birdHead.GetComponent<BirdHeadScan2>();
            bool scanDone = scanScript.scanDone;

            if (atTree2 == true && curState == (int)State.scan)
            {



                if (System.Math.Round(pos03Angle, 2) != System.Math.Round(currentAngle, 2))
                {
                    transform.Rotate(0, 0, 1 * 20 * Time.fixedDeltaTime);

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
                               

                if (System.Math.Round(pos04Angle, 2) != System.Math.Round(currentAngle, 2))
                {
                    transform.Rotate(0, 0, 1 * 20 * Time.fixedDeltaTime);

                }

                if (scanDone == true)
                {
                    incrementor = 0;
                    curState = (int)State.fly;
                    atTree3 = false;
                    toTree4 = true;
                    birdScan = false;
                }


            }

            if(atTree4 == true && curState == (int)State.scan)
            {

                if(System.Math.Round(pos01Angle,2) != System.Math.Round(currentAngle,2))
                {
                    transform.Rotate(0, 0, 1 * 20 * Time.fixedDeltaTime);
                }

                if(scanDone == true)
                {
                    incrementor = 0;
                    curState = (int)State.fly;
                    atTree4 = false;
                    toTree1 = true;
                    birdScan = false;
                }
            
            }

            if (atTree1 == true && curState == (int)State.scan)
            {

 

                if (System.Math.Round(pos02Angle, 2) != System.Math.Round(currentAngle, 2))
                {
                    transform.Rotate(0, 0, 1 * 25 * Time.fixedDeltaTime);

                }
                                               

                if (scanDone == true)
                {
                    incrementor = 0;
                    atTree1 = false;
                    curState = (int)State.fly;
                    birdScan = false;
                    toTree2 = true;
                    
                }

            }





        }





    }
}
