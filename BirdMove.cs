using UnityEngine;
using System.Collections;

public class BirdMove : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private float moveSpeed = 1f;
    private bool touchDown1;
    private bool touchDown2;

    private float incrementor = 0;

    //set of co-routines to use for Invoke
    void CheckTouch1()
    {

        touchDown1 = true;


    }

    void CheckTouch2()
    {

        touchDown2 = true;

    }

    void CheckTouch3()
    {

        touchDown1 = false;
        touchDown2 = false;

    }

    void IncremReset()
    {
        incrementor = 0;
    }

    private GameObject tree;
    private GameObject tree1;
    private GameObject tree2;

    public bool gotYerButt;

    void BirdyGo()
    {
        Vector3 currentPos = new Vector3();

        Vector3 treePos1 = tree.transform.position;

        Vector3 treePos2 = tree1.transform.position;

        Vector3 treePos3 = tree2.transform.position;

        //finding the centre for the arc between tree & tree1
        Vector3 centre1 = (treePos1 + treePos2) * 0.35f;
        centre1 -= new Vector3(0, -1, 0);
        Vector3 oneToTwoRelCentre = treePos1 - centre1;
        Vector3 twoToOneRelCentre = treePos2 - centre1;


        Vector3 centre2 = (treePos2 + treePos3) * 0.15f;
        centre2 -= new Vector3(0, -1, 0);
        Vector3 twoToThreeRelCentre = treePos2 - centre2;
        Vector3 threeToTwoRelCentre = treePos3 - centre2;

        Vector3 centre3 = (treePos3 + treePos1) * -0.35f;
        centre3 -= new Vector3(0, -1, 0);
        Vector3 threeToOneRelCentre = treePos3 - centre3;
        Vector3 oneToThreeRelCentre = treePos1 - centre3;

        currentPos = transform.position;

        if (touchDown1 == false)
        {
            incrementor += 0.01f;
            transform.position = Vector3.Slerp(oneToTwoRelCentre, twoToOneRelCentre, incrementor);
            transform.position += centre1;
            rb2d.velocity = (transform.position).normalized;

            if (currentPos == treePos2)
            {

                float angle = Mathf.Atan2(treePos1.y, treePos1.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                //Invoke("CheckTouch1", 2);
                touchDown1 = true;
                incrementor = 0;



            }
        }



        if (touchDown1 == true)
        {


            //rotate to face tree



            incrementor += 0.01f;
            transform.position = Vector3.Slerp(twoToThreeRelCentre, threeToTwoRelCentre, incrementor);
            transform.position += centre2;
            rb2d.velocity = (transform.position).normalized;


            if (currentPos == treePos3)
            {

                float angle = Mathf.Atan2(treePos2.y, treePos2.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                //Invoke("CheckTouch2", 2);
                touchDown2 = true;
                incrementor = 0;
            }


        }


        if (touchDown2 == true)
        {

            incrementor += 0.01f;
            transform.position = Vector3.Slerp(threeToOneRelCentre, oneToThreeRelCentre, incrementor);
            transform.position += centre3;
            rb2d.velocity = (transform.position).normalized;


            if (currentPos == treePos1)
            {


                float angle = Mathf.Atan2(treePos3.y, treePos3.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                //Invoke("CheckTouch3", 2);
                touchDown1 = false;
                touchDown2 = false;
                incrementor = 0;


            }



        }

    }

    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        touchDown1 = false;
        touchDown2 = false;
        gotYerButt = false;
        tree = GameObject.Find("Tree");
        tree1 = GameObject.Find("Tree (1)");
        tree2 = GameObject.Find("Tree (2)");


    }

    void Update()
    {


        if (gotYerButt == false)
            BirdyGo();





    }
}
