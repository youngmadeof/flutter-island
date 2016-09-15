using UnityEngine;
using System.Collections;

public class BirdMove : MonoBehaviour
{

    private Rigidbody2D rb2d;
    public float moveSpeed;
    private bool touchDown1;
    private bool touchDown2;

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

    private GameObject tree;
    private GameObject tree1;
    private GameObject tree2;

    public bool gotYerButt;

    void BirdyGo()
    {
        Vector2 currentPos = new Vector2();

        Vector2 treePos1 = tree.transform.position;

        Vector2 treePos2 = tree1.transform.position;

        Vector2 treePos3 = tree2.transform.position;

        currentPos = transform.position;

        if (touchDown1 == false)
        {
            Debug.Log("first loop");
            Vector2 dir1 = (treePos2 - currentPos);
            rb2d.velocity += (dir1) * moveSpeed / Time.deltaTime;
            rb2d.velocity = (dir1);

            if (Vector2.Distance(currentPos, treePos2) <= 0.1f)
            {
                float angle = Mathf.Atan2(treePos1.y, treePos1.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                Debug.Log(angle);

                Invoke("CheckTouch1", 2);

            }


        }


        if (touchDown1 == true)
        {
            Debug.Log("second loop");
            Vector2 dir2 = (treePos3 - currentPos);
            rb2d.velocity += (dir2).normalized * moveSpeed;
            rb2d.velocity = dir2;


            if (Vector2.Distance(currentPos, treePos3) < 0.1f)
            {
                //rb2d.MoveRotation(-70);

                float angle = Mathf.Atan2(treePos2.y, treePos2.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                Invoke("CheckTouch2", 2);
            }




        }


        if (touchDown2 == true)
        {
            Debug.Log("third loop");
            Vector2 dir3 = (treePos1 - currentPos);
            rb2d.velocity += (dir3).normalized * moveSpeed;
            rb2d.velocity = dir3;


            if (Vector2.Distance(currentPos, treePos1) < 0.1f)
            {

                //rb2d.MoveRotation(170);

                float angle = Mathf.Atan2(treePos3.y, treePos3.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                Debug.Log("third loop end");

                Invoke("CheckTouch3", 2);
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

    void FixedUpdate()
    {


        if (gotYerButt == false)
            BirdyGo();





    }
}
