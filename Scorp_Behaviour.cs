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

    public GameObject cact01;
    public GameObject cact02;

    private int directionDistance;

    private Vector3 pos0101;
    //private Vector3 locPos0101;
    private Vector3 pos0102;
    private Vector3 pos0103;
    private Vector3 pos0201;
    private Vector3 pos0202;
    private Vector3 pos0203;
    private Vector3 pos0301;
    private Vector3 pos0302;
    private Vector3 pos0303;

    public int tripCount;

    private Vector3 relativePos;
    private Transform transPos;
    private float relPosX;

    private Vector3 posCact01;
    private Vector3 posCact02;

    private Vector3 currentPos;
    private Vector3 retPos;
    private Vector3 retPosAlt;
    private Vector3 nextPos;

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

    public bool boolRestRot;
    private bool boolGoToNext;

    private bool getRel;

    private float speed;
    public float restSpeed;
    public float patrolSpeed;
    public float attackSpeed;
    public int intSect;

    public float distJ;
    public float distL;
    public int index;
    public int indexAlt;
    public bool goToAltPos;

    private float floatNearest;
    private float dxRet;
    private float dyRet;
    private int rotDir;

    private bool timeCapt;
    private float timeStart;

    public GameObject butt;

    List<float> nearDistArray = new List<float>();

    float t;

    public int curMainState;
    public int curSubState;

    //Use these variables to parse through to Rotation script
    public float dxPos;
    public float dyPos;

    private Collider2D collide;

    private int direction;

    LayerMask cactusLayer;

    public enum MainState
    {
        patrol,
        attack,
        ret,
        rest,
        nextSect
    }

    public enum SubState
    {
        inSect1,
        inSect2,
        inSect3
    }


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collide = GetComponent<Collider2D>();

        speed = patrolSpeed;
        pos0101 = sect0101.transform.position;
        pos0102 = sect0102.transform.position;
        pos0103 = sect0103.transform.position;
        pos0201 = sect0201.transform.position;
        pos0202 = sect0202.transform.position;
        pos0203 = sect0203.transform.position;
        pos0301 = sect0301.transform.position;
        pos0302 = sect0302.transform.position;
        pos0303 = sect0303.transform.position;


        //locPos0101 = sect0101.transform.localPosition;

        posCact01 = cact01.transform.position;
        posCact02 = cact02.transform.position;

        directionDistance = 5;

        toPos0101 = true;
        intSect = 1;
        boolSect1 = true;
        boolRestRot = false;

        
        //cactusLayer = LayerMask.GetMask("Cactus");
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



        if (boolSect1 == true)
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



        if(curMainState == (int)MainState.patrol)
        {
            
            collide.isTrigger = true;
            animator.SetBool("Agro", false);
            animator.SetBool("Rest", false);


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
                        speed = restSpeed;

                        transform.Rotate(0, 0, 1 * 37 * Time.fixedDeltaTime);

                        animator.SetBool("Rest", true);
                    }
                        
                    

                    if (System.Math.Round(currentAngle,1) == System.Math.Round(pos02Angle,1))
                    {
                        speed = patrolSpeed;

                        animator.SetBool("Rest", false);
                        toPos0101 = false;
                        toPos0102 = true;
                        t = 0;


                    }

                }

                if (toPos0102 == true)
                {
                    
                    transform.position += (pos0102 - currentPos).normalized * speed;

                    if (Vector3.Distance(currentPos, pos0102) <= 0.1f)
                    {
                        speed = restSpeed;

                        transform.Rotate(0, 0, 1 * 37 * Time.fixedDeltaTime);

                        animator.SetBool("Rest", true);
                    }


                    if (System.Math.Round(currentAngle, 1) == System.Math.Round(pos03Angle, 1))
                    {
                        speed = patrolSpeed;
                        animator.SetBool("Rest", false);

                        toPos0102 = false;
                        toPos0103 = true;
                        t = 0;
                        tripCount += 1;
                    }

                }

                if (toPos0103 == true)
                {
                   
                    transform.position += (pos0103 - currentPos).normalized * speed;                  
                                       
                   
                    if (Vector3.Distance(currentPos, pos0103) <= 0.1f)
                    {
                        if (tripCount == 2)
                        {
                            curMainState = (int)MainState.nextSect;
                            nextPos = pos0201;
                            toPos0201 = true;
                            toPos0103 = false;
                            boolGoToNext = false;
                            rotDir = 1;
                            tripCount = 0;

                        }

                        else
                        {
                            speed = restSpeed;
                            transform.Rotate(0, 0, 1 * 37 * Time.fixedDeltaTime);

                            animator.SetBool("Rest", true);
                        }
                            


                    }
                    if (System.Math.Round(currentAngle, 1) == System.Math.Round(pos01Angle, 1))
                    {
                        speed = patrolSpeed;
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
                        speed = restSpeed;
                        transform.Rotate(0, 0, -1 * 37 * Time.fixedDeltaTime);


                        animator.SetBool("Rest", true);
                    }



                    if (System.Math.Round(currentAngle, 1) == System.Math.Round(pos02Angle, 1))
                    {
                        speed = patrolSpeed;
                        animator.SetBool("Rest", false);

                        toPos0201 = false;
                        toPos0202 = true;
                        t = 0;


                    }

                }

                if (toPos0202 == true)
                {

                    transform.position += (pos0202 - currentPos).normalized * speed;

                    if (Vector3.Distance(currentPos, pos0202) <= 0.1f)
                    {
                        speed = restSpeed;
                        transform.Rotate(0, 0, -1 * 37 * Time.fixedDeltaTime);

                        animator.SetBool("Rest", true);
                    }


                    if (System.Math.Round(currentAngle, 1) == System.Math.Round(pos03Angle, 1))
                    {
                        speed = patrolSpeed;
                        animator.SetBool("Rest", false);

                        toPos0202 = false;
                        toPos0203 = true;
                        t = 0;
                        tripCount += 1;
                    }

                }

                if (toPos0203 == true)
                {

                    transform.position += (pos0203 - currentPos).normalized * speed;

                    if (Vector3.Distance(currentPos, pos0203) <= 0.5f)
                    {

                        if (tripCount == 1)
                        {
                            curMainState = (int)MainState.nextSect;
                            nextPos = pos0302;
                            toPos0302 = true;
                            toPos0203 = false;
                            rotDir = -1;
                            boolGoToNext = false;
                            tripCount = 0;

                        }

                        else
                        {
                            speed = restSpeed;
                            transform.Rotate(0, 0, -1 * 37 * Time.fixedDeltaTime);

                            animator.SetBool("Rest", true);
                        }
                    }


                    if (System.Math.Round(currentAngle, 1) == System.Math.Round(pos01Angle, 1))
                    {
                        speed = patrolSpeed;
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
                        

                        if (tripCount == 1)
                        {
                            curMainState = (int)MainState.nextSect;
                            nextPos = pos0101;
                            toPos0101 = true;
                            toPos0301 = false;
                            boolGoToNext = false;
                            rotDir = 1;
                            tripCount = 0;

                        }

                        else
                        {
                            speed = restSpeed;
                            transform.Rotate(0, 0, 1 * 37 * Time.fixedDeltaTime);
                            animator.SetBool("Rest", true);
                        }
                    }



                    if (System.Math.Round(currentAngle, 1) == System.Math.Round(pos02Angle, 1))
                    {
                        speed = patrolSpeed;
                        animator.SetBool("Rest", false);

                        toPos0301 = false;
                        toPos0302 = true;
                        t = 0;


                    }

                }

                if (toPos0302 == true)
                {

                    transform.position += (pos0302 - currentPos).normalized * speed;

                    if (Vector3.Distance(currentPos, pos0302) <= 0.1f)
                    {
                        speed = restSpeed;
                        transform.Rotate(0, 0, 1 * 37 * Time.fixedDeltaTime);

                        animator.SetBool("Rest", true);
                    }


                    if (System.Math.Round(currentAngle, 1) == System.Math.Round(pos03Angle, 1))
                    {
                        speed = patrolSpeed;
                        animator.SetBool("Rest", false);

                        toPos0302 = false;
                        toPos0303 = true;
                        t = 0;
                        tripCount += 1;
                    }

                }

                if (toPos0303 == true)
                {

                    transform.position += (pos0303 - currentPos).normalized * speed;

                    if (Vector3.Distance(currentPos, pos0303) <= 0.1f)
                    {
                        speed = restSpeed;
                        transform.Rotate(0, 0, 1 * 37 * Time.fixedDeltaTime);

                        animator.SetBool("Rest", true);
                    }


                    if (System.Math.Round(currentAngle, 1) == System.Math.Round(pos01Angle, 1))
                    {
                        speed = patrolSpeed;
                        animator.SetBool("Rest", false);

                        toPos0303 = false;
                        toPos0301 = true;
                        t = 0;
                    }
                }
            }
        }
  
        if(curMainState == (int)MainState.attack)
        {
            boolGoToNext = false;
            tripCount = 0;
            animator.SetBool("Rest", false);
            animator.SetBool("Agro", true);

            float bx = butt.transform.position.x - transform.position.x;
            float by = butt.transform.position.x - transform.position.y;

            float buttAngle = Mathf.Atan2(by, bx);

            speed = attackSpeed;
            //transform.position += (butt.transform.position - currentPos).normalized * speed;

    
            float dist = Vector3.Distance(posCact01, transform.position);
            //Debug.Log(dist);
            Vector3 newPos = transform.position += (butt.transform.position - currentPos).normalized * speed;
            rb2d.MovePosition(newPos);
            //rb2d.velocity = (butt.transform.position - currentPos);

            Vector3 relativePos = currentPos - butt.transform.position;

            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.forward);
            rotation.x = 0.0f;
            rotation.y = 0.0f;
            //transform.rotation = rotation;
            rb2d.MoveRotation(rotation);           
            

            timeCapt = true;

            collide.isTrigger = false;

  

        }

        if(curMainState == (int)MainState.ret)
        {
            speed = patrolSpeed;

            animator.SetBool("Agro", false);
            animator.SetBool("Rest", false);

            //Debug.Log("Return");

            if(goToAltPos)
            {
                transform.position += (retPosAlt - currentPos).normalized * speed;

                if (Vector3.Distance(currentPos, retPosAlt) <= 0.1f)
                {
                    if (indexAlt == 0)
                    {
                        toPos0101 = true;
                    }

                    else if (indexAlt == 1)
                    {
                        toPos0102 = true;
                    }

                    else if (indexAlt == 2)
                    {
                        toPos0103 = true;
                    }

                    else if (indexAlt == 3)
                    {
                        toPos0201 = true;
                    }

                    else if (indexAlt == 4)
                    {
                        toPos0202 = true;
                    }

                    else if (indexAlt == 5)
                    {
                        toPos0203 = true;
                    }

                    else if (indexAlt == 6)
                    {
                        toPos0301 = true;
                    }

                    else if (indexAlt == 7)
                    {
                        toPos0302 = true;
                    }

                    else if (indexAlt == 8)
                    {
                        toPos0303 = true;
                    }
                    curMainState = (int)MainState.patrol;

                    goToAltPos = false;
                }

            }

            else
            {
                transform.position += (retPos - currentPos).normalized * speed;

                if (Vector3.Distance(currentPos, retPos) <= 0.1f)
                {
                   // Debug.Log(index + " index");
                    if (index == 0)
                    {
                        toPos0101 = true;
                    }

                    else if (index == 1)
                    {
                        toPos0102 = true;
                    }

                    else if (index == 2)
                    {
                        toPos0103 = true;
                    }

                    else if (index == 3)
                    {
                        toPos0201 = true;
                    }

                    else if (index == 4)
                    {
                        toPos0202 = true;
                    }

                    else if (index == 5)
                    {
                        toPos0203 = true;
                    }

                    else if (index == 6)
                    {
                        toPos0301 = true;
                    }

                    else if (index == 7)
                    {
                        toPos0302 = true;
                    }

                    else if (index == 8)
                    {
                        toPos0303 = true;
                    }
                    curMainState = (int)MainState.patrol;
                }

            }






        }

        if (curMainState == (int)MainState.rest)
        {
            animator.SetBool("Agro", false);
            animator.SetBool("Rest", true);



            if(goToAltPos)
            {
                dxRet = retPosAlt.x - transform.position.x;
                dyRet = retPosAlt.y - transform.position.y;

                
                
                dxPos = retPosAlt.x;
                dxPos = retPosAlt.y;
            }

            else
            {
                dxRet = retPos.x - transform.position.x;
                dyRet = retPos.y - transform.position.y;

                //TODO: use localposition to determine which way to turn

                GameObject[] posObjArray = new[] { sect0101, sect0102, sect0103, sect0201, sect0202, sect0203, sect0301, sect0302, sect0303 };

                if(getRel)
                {
                    for (int i = 0; i <= posObjArray.Length; i++)
                    {
                        if (i == index)
                        {
                            transPos = posObjArray[i].transform;

                            Vector3 relativePos = transPos.InverseTransformDirection(transform.up);
                            
                            relPosX = relativePos.x;
                        }
                    }

                    getRel = false;
                }

                          

                
                dxPos = retPos.x;
                dxPos = retPos.y;
            }

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


            if(boolRestRot)
            {
                //Debug.Log(Mathf.Round(relativePos.x));
                if(relPosX < 0f)
                {
                    transform.Rotate(0, 0, 1 * 37 * Time.fixedDeltaTime);

                    //Debug.Log("Rotate anti-clock");  
                }

                else
                {
                    transform.Rotate(0, 0, -1 * 37 * Time.fixedDeltaTime);
                }
                
            }




            if (System.Math.Round(currentAngle, 1) == System.Math.Round(posRetAngle, 1))
            {
                

                cactusLayer = LayerMask.GetMask("Cactus");
                //Debug.Log(cactusLayer);
                RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 1.0f, cactusLayer);

                //Debug.DrawRay(transform.position, transform.up * 1.0f, Color.red, 1f);

                if (hit.collider != null)
                {
                    //Debug.Log("Cactus look " + hit.collider.gameObject.name);
                    goToAltPos = true;
                }

                else
                {
                    curMainState = (int)MainState.ret;
                    boolRestRot = false;
                }

            }

            


        }

        if(curMainState == (int)MainState.nextSect)
        {
            float dxNext = nextPos.x - transform.position.x;
            float dyNext = nextPos.y - transform.position.y;

            float nextPosAngle = Mathf.Atan2(dyNext, dxNext);           

            if(boolGoToNext == false)
            {
                speed = restSpeed;
                transform.Rotate(0, 0, rotDir * 37 * Time.fixedDeltaTime);

                if (System.Math.Round(currentAngle, 1) == System.Math.Round(nextPosAngle, 1))
                {
                    speed = patrolSpeed;
                    animator.SetBool("Rest", false);
                    boolGoToNext = true;

                }
            }

            else
            {
                transform.position += (nextPos - currentPos).normalized * speed;

                if (Vector3.Distance(currentPos, nextPos) <= 0.1f)
                {
                    curMainState = (int)MainState.patrol;
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

        //Add all distancces to array
        for (int i = 0; i < posArray.Length; i++)
        {
            floatNearest = Vector3.Distance(currentPos, posArray[i]);

            nearDistArray.Add(floatNearest);            


        }
        
        float minVal = nearDistArray[0];

        //go through all the distances and pick minmnum
        for (int j = 1; j < nearDistArray.Count; j++)
        {
            if(nearDistArray[j]<minVal)
            {
                minVal = nearDistArray[j];
                index = j;
                indexAlt = j - 1;
            }
        }


        for(int k = 0; k < posArray.Length; k++)
        {

            if(k == index)
            {
                retPos = posArray[k];
            }

            if(k == indexAlt)
            {
                retPosAlt = posArray[k];
            }
        }



        nearDistArray.Clear();

        getRel = true;

    }


    

}
