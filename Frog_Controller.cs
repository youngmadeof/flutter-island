using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog_Controller : MonoBehaviour
{

    private Rigidbody2D rb2d;

    Animator anim;

    public GameObject butt;
    public GameObject tongue;
    public GameObject tongueTrig;
    public GameObject lil01;
    public GameObject lil02;
    public GameObject lil03;
    public GameObject lil04;
    public GameObject lil05;

    private bool toLil01;
    private bool toLil02;
    private bool toLil03;
    private bool toLil04;
    private bool toLil05;

    private bool gotPos;


    private float halfDist;
    private string route;

    public int tripCount;

    float destiTime;

    bool shrink;
    public int curState;
    bool gotSize;

    public static Vector3 currSize;

    Vector3 offsetRot;

    public enum State
    {
        idle,
        leap
    }

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        toLil02 = true;

        curState = (int)State.leap;
        gotSize = false;

        offsetRot = new Vector3(0, 0, 10);

    }

    void FixedUpdate()
    {
        if (Time.timeSinceLevelLoad > 1.5f)
        {
            MoveToPad();
        }

    }

    private void MoveToPad()
    {
        Vector3 currentPos = transform.position;


        Vector3 lilPos01 = lil01.transform.position;
        Vector3 lilPos02 = lil02.transform.position;
        Vector3 lilPos03 = lil03.transform.position;
        Vector3 lilPos04 = lil04.transform.position;
        Vector3 lilPos05 = lil05.transform.position;


        if (curState == (int)State.leap)
        {

            if (toLil02 == true)
            {


                
                Vector3 relativePos = currentPos - lilPos02;

                Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.forward);
                rotation.x = 0.0f;
                rotation.y = 0.0f;
                transform.rotation = rotation;

               // Debug.Log(rotation + " transform.rotation");
                //Debug.Log(relativePos + " relativePos");

                anim.SetBool("IdleToLeap", true);
                transform.position += (lilPos02 - transform.position) * 0.08f;
                currSize = transform.localScale;
                float halfDist0102 = Vector3.Distance(lilPos01, lilPos02) / 2;
                float curDist = Vector3.Distance(currentPos, lilPos02);

                if (shrink == false)
                {
                    transform.localScale += new Vector3(0.1f, 0.1f);
                }

                if (Mathf.Round(curDist) <= Mathf.Round(halfDist0102))

                {

                    anim.SetBool("IdleToLeap", false);


                    if (System.Math.Round(currSize.y, 2) > 0.5f)

                    {


                        if (System.Math.Round(currSize.y, 2) != 0.5f)

                        {
                            transform.localScale -= new Vector3(0.1f, 0.1f);
                            shrink = true;
                        }

                    }


                }


                if (Vector3.Distance(currentPos, lilPos02) <= 0.05f)
                {

                    toLil02 = false;

                    Vector3 relativePos2 = currentPos - butt.transform.position;

                    Quaternion rotation2 = Quaternion.LookRotation(relativePos2, Vector3.forward);
                    rotation2.x = 0.0f;
                    rotation2.y = 0.0f;
                    transform.rotation = rotation2;
                    curState = (int)State.idle;
                    destiTime = Mathf.Round(Time.fixedTime);
                    shrink = false;
                    toLil01 = true;
                    route = "0201";
                }

            }


            if (toLil01 == true && curState == (int)State.leap)
            {
                //Turn before jump
                Vector3 relativePos = currentPos - lilPos01;

                Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.forward);
                rotation.x = 0.0f;
                rotation.y = 0.0f;
                transform.rotation = rotation;

                //Debug.Log(rotation + " transform.rotation");
                //Debug.Log(relativePos + " relativePos");

                anim.SetBool("IdleToLeap", true);
                //Make that jump
                transform.position += (lilPos01 - transform.position) * 0.08f;
                currSize = transform.localScale;
                //working out half the distance between lilly pads

                if(route == "0201")
                {
                    halfDist = Vector3.Distance(lilPos02, lilPos01) / 2;
                }

                else if (route == "0301")
                {
                    halfDist = Vector3.Distance(lilPos03, lilPos01) / 2;
                }

                else if (route == "0401")
                {
                    halfDist = Vector3.Distance(lilPos04, lilPos01) / 2;
                }

                else if (route == "0501")
                {

                    halfDist = Vector3.Distance(lilPos05, lilPos01) / 2;
                }

                
               

                float curDist = Vector3.Distance(currentPos, lilPos01);

                if (shrink == false)
                {
                    transform.localScale += new Vector3(0.1f, 0.1f);
                }

                if (Mathf.Round(curDist) <= Mathf.Round(halfDist))

                {

                    anim.SetBool("IdleToLeap", false);


                    if (System.Math.Round(currSize.y, 2) > 0.5f)

                    {


                        if (System.Math.Round(currSize.y, 2) != 0.5f)

                        {
                            transform.localScale -= new Vector3(0.1f, 0.1f);
                            shrink = true;
                        }

                    }

                    if (Vector3.Distance(currentPos, lilPos01) <= 0.05f)
                    {

                        toLil01 = false;

                        curState = (int)State.idle;
                        destiTime = Mathf.Round(Time.fixedTime);
                        shrink = false;

                        if(route == "0201")
                        {
                            toLil04 = true;


                            Vector3 relativePos2 = currentPos - butt.transform.position;

                            Quaternion rotation2 = Quaternion.LookRotation(relativePos2, Vector3.forward);
                            rotation2.x = 0.0f;
                            rotation2.y = 0.0f;
                            transform.rotation = rotation2;
                        }

                        else if (route == "0401")
                        {

                            if(tripCount == 1)
                            {
                                toLil03 = true;


                                Vector3 relativePos2 = currentPos - butt.transform.position;

                                Quaternion rotation2 = Quaternion.LookRotation(relativePos2, Vector3.forward);
                                rotation2.x = 0.0f;
                                rotation2.y = 0.0f;
                                transform.rotation = rotation2;
                            }

                            if(tripCount == 2)
                            {
                                toLil05 = true;


                                Vector3 relativePos2 = currentPos - butt.transform.position;

                                Quaternion rotation2 = Quaternion.LookRotation(relativePos2, Vector3.forward);
                                rotation2.x = 0.0f;
                                rotation2.y = 0.0f;
                                transform.rotation = rotation2;

                                tripCount = 0;
                            }
            
                        }

                        else if (route == "0301")
                        {
                            
                            toLil04 = true;

                            Vector3 relativePos2 = currentPos - butt.transform.position;

                            Quaternion rotation2 = Quaternion.LookRotation(relativePos2, Vector3.forward);
                            rotation2.x = 0.0f;
                            rotation2.y = 0.0f;
                            transform.rotation = rotation2;
                        }

                        else if (route == "0501")
                        {
                            if(tripCount == 1)
                            {
                                toLil05 = true;


                                Vector3 relativePos2 = currentPos - butt.transform.position;

                                Quaternion rotation2 = Quaternion.LookRotation(relativePos2, Vector3.forward);
                                rotation2.x = 0.0f;
                                rotation2.y = 0.0f;
                                transform.rotation = rotation2;
                            }

                            if(tripCount == 2)
                            {
                                toLil02 = true;


                                Vector3 relativePos2 = currentPos - butt.transform.position;

                                Quaternion rotation2 = Quaternion.LookRotation(relativePos2, Vector3.forward);
                                rotation2.x = 0.0f;
                                rotation2.y = 0.0f;
                                transform.rotation = rotation2;

                                tripCount = 0;
                            }
                        }
                        
                    }

                }
            }


            if (toLil04 == true && curState == (int)State.leap)
            {
                //Turn before jump
                Vector3 relativePos = currentPos - lilPos04;

                //Debug.Log("TOLIL01");

                Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.forward);
                rotation.x = 0.0f;
                rotation.y = 0.0f;
                transform.rotation = rotation;

                //Debug.Log(rotation + " transform.rotation");
                //Debug.Log(relativePos + " relativePos");

                anim.SetBool("IdleToLeap", true);
                //Make that jump
                transform.position += (lilPos04 - transform.position) * 0.08f;
                currSize = transform.localScale;
                //working out half the distance between lilly pads
                float halfDist0104 = Vector3.Distance(lilPos01, lilPos04) / 2;
                float curDist = Vector3.Distance(currentPos, lilPos04);

                if (shrink == false)
                {
                    transform.localScale += new Vector3(0.1f, 0.1f);
                }

                if (Mathf.Round(curDist) <= Mathf.Round(halfDist0104))

                {

                    anim.SetBool("IdleToLeap", false);


                    if (System.Math.Round(currSize.y, 2) > 0.5f)

                    {


                        if (System.Math.Round(currSize.y, 2) != 0.5f)

                        {
                            transform.localScale -= new Vector3(0.1f, 0.1f);
                            shrink = true;
                        }

                    }

                    if (Vector3.Distance(currentPos, lilPos04) <= 0.05f)
                    {

                        toLil04 = false;

                        Vector3 relativePos2 = currentPos - butt.transform.position;

                        Quaternion rotation2 = Quaternion.LookRotation(relativePos2, Vector3.forward);
                        rotation2.x = 0.0f;
                        rotation2.y = 0.0f;
                        transform.rotation = rotation2;
                        curState = (int)State.idle;
                        destiTime = Mathf.Round(Time.fixedTime);
                        shrink = false;
                        toLil01 = true;
                        route = "0401";
                        tripCount += 1;
                    }

                }
            }

            if (toLil03 == true && curState == (int)State.leap)
            {
                //Turn before jump
                Vector3 relativePos = currentPos - lilPos03;

                Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.forward);
                rotation.x = 0.0f;
                rotation.y = 0.0f;
                transform.rotation = rotation;

                //Debug.Log(rotation + " transform.rotation");
                //Debug.Log(relativePos + " relativePos");

                anim.SetBool("IdleToLeap", true);
                //Make that jump
                transform.position += (lilPos03 - transform.position) * 0.08f;
                currSize = transform.localScale;
                //working out half the distance between lilly pads
                float halfDist0103 = Vector3.Distance(lilPos01, lilPos03) / 2;
                float curDist = Vector3.Distance(currentPos, lilPos03);

                if (shrink == false)
                {
                    transform.localScale += new Vector3(0.1f, 0.1f);
                }

                if (Mathf.Round(curDist) <= Mathf.Round(halfDist0103))

                {

                    anim.SetBool("IdleToLeap", false);


                    if (System.Math.Round(currSize.y, 2) > 0.5f)

                    {


                        if (System.Math.Round(currSize.y, 2) != 0.5f)

                        {
                            transform.localScale -= new Vector3(0.1f, 0.1f);
                            shrink = true;
                        }

                    }

                    if (Vector3.Distance(currentPos, lilPos03) <= 0.05f)
                    {

                        toLil03 = false;

                        Vector3 relativePos2 = currentPos - butt.transform.position;

                        Quaternion rotation2 = Quaternion.LookRotation(relativePos2, Vector3.forward);
                        rotation2.x = 0.0f;
                        rotation2.y = 0.0f;
                        transform.rotation = rotation2;
                        curState = (int)State.idle;
                        destiTime = Mathf.Round(Time.fixedTime);
                        shrink = false;
                        toLil01 = true;
                        route = "0301";
                    }

                }
            }

            if (toLil05 == true && curState == (int)State.leap)
            {
                //Turn before jump
                Vector3 relativePos = currentPos - lilPos05;

                Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.forward);
                rotation.x = 0.0f;
                rotation.y = 0.0f;
                transform.rotation = rotation;

               // Debug.Log(rotation + " transform.rotation");
               // Debug.Log(relativePos + " relativePos");

                anim.SetBool("IdleToLeap", true);
                //Make that jump
                transform.position += (lilPos05 - transform.position) * 0.08f;
                currSize = transform.localScale;
                //working out half the distance between lilly pads
                float halfDist0105 = Vector3.Distance(lilPos01, lilPos05) / 2;
                float curDist = Vector3.Distance(currentPos, lilPos05);

                if (shrink == false)
                {
                    transform.localScale += new Vector3(0.1f, 0.1f);
                }

                if (Mathf.Round(curDist) <= Mathf.Round(halfDist0105))

                {

                    anim.SetBool("IdleToLeap", false);


                    if (System.Math.Round(currSize.y, 2) > 0.5f)

                    {


                        if (System.Math.Round(currSize.y, 2) != 0.5f)

                        {
                            transform.localScale -= new Vector3(0.1f, 0.1f);
                            shrink = true;
                        }

                    }

                    if (Vector3.Distance(currentPos, lilPos05) <= 0.05f)
                    {

                        toLil05 = false;

                        Vector3 relativePos2 = currentPos - butt.transform.position;

                        Quaternion rotation2 = Quaternion.LookRotation(relativePos2, Vector3.forward);
                        rotation2.x = 0.0f;
                        rotation2.y = 0.0f;
                        transform.rotation = rotation2;
                        curState = (int)State.idle;
                        destiTime = Mathf.Round(Time.fixedTime);
                        shrink = false;
                        toLil01 = true;
                        route = "0501";

                        tripCount += 1;
                    }

                }
            }
        }

        if (curState == (int)State.idle)
        {
            //Debug.Log(destiTime + 5f + "destiTime + 5");            
            //Debug.Log("IDLE");
            if (Mathf.Round(Time.fixedTime) == destiTime + 5f)
            {
                curState = (int)State.leap;
            }
        }
    }


}
