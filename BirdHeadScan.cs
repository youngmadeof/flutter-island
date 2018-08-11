using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdHeadScan : MonoBehaviour {


    private Rigidbody2D headRB;
    private float headPos;
    private bool rotateDoneRight;
    private bool rotateDoneLeft;

    private GameObject bird;
    private GameObject cone;

    private Animator animator;

    private bool extractDone;
    private bool retractDone;



    // Use this for initialization
    void Start ()

    {
        //headPos = 0f;
        rotateDoneRight = false;
        rotateDoneLeft = false;

        bird = GameObject.Find("Bird");

        cone = GameObject.Find("ViewCone");
        cone.SetActive(false);
        extractDone = false;



    }
	
	// Update is called once per frame
	void Update ()

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
            }
            



            if (rotateDoneRight == false)
            {

                headRB.transform.Rotate(0, 0, -1 * 35 * Time.fixedDeltaTime);
                headPos = headRB.transform.localEulerAngles.z;
                Debug.Log("BirdHead " + headPos);

                if (headPos <= 280.0f)
                {
                    rotateDoneRight = true;
                    Debug.Log("rotRight " + rotateDoneRight);

                }



            }

            if (rotateDoneRight == true && rotateDoneLeft == false)
            {
                headRB.transform.Rotate(0, 0, 1 * 35 * Time.fixedDeltaTime);
                headPos = headRB.transform.localEulerAngles.z;
                Debug.Log("BirdHead " + headPos);

                if (headPos <= 280.0f && headPos >= 50.0f)
                {
                    rotateDoneLeft = true;

                    Debug.Log("rotLeft " + rotateDoneLeft);
                }

            }

            if(rotateDoneRight == true && rotateDoneLeft == true)
            {

                headRB.transform.Rotate(0, 0, -1 * 35 * Time.fixedDeltaTime);
                headPos = headRB.transform.localEulerAngles.z;
                Debug.Log("BirdHead " + headPos);

                if(headPos <= 14f)
                {
                    
                    animator.Play("BirdViewConeRetract");

                    retractDone = true;

                }

            }
        }

                



    }
}
