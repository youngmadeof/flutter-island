using UnityEngine;
using System.Collections;

public class BirdMove : MonoBehaviour {

    private Rigidbody2D rb2d;
    public float moveSpeed;
    public float rotateSpeed;
    private bool touchDown1;
    private bool touchDown2;
    private bool touchDown3;

    void CheckTouch1() {
        touchDown1 = true;
        Debug.Log(touchDown1);
    }

    void CheckTouch2() {
        touchDown2 = true;
        Debug.Log(touchDown2);
    }

    void CheckTouch3() {
        touchDown1 = false;
        
    }

	void Start () {

        rb2d = GetComponent<Rigidbody2D>();
        moveSpeed = 0.1f;
        rotateSpeed = 0.1f;
        touchDown1 = false;
        Debug.Log(touchDown1);
        touchDown2 = false;
        Debug.Log(touchDown2);
        touchDown3 = false;
        Debug.Log(touchDown3);



    }

    void FixedUpdate () {

        Vector2 currentPos  = new Vector2();

        Vector2 treePos1 = new Vector2(2.22f, -2.2f);

        Vector2 treePos2 = new Vector2(-4.93f, 1.13f);

        Vector2 treePos3 = new Vector2(3.65f, 2.75f);

        currentPos = transform.position;


        
        if (touchDown1 == false){
            Debug.Log(touchDown3);
            Vector2 dir1 = (treePos1 - currentPos);
            rb2d.velocity += (dir1).normalized * moveSpeed / Time.deltaTime;
            rb2d.velocity = (dir1);

            Debug.Log(currentPos);
            Debug.Log(treePos1);
            if (Vector2.Distance(currentPos, treePos1) <=0.1f){
                rb2d.MoveRotation(60);
                Invoke("CheckTouch1", 2);
            }

            
        }

        

        if (touchDown1 == true){
            Vector2 dir2 = (treePos2 - currentPos);
            rb2d.velocity += (dir2).normalized * moveSpeed;
            rb2d.velocity = dir2;
            Debug.Log(currentPos);

            if (Vector2.Distance(currentPos, treePos2) < 0.1f){
                rb2d.MoveRotation(-70);
                Invoke("CheckTouch2", 2);

            }



        }

                     
        if (touchDown2 == true){
            Vector2 dir3 = (treePos3 - currentPos);
            rb2d.velocity += (dir3).normalized * moveSpeed;
            rb2d.velocity = dir3;
            Debug.Log(currentPos);

            if (Vector2.Distance(currentPos, treePos3) < 0.1f){
                rb2d.MoveRotation(166);
                Invoke("CheckTouch3", 2);

            }


        }











    }
}
