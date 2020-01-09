using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorp_Behaviour : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator animator;

    public GameObject sector1;
    public GameObject sector2;
    public GameObject sector3;
    public GameObject sect0101;
    public GameObject sect0102;
    public GameObject sect0103;
    public GameObject sect0201;
    public GameObject sect0202;
    public GameObject sect0203;
    public GameObject sect0301;
    public GameObject sect0302;
    public GameObject sect0303;

    

    private Vector3 pos0101;
    private Vector3 pos0102;
    private Vector3 pos0103;
    private Vector3 pos0201;
    private Vector3 pos0202;
    private Vector3 pos0203;
    private Vector3 pos0301;
    private Vector3 pos0302;
    private Vector3 pos0303;

    private Vector3 currentPos;
    private Vector3 retPos;

    public bool toPos0101;
    public bool toPos0102;
    public bool toPos0103;
    public bool toPos0201;
    public bool toPos0202;
    public bool toPos0203;
    public bool toPos0301;
    public bool toPos0302;
    public bool toPos0303;

    public bool boolSect1;
    public bool boolSect2;
    public bool boolSect3;

    private bool boolRestRot;

    private float speed;
    public int intSect;

    public float distJ;
    public float distL;
    public int index;

    private float floatNearest;

    private bool timeCapt;
    private float timeStart;

    public GameObject butt;

    List<float> nearDistArray = new List<float>();

    float t;

    public int curMainState;
    public int curSubState;

    public enum MainState
    {
        idle,
        agro,
        ret,
        rest
    }

    public enum SubState
    {
        inSect1,
        inSect2,
        inSect3
    }

    //TODO: This is on the wrong object. Should be attached to each sector
    /*public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == sector1)
        {
            curSubState = (int)SubState.inSect1;
            intSect = 1;
        }

        if(collision.gameObject == sector2)
        {
            curSubState = (int)SubState.inSect2;
            intSect = 2;
        }

        if(collision.gameObject == sector3)
        {
            curSubState = (int)SubState.inSect3;
            intSect = 3;
        }
    }*/

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        speed = 0.02f;
        pos0101 = sect0101.transform.position;
        pos0102 = sect0102.transform.position;
        pos0103 = sect0103.transform.position;
        pos0201 = sect0201.transform.position;
        pos0202 = sect0202.transform.position;
        pos0203 = sect0203.transform.position;
        pos0301 = sect0301.transform.position;
        pos0302 = sect0302.transform.position;
        pos0303 = sect0303.transform.position;
        toPos0101 = true;
        intSect = 1;
        boolSect1 = true;
        boolRestRot = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SectOneCol sectOneScript = sector1.GetComponent<SectOneCol>();
        boolSect1 = sectOneScript.boolSect;
        SectTwoCol sectTwoScript = sector2.GetComponent<SectTwoCol>();
        boolSect2 = sectTwoScript.boolSect;
        SectThreeCol sectThreeScript = sector3.GetComponent<SectThreeCol>();
        boolSect3 = sectThreeScript.boolSect;

        
        if(boolSect1 == true)
        {
            curSubState = (int)SubState.inSect1;
        }

        else if (boolSect2 == true)
        {
            curSubState = (int)SubState.inSect2;
        }

        else if (boolSect3 == true)
        {
            curSubState = (int)SubState.inSect3;
        }
        

        currentPos = transform.position;

        float cx = transform.up.x;
        float cy = transform.up.y;

        float currentAngle = Mathf.Atan2(cy, cx);



        if(curMainState == (int)MainState.idle)
        {
            animator.SetBool("Agro", false);
            animator.SetBool("Rest", false);

            //speed = 0.02f;

            if (curSubState == (int)SubState.inSect1)
            {


                float dx0101 = pos0101.x - transform.position.x;
                float dy0101 = pos0101.y - transform.position.y;
                float dx0102 = pos0102.x - transform.position.x;
                float dy0102 = pos0102.y - transform.position.y;
                float dx0103 = pos0103.x - transform.position.x;
                float dy0103 = pos0103.y - transform.position.y;


                float pos01Angle = Mathf.Atan2(dy0101, dx0101);
                float pos02Angle = Mathf.Atan2(dy0102, dx0102);
                float pos03Angle = Mathf.Atan2(dy0103, dx0103);



                if (toPos0101 == true)
                {


                    transform.position += (pos0101 - currentPos).normalized * speed;

                    if (Vector3.Distance(currentPos, pos0101) <= 0.1f)
                    {

                        transform.Rotate(0, 0, 1 * 37 * Time.fixedDeltaTime);

                        animator.SetBool("Rest", true);
                    }
                        
                    

                    if (System.Math.Round(currentAngle,2) == System.Math.Round(pos02Angle,2))
                    {

                        animator.SetBool("Rest", false);
                        toPos0101 = false;
                        toPos0102 = true;
                        t = 0;


                    }

                }

                if (toPos0102 == true)
                {
                    
                    transform.position += (pos0102 - currentPos).normalized * speed;

                    //transform.Rotate(0, 0, 1 * 20 * Time.fixedDeltaTime);

                    if (Vector3.Distance(currentPos, pos0102) <= 0.1f)
                    {
                        transform.Rotate(0, 0, 1 * 37 * Time.fixedDeltaTime);

                        animator.SetBool("Rest", true);
                    }


                    if (System.Math.Round(currentAngle, 2) == System.Math.Round(pos03Angle, 2))
                    {
                        animator.SetBool("Rest", false);

                        toPos0102 = false;
                        toPos0103 = true;
                        t = 0;
                    }

                }

                if (toPos0103 == true)
                {
                   
                    transform.position += (pos0103 - currentPos).normalized * speed;

                    if (Vector3.Distance(currentPos, pos0103) <= 0.1f)
                    {
                        transform.Rotate(0, 0, 1 * 37 * Time.fixedDeltaTime);

                        animator.SetBool("Rest", true);
                    }


                    if (System.Math.Round(currentAngle, 2) == System.Math.Round(pos01Angle, 2))
                    {
                        animator.SetBool("Rest", false);

                        toPos0103 = false;
                        toPos0101 = true;
                        t = 0;
                    }
       
                }



            }

            if (curSubState == (int)SubState.inSect2)
            {
                float dx0201 = pos0201.x - transform.position.x;
                float dy0201 = pos0201.y - transform.position.y;
                float dx0202 = pos0202.x - transform.position.x;
                float dy0202 = pos0202.y - transform.position.y;
                float dx0203 = pos0203.x - transform.position.x;
                float dy0203 = pos0203.y - transform.position.y;


                float pos01Angle = Mathf.Atan2(dy0201, dx0201);
                float pos02Angle = Mathf.Atan2(dy0202, dx0202);
                float pos03Angle = Mathf.Atan2(dy0203, dx0203);

                if (toPos0201 == true)
                {


                    transform.position += (pos0201 - currentPos).normalized * speed;


                    if (Vector3.Distance(currentPos, pos0201) <= 0.1f)
                    {
                        transform.Rotate(0, 0, -1 * 37 * Time.fixedDeltaTime);

                        animator.SetBool("Rest", true);
                    }



                    if (System.Math.Round(currentAngle, 2) == System.Math.Round(pos02Angle, 2))
                    {
                        animator.SetBool("Rest", false);

                        toPos0201 = false;
                        toPos0202 = true;
                        t = 0;


                    }

                }

                if (toPos0202 == true)
                {

                    transform.position += (pos0202 - currentPos).normalized * speed;

                    //transform.Rotate(0, 0, 1 * 20 * Time.fixedDeltaTime);

                    if (Vector3.Distance(currentPos, pos0202) <= 0.1f)
                    {
                        transform.Rotate(0, 0, -1 * 37 * Time.fixedDeltaTime);

                        animator.SetBool("Rest", true);
                    }


                    if (System.Math.Round(currentAngle, 2) == System.Math.Round(pos03Angle, 2))
                    {
                        animator.SetBool("Rest", false);

                        toPos0202 = false;
                        toPos0203 = true;
                        t = 0;
                    }

                }

                if (toPos0203 == true)
                {

                    transform.position += (pos0203 - currentPos).normalized * speed;

                    if (Vector3.Distance(currentPos, pos0203) <= 0.5f)
                    {
                        transform.Rotate(0, 0, 1 * -37 * Time.fixedDeltaTime);

                        animator.SetBool("Rest", true);
                    }


                    if (System.Math.Round(currentAngle, 2) == System.Math.Round(pos01Angle, 2))
                    {
                        animator.SetBool("Rest", false);

                        toPos0203 = false;
                        toPos0201 = true;
                        t = 0;
                    }
                }
            }

            if(curSubState == (int)SubState.inSect3)
            {
                float dx0301 = pos0301.x - transform.position.x;
                float dy0301 = pos0301.y - transform.position.y;
                float dx0302 = pos0302.x - transform.position.x;
                float dy0302 = pos0302.y - transform.position.y;
                float dx0303 = pos0303.x - transform.position.x;
                float dy0303 = pos0303.y - transform.position.y;


                float pos01Angle = Mathf.Atan2(dy0301, dx0301);
                float pos02Angle = Mathf.Atan2(dy0302, dx0302);
                float pos03Angle = Mathf.Atan2(dy0303, dx0303);

                if (toPos0301 == true)
                {


                    transform.position += (pos0301 - currentPos).normalized * speed;


                    if (Vector3.Distance(currentPos, pos0301) <= 0.1f)
                    {
                        transform.Rotate(0, 0, 1 * 37 * Time.fixedDeltaTime);

                        animator.SetBool("Rest", true);
                    }



                    if (System.Math.Round(currentAngle, 2) == System.Math.Round(pos02Angle, 2))
                    {
                        animator.SetBool("Rest", false);

                        toPos0301 = false;
                        toPos0302 = true;
                        t = 0;


                    }

                }

                if (toPos0302 == true)
                {

                    transform.position += (pos0302 - currentPos).normalized * speed;

                    //transform.Rotate(0, 0, 1 * 20 * Time.fixedDeltaTime);

                    if (Vector3.Distance(currentPos, pos0302) <= 0.1f)
                    {
                        transform.Rotate(0, 0, 1 * 37 * Time.fixedDeltaTime);

                        animator.SetBool("Rest", true);
                    }


                    if (System.Math.Round(currentAngle, 2) == System.Math.Round(pos03Angle, 2))
                    {
                        animator.SetBool("Rest", false);

                        toPos0302 = false;
                        toPos0303 = true;
                        t = 0;
                    }

                }

                if (toPos0303 == true)
                {

                    transform.position += (pos0303 - currentPos).normalized * speed;

                    if (Vector3.Distance(currentPos, pos0303) <= 0.5f)
                    {
                        transform.Rotate(0, 0, 1 * 37 * Time.fixedDeltaTime);

                        animator.SetBool("Rest", true);
                    }


                    if (System.Math.Round(currentAngle, 2) == System.Math.Round(pos01Angle, 2))
                    {
                        animator.SetBool("Rest", false);

                        toPos0303 = false;
                        toPos0301 = true;
                        t = 0;
                    }
                }
            }
        }
  
        if(curMainState == (int)MainState.agro)
        {
            animator.SetBool("Rest", false);
            animator.SetBool("Agro", true);

            float bx = butt.transform.position.x - transform.position.x;
            float by = butt.transform.position.x - transform.position.y;

            float buttAngle = Mathf.Atan2(by, bx);

            speed = 0.045f;
            transform.position += (butt.transform.position - currentPos).normalized * speed;

            Vector3 relativePos = currentPos - butt.transform.position;

            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.forward);
            rotation.x = 0.0f;
            rotation.y = 0.0f;
            transform.rotation = rotation;

            timeCapt = true;

  

        }

        if(curMainState == (int)MainState.ret)
        {
            speed = 0.02f;

            animator.SetBool("Agro", false);
            animator.SetBool("Rest", false);


            transform.position += (retPos - currentPos).normalized * 0.02f;

            Debug.Log("Return");


            if (Vector3.Distance(currentPos, retPos) <= 0.3f)
            {
                if (index == 0)
                {
                    toPos0102 = true;
                }

                else if (index == 1)
                {
                    toPos0103 = true;
                }

                else if (index == 2)
                {
                    toPos0101 = true;
                }

                else if (index == 3)
                {
                    toPos0202 = true;
                }

                else if (index == 4)
                {
                    toPos0203 = true;
                }

                else if (index == 5)
                {
                    toPos0201 = true;
                }

                else if (index == 6)
                {
                    toPos0302 = true;
                }

                else if(index == 7)
                {
                    toPos0303 = true;
                }

                else if (index == 8)
                {
                    toPos0301 = true;
                }
                curMainState = (int)MainState.idle;
            }

           
        }

        if(curMainState == (int)MainState.rest)
        {
            animator.SetBool("Agro", false);
            animator.SetBool("Rest", true);

            float dxRet = retPos.x - transform.position.x;
            float dyRet = retPos.y - transform.position.y;

            float posRetAngle = Mathf.Atan2(dyRet, dxRet);

            if (timeCapt == true)
            {
                timeStart = Time.fixedTime;
                timeCapt = false;
               
            }

            

            if(Mathf.Round(timeStart) + 3 == Mathf.Round(Time.fixedTime))
            {                
                boolRestRot = true;
            }

            if(boolRestRot == true)
            {
                transform.Rotate(0, 0, -1 * 37 * Time.fixedDeltaTime);

                if (System.Math.Round(currentAngle, 2) == System.Math.Round(posRetAngle, 2))
                {
                    curMainState = (int)MainState.ret;
                    boolRestRot = false;
                }

            }

        }
       
    }

    public void GetNextPos()
    {
        toPos0101 = false;
        toPos0102 = false;
        toPos0103 = false;
        toPos0201 = false;
        toPos0202 = false;
        toPos0203 = false;
        toPos0301 = false;
        toPos0302 = false;
        toPos0303 = false;

        Vector3[] posArray = new[] { pos0101, pos0102, pos0103, pos0201, pos0202, pos0203, pos0301, pos0302, pos0303 };


        for (int i = 0; i < posArray.Length; i++)
        {
            floatNearest = Vector3.Distance(currentPos, posArray[i]);

            nearDistArray.Add(floatNearest);            

            //Debug.Log(floatNearest + " distance " + posArray[i] + " | " + i);

        }


        float minVal = nearDistArray[0];

        for (int j = 1; j < nearDistArray.Count; j++)
        {
            if(nearDistArray[j]<minVal)
            {
                minVal = nearDistArray[j];
                index = j;
            }
        }

        //Debug.Log(posArray.Length + " posArray Length");

        for(int k = 0; k < posArray.Length; k++)
        {

            Debug.Log(posArray[k] + " posArray " + k);
            if(k == index)
            {
                retPos = posArray[k];
            }
        }

    
        //Debug.Log(minVal);
        //Debug.Log(index);


        nearDistArray.Clear();

    }


    

}
