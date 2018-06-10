using UnityEngine;
using System.Collections;

public class BirdMove : MonoBehaviour {

    private Rigidbody2D rb2d;
    private bool touchDown1;
    private bool touchDown2;

    private float incrementor = 0;

    private float duration;
    
        
    private GameObject tree;
    private GameObject tree1;
    private GameObject tree2;

    private bool gotYerButt;

    public bool waitDone;
    public bool resetAnim;
    public bool birdSit;
    private bool birdFly;

    Animator animator;

    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchDown1 = false;
        touchDown2 = false;
        gotYerButt = false;
        tree = GameObject.Find("Tree");
        tree1 = GameObject.Find("Tree (1)");
        tree2 = GameObject.Find("Tree (2)");
        //waitDone = false;
        birdFly = true;

    }

    void Update()
    {


        if (gotYerButt == false)
        {
            BirdyGo();
        }
            
        
    }

    void BirdyGo()
    {
        Vector3 currentPos = new Vector3();

        Vector3 treePos1 = tree.transform.position;

        Vector3 treePos2 = tree1.transform.position;

        Vector3 treePos3 = tree2.transform.position;

        //finding the centre for the arc between tree & tree1
        Vector3 centre1 = (treePos1 + treePos2) * 0.05f;
        centre1 -= new Vector3(0, -1, 0);
        Vector3 oneToTwoRelCentre = treePos1 - centre1;
        Vector3 twoToOneRelCentre = treePos2 - centre1;


        Vector3 centre2 = (treePos2 + treePos3) * 0.15f;
        centre2 -= new Vector3(0, -1, 0);
        Vector3 twoToThreeRelCentre = treePos2 - centre2;
        Vector3 threeToTwoRelCentre = treePos3 - centre2;

        Vector3 centre3 = (treePos3 + treePos1) * -1f;
        centre3 -= new Vector3(0, -1, 0);
        Vector3 threeToOneRelCentre = treePos3 - centre3;
        Vector3 oneToThreeRelCentre = treePos1 - centre3; 
        
        currentPos = transform.position;

        duration = 1.5f;

 
        if (touchDown1 == false)
        {


            if(birdFly == true)
            {

                animator.Play("Bird_Fly");

            }

            
            incrementor += 0.01f;
            transform.position = Vector3.Slerp(oneToTwoRelCentre, twoToOneRelCentre, incrementor / duration);
            transform.position += centre1;
            rb2d.velocity = (transform.position).normalized;

            if (currentPos == treePos2)
            {

                //Debug.Log(waitDone);
                birdFly = false;
                StartCoroutine(WaitForAnim());
                //Debug.Log(waitDone);


                if (waitDone == true)
                {
                    float angle = Mathf.Atan2(treePos1.y, treePos1.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                    incrementor = 0;
                    touchDown1 = true;
                    waitDone = false;
                    birdFly = true;
                 }


            }
        }

             
        


        if (touchDown1 == true)
        {
            //waitDone = false;

            if (birdFly == true)
            {

                animator.Play("Bird_Fly");

            }

            incrementor += 0.01f;
            transform.position = Vector3.Slerp(twoToThreeRelCentre, threeToTwoRelCentre, incrementor / duration);
            transform.position += centre2;
            rb2d.velocity = (transform.position).normalized;


            if (currentPos == treePos3)
            {

                //Debug.Log(waitDone);
                birdFly = false;
                StartCoroutine(WaitForAnim());
                //Debug.Log(waitDone);

                if(waitDone == true)
                {
                    float angle = Mathf.Atan2(treePos2.y, treePos2.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                    incrementor = 0;
                    touchDown2 = true;
                    waitDone = false;
                    birdFly = true;
                }


                                                          
            }

            
        }


        if (touchDown2 == true)
        {

            //waitDone = false;

            if (birdFly == true)
            {

                animator.Play("Bird_Fly");

            }

            duration = 1.2f;
            incrementor += 0.01f;
            transform.position = Vector3.Slerp(threeToOneRelCentre, oneToThreeRelCentre, incrementor/duration);
            transform.position += centre3;
            rb2d.velocity = (transform.position).normalized;


            if (currentPos == treePos1)
            {

                //Debug.Log(waitDone);
                birdFly = false;
                StartCoroutine(WaitForAnim());
                //Debug.Log(waitDone);

                if(waitDone == true)
                {
                    float angle = Mathf.Atan2(treePos3.y, treePos3.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                    incrementor = 0;
                    touchDown1 = false;
                    touchDown2 = false;
                    waitDone = false;
                    birdFly = true;
                }


                                                                     
            }

            

        }

    }


    IEnumerator WaitForAnim()
    {
        waitDone = false;
        if(waitDone == false)
        {
            animator.Play("BirdIdle");
            yield return new WaitForSeconds(5);
            waitDone = true;
            Debug.Log(waitDone);
        }

    }


}
