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

    private GameObject bHead;
    private Rigidbody2D headRB;
    private float headRot;

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
        waitDone = false;
        Debug.Log("Start waitDone " + waitDone);
        birdFly = true;
        headRot = 20.0f;

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

 
        if (touchDown1 == false && touchDown2 != true)
        {


            if(birdFly == true)
            {

                animator.Play("Bird_Fly");
                Debug.Log("anim playing");

            }

            
            incrementor += 0.01f;
            transform.position = Vector3.Slerp(oneToTwoRelCentre, twoToOneRelCentre, incrementor / duration);
            transform.position += centre1;
            rb2d.velocity = (transform.position).normalized;

            if (currentPos == treePos2 && birdFly == true)
            {
                animator.Play("BirdIdle");  
                //Debug.Log(waitDone);
                birdFly = false;
                Debug.Log("birdfly " + birdFly);
                //StartCoroutine(WaitForAnim());
                BirdScan();
            
            }

            if (waitDone == true)
            {
                float angle = Mathf.Atan2(treePos1.y, treePos1.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                incrementor = 0;
                touchDown1 = true;
                waitDone = false;
                Debug.Log("wait done wrong");
                birdFly = true;
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


            if (currentPos == treePos3 && birdFly == true)
            {
                animator.Play("BirdIdle");
                birdFly = false;
                StartCoroutine(WaitForAnim());
                                                          
            }

            if (waitDone == true)
            {
                float angle = Mathf.Atan2(treePos2.y, treePos2.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                incrementor = 0;
                touchDown2 = true;
                touchDown1 = false;
                waitDone = false;
                //Debug.Log("wait done wrong");
                birdFly = true;
            }


        }


        if (touchDown2 == true)
        {



            if (birdFly == true)
            {

                animator.Play("Bird_Fly");

            }

            duration = 1.2f;
            incrementor += 0.01f;
            transform.position = Vector3.Slerp(threeToOneRelCentre, oneToThreeRelCentre, incrementor / duration);
            transform.position += centre3;
            rb2d.velocity = (transform.position).normalized;
            

            if (currentPos == treePos1 && birdFly == true)
            {
                animator.Play("BirdIdle");
                
                birdFly = false;
                StartCoroutine(WaitForAnim());
                Debug.Log("touchdown 2" + touchDown2);
                Debug.Log("waitDone " + waitDone);

            }


            if (waitDone == true)
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

   
    public IEnumerator WaitForAnim()
    {

            yield return new WaitForSeconds(4);
            waitDone = true;
            Debug.Log(waitDone);
        

    }

    public void BirdScan()
    {
        bHead = GameObject.Find("Bird_Black_Head");
        headRB = bHead.GetComponent<Rigidbody2D>();

        for(int i = 0; i<2; i++)
        {
            for (int j = 0; j < 2; j++)
            {

                headRot = Mathf.Atan2(4, 5) * Mathf.Rad2Deg;
                headRB.transform.rotation = Quaternion.AngleAxis(headRot, Vector3.forward);
               

              
            }

          
        }

        waitDone = true;

    }

}
