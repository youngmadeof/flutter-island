using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMove104_2 : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public bool toTree1;
    public bool toTree2;
    public bool atTree1;
    public bool atTree2;
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
        atTree1 = false;
        atTree2 = false;
        toTree2 = true;
        gotYerButt = false;
        BirdHeadScan birdHead = GetComponent<BirdHeadScan>();
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

        //finding the centre for the arc between tree & tree1
        Vector3 centre1 = (treePos1 + treePos2) * 0.5f;
        centre1 -= new Vector3(0, -1, 0);
        Vector3 centre2 = (treePos1 + treePos2) * 0.25f;
        centre2 -= new Vector3(0, 1, 0);
        Vector3 oneToTwoRelCentre1 = treePos1 - centre1;
        Vector3 twoToOneRelCentre1 = treePos2 - centre1;
        Vector3 oneToTwoRelCentre2 = treePos1 - centre2;
        Vector3 twoToOneRelCentre2 = treePos2 - centre2;

        currentPos = transform.position;

        duration = 1.75f;

        //fly state
        if (curState == (int)State.fly)
        {
            animator.Play("Bird_Fly");

            BirdHeadScan2 scanScript = birdHead.GetComponent<BirdHeadScan2>();
            bool scanDone = scanScript.scanDone;

            if (toTree2 == true)
            {
                incrementor += 0.01f;
                transform.position = Vector3.Slerp(oneToTwoRelCentre1, twoToOneRelCentre1, incrementor / duration);
                transform.position += centre1;
                rb2d.position = (transform.position).normalized;


                transform.Rotate(0, 0, 1 * 15 * Time.fixedDeltaTime);

                if (Vector3.Distance(currentPos, treePos2) <= 0.1)
                {
                    toTree2 = false;
                    atTree2 = true;
                    curState = (int)State.scan;
                    scanScript.scanDone = false;

                }

            }

            if (toTree1 == true && curState == (int)State.fly)
            {
                incrementor += 0.01f;
                transform.position = Vector3.Slerp(twoToOneRelCentre2, oneToTwoRelCentre2, incrementor / duration);
                transform.position += centre2;
                rb2d.position = (transform.position).normalized;


                transform.Rotate(0, 0, 1 * 15 * Time.fixedDeltaTime);

                if (Vector3.Distance(currentPos, treePos1) <= 0.1)
                {
                    toTree1 = false;
                    atTree1 = true;
                    curState = (int)State.scan;
                    scanScript.scanDone = false;
                }

            }








        }
        //scan state
        if (curState == (int)State.scan)
        {
            animator.Play("BirdIdle");

            birdScan = true;
            //Slowly rotate enemy towards next tree

            float dx01 = treePos1.x - transform.position.x;
            float dy01 = treePos1.y - transform.position.y;

            float dx02 = treePos2.x - transform.position.x;
            float dy02 = treePos2.y - transform.position.y;

            float cx = transform.up.x;
            float cy = transform.up.y;

            float treeAngle01 = Mathf.Atan2(dy01, dx01);
            float treeAngle02 = Mathf.Atan2(dy02, dx02);
            float currentAngle = Mathf.Atan2(cy, cx);

            BirdHeadScan2 scanScript = birdHead.GetComponent<BirdHeadScan2>();
            bool scanDone = scanScript.scanDone;

            if (atTree1 == true && curState == (int)State.scan)
            {
                
                if (System.Math.Round(treeAngle02, 2) != System.Math.Round(currentAngle, 2))
                {
                    transform.Rotate(0, 0, 1 * 25 * Time.fixedDeltaTime);

                }

                if (scanDone == true)
                {
                    incrementor = 0;
                    atTree1 = false;
                    curState = (int)State.fly;
                    toTree2 = true;
                    birdScan = false;

                }
                



            }



            if (atTree2 == true && curState == (int)State.scan)
            {


                if (System.Math.Round(treeAngle01, 2) != System.Math.Round(currentAngle, 2))
                {
                    transform.Rotate(0, 0, 1 * 25 * Time.fixedDeltaTime);

                }


                if (scanDone == true)
                {
                    incrementor = 0;
                    curState = (int)State.fly;
                    atTree2 = false;
                    toTree1 = true;
                    birdScan = false;
                }

            }




        }





    }

}
