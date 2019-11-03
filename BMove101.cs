using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMove101 : MonoBehaviour
{

    private Rigidbody2D rb2d;
    public GameObject birdHead;
    private bool gotYerButt;
    private float birdRotPos;

    public bool birdScan;

    public GameObject Pos01;
    public GameObject Pos02;
    private float angle01;
    private float angle02;
    private float birdAngle;
    public int rotTurn;

    private bool scanDone;


    Animator animator;

    public int curState;

    private enum State
    {
        turn,
        scan
    }
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gotYerButt = false;
       
        curState = (int)State.turn;
        Vector3 Pos01Trans = Pos01.transform.position;
        Vector3 Pos02Trans = Pos02.transform.position;
        angle01 = Vector2.Angle(transform.position, Pos01Trans);
        angle02 = Vector2.Angle(transform.position, Pos02Trans);
        Debug.Log(Mathf.Round(angle01) + " angle01");
        Debug.Log(Mathf.Round(angle02) + " angle02");


        rotTurn = 1;

    }

    // Update is called once per frame
    void Update()
    {
        
        if(curState == (int)State.turn)
        {

            //birdAngle = Vector2.Angle(transform.up, transform.position);

            Vector3 Pos01Trans = Pos01.transform.position;
            Vector3 Pos02Trans = Pos02.transform.position;

            float dx01 = Pos01Trans.x - transform.position.x;
            float dy01 = Pos01Trans.y - transform.position.y;

            float dx02 = Pos02Trans.x - transform.position.x;
            float dy02 = Pos02Trans.y - transform.position.y;

            float cx = transform.up.x;
            float cy = transform.up.y;


            float pos01Angle = Mathf.Atan2(dy01, dx01);
            float pos02Angle = Mathf.Atan2(dy02, dx02);

            float currentAngle = Mathf.Atan2(cy, cx);

            Debug.Log(System.Math.Round(pos01Angle, 2) + " targetAngle01");
            Debug.Log(System.Math.Round(pos02Angle, 2) + " targetAngle02");
            Debug.Log(System.Math.Round(currentAngle,2) + " currentAngle");

            if (rotTurn == 1 || rotTurn == 3)
            {
                if (System.Math.Round(pos01Angle, 2) != System.Math.Round(currentAngle,2))
                {

                    transform.Rotate(0, 0, 1 * 20 * Time.fixedDeltaTime);

                }

                else
                {
                    curState = (int)State.scan;

                }

            }

            if(rotTurn == 2)
            {
                if (System.Math.Round(pos02Angle, 2) != System.Math.Round(currentAngle, 2))
                {

                    transform.Rotate(0, 0, -1 * 20 * Time.fixedDeltaTime);

                }

                else
                {
                    curState = (int)State.scan;

                }

            }

        }

        if(curState == (int)State.scan)
        {
            birdScan = true;

            BirdHeadScan scanScript = birdHead.GetComponent<BirdHeadScan>();
            scanDone = scanScript.scanDone;

            if (scanDone == true)
            {
                rotTurn += 1;
                curState = (int)State.turn;
                birdScan = false;
                scanScript.scanDone = false;
            }
                
        }


   


           


    }
}
