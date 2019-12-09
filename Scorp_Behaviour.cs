using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorp_Behaviour : MonoBehaviour
{
    private Animator animator;

    public GameObject sector1;
    public GameObject sector2;
    public GameObject sect0101;
    public GameObject sect0102;
    public GameObject sect0103;
    public GameObject sect0201;
    public GameObject sect0202;
    public GameObject sect0203;

    private Vector3 pos0101;
    private Vector3 pos0102;
    private Vector3 pos0103;
    private Vector3 pos0201;
    private Vector3 pos0202;
    private Vector3 pos0203;

    private Vector3 currentPos;
    private Vector3 newPos;
    public Vector3 retPos;

    public bool toPos0101;
    public bool toPos0102;
    public bool toPos0103;

    private float speed;
    public int intSect;

    public float distJ;
    public float distL;
    private float index;

    private float floatNearest;

    public GameObject butt;

    List<float> nearDistArray = new List<float>();

    float t;

    public int curMainState;
    private int curSubState;

    public enum MainState
    {
        idle,
        agro,
        ret
    }

    public enum SubState
    {
        inSect1,
        inSect2,
        inSect3
    }

    public void OnTriggerEnter2D(Collider2D collision)
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
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        speed = 20f;
        pos0101 = sect0101.transform.position;
        pos0102 = sect0102.transform.position;
        pos0103 = sect0103.transform.position;
        pos0201 = sect0201.transform.position;
        pos0202 = sect0202.transform.position;
        pos0203 = sect0203.transform.position;
        toPos0101 = true;
        intSect = 1;

    }

    // Update is called once per frame
    void Update()
    {

        currentPos = transform.position;

        float cx = transform.up.x;
        float cy = transform.up.y;

        float currentAngle = Mathf.Atan2(cy, cx);



        if(curMainState == (int)MainState.idle)
        {
            animator.SetBool("Agro", false);

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


                    t += 0.005f;


                    Vector3 newPos = Vector3.Lerp(transform.position, pos0101, t * Time.deltaTime);

                    transform.position = newPos;


                    if (System.Math.Round(currentAngle, 2) != System.Math.Round(pos01Angle, 2))
                    {
                        transform.Rotate(0, 0, 1 * 20 * Time.fixedDeltaTime);
                    }

                    if (System.Math.Round(currentAngle, 2) == System.Math.Round(pos02Angle, 2))
                    {
                        if (Vector3.Distance(currentPos, pos0101) <= 1f)
                        {

                            toPos0101 = false;
                            toPos0102 = true;
                            t = 0;
                        }
                    }

                }

                if (toPos0102 == true)
                {
                    t += 0.005f;

                    Vector3 newPos = Vector3.Lerp(transform.position, pos0102, t * Time.deltaTime);

                    transform.position = newPos;

                    /*float distCheck = Vector3.Distance(currentPos, pos0102) / 3;

                    if(Vector3.Distance(currentPos, pos0102) <= distCheck)
                    {
                        if (System.Math.Round(currentAngle, 2) != System.Math.Round(pos03Angle, 2))
                        {
                            transform.Rotate(0, 0, 1 * 20 * Time.fixedDeltaTime);
                        }
                    }*/

                    transform.Rotate(0, 0, 1 * 20 * Time.fixedDeltaTime);


                    if (System.Math.Round(currentAngle, 2) == System.Math.Round(pos03Angle, 2))
                    {
                        if (Vector3.Distance(currentPos, pos0102) <= 1f)
                        {

                            toPos0102 = false;
                            toPos0103 = true;
                            t = 0;
                        }
                    }

                }

                if (toPos0103 == true)
                {
                    t += 0.005f;

                    Vector3 newPos = Vector3.Lerp(transform.position, pos0103, t * Time.deltaTime);

                    transform.position = newPos;

                    if (System.Math.Round(currentAngle, 2) != System.Math.Round(pos01Angle, 2))
                    {
                        transform.Rotate(0, 0, 1 * 20 * Time.fixedDeltaTime);
                    }

                    if (Vector3.Distance(currentPos, pos0103) <= 1f)
                    {

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


            }
        }
  
        if(curMainState == (int)MainState.agro)
        {
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

  

        }

        if(curMainState == (int)MainState.ret)
        {
            t += 0.005f;


            Vector3 newPos = Vector3.Lerp(transform.position, retPos, t /* Time.deltaTime*/);

            transform.position = newPos;
        }
       
    }

    public void GetNextPos()
    {
        Vector3[] posArray = new[] { pos0101, pos0102, pos0103, pos0201, pos0202, pos0203 };


        for (int i = 0; i < posArray.Length; i++)
        {
            floatNearest = Vector3.Distance(currentPos, posArray[i]);

            nearDistArray.Add(floatNearest);            

            Debug.Log(floatNearest + " distance " + posArray[i] + " | " + i);

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

        Debug.Log(posArray.Length + " posArray Length");

        for(int k = 0; k < posArray.Length; k++)
        {

            Debug.Log(posArray[k] + " posArray");
            if(k == index)
            {
                retPos = posArray[k];
            }
        }

    
        Debug.Log(minVal);
        Debug.Log(index);


        nearDistArray.Clear();

    }


    

}
