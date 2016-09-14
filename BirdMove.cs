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
        Debug.Log(touchDown1);
    }

    void CheckTouch2()
    {
        touchDown2 = true;
        Debug.Log(touchDown2);
    }

    void CheckTouch3()
    {
        touchDown1 = false;
        Debug.Log(touchDown1);

    }

    private GameObject tree;
    private GameObject tree1;
    private GameObject tree2;

    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        touchDown1 = false;
        Debug.Log(touchDown1);
        touchDown2 = false;
        Debug.Log(touchDown2);

        tree = GameObject.Find("Tree");
        tree1 = GameObject.Find("Tree (1)");
        tree2 = GameObject.Find("Tree (2)");

    }

    void FixedUpdate()
    {


        Vector2 currentPos = new Vector2();

        Vector2 treePos1 = tree.transform.position;

        Vector2 treePos2 = tree1.transform.position;

        Vector2 treePos3 = tree2.transform.position;

        currentPos = transform.position;




        if (touchDown1 == false)
        {
            Debug.Log(touchDown1);
            Vector2 dir1 = (treePos1 - currentPos);
            rb2d.velocity += (dir1) * moveSpeed / Time.deltaTime;
            rb2d.velocity = (dir1);

            Debug.Log(currentPos);
            Debug.Log(treePos1);
            if (Vector2.Distance(currentPos, treePos1) <= 0.1f)
            {
                Invoke("CheckTouch1", 2);
                float angle = Mathf.Atan2(treePos3.y, treePos3.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                Debug.Log(angle);
                //rb2d.MoveRotation(60);

            }


        }



        if (touchDown1 == true)
        {
            Vector2 dir2 = (treePos2 - currentPos);
            rb2d.velocity += (dir2).normalized * moveSpeed;
            rb2d.velocity = dir2;
            Debug.Log(currentPos);

            if (Vector2.Distance(currentPos, treePos2) < 0.1f)
            {
                //rb2d.MoveRotation(-70);
                Invoke("CheckTouch2", 2);
                float angle = Mathf.Atan2(treePos1.y, treePos1.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            }


        }


        if (touchDown2 == true)
        {
            Vector2 dir3 = (treePos3 - currentPos);
            rb2d.velocity += (dir3).normalized * moveSpeed;
            rb2d.velocity = dir3;
            Debug.Log(currentPos);

            if (Vector2.Distance(currentPos, treePos3) < 0.1f)
            {

                //rb2d.MoveRotation(170);
                Invoke("CheckTouch3", 0);
                float angle = Mathf.Atan2(treePos2.y, treePos2.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            }


        }


    }
}
