using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishControl : MonoBehaviour {

    Vector3 currPos;
    public GameObject node01;
    public GameObject node02;
    public GameObject node03;
    public GameObject node04;
    public GameObject node05;
    public GameObject node06;
    public GameObject node07;
    public GameObject node08;
    public GameObject node09;
    public GameObject node10;

    Vector3 node01Pos;
    Vector3 node02Pos;
    Vector3 node03Pos;
    Vector3 node04Pos;
    Vector3 node05Pos;
    Vector3 node06Pos;
    Vector3 node07Pos;
    Vector3 node08Pos;
    Vector3 node09Pos;
    Vector3 node10Pos;

    private bool toNode01;
    private bool toNode02;
    private bool toNode03;
    private bool toNode04;
    private bool toNode05;
    private bool toNode06;
    private bool toNode07;
    private bool toNode08;
    private bool toNode09;
    private bool toNode10;
    // Use this for initialization
    void Start ()

    {
        
        node01Pos = node01.transform.position;
        node02Pos = node02.transform.position;
        node03Pos = node03.transform.position;
        node04Pos = node04.transform.position;
        node05Pos = node05.transform.position;
        node06Pos = node06.transform.position;
        node07Pos = node07.transform.position;
        node08Pos = node08.transform.position;
        node09Pos = node09.transform.position;
        node10Pos = node10.transform.position;

        toNode01 = true;
	}
	
	// Update is called once per frame
	void FixedUpdate ()

    {
        currPos = transform.position;

        //TODO: have rotation target in a stored in array and iterate as each node is hit. Put outside of if statements
 

        if(toNode01 == true )
        {

            transform.position += (node01Pos - transform.position).normalized * 0.02f;
            Vector3 relPos = (currPos - node02Pos).normalized;
            Quaternion rot = Quaternion.LookRotation(relPos, Vector3.forward);

            rot.x = 0.0f;
            rot.y = 0.0f;
            transform.rotation = rot;


            if (Vector3.Distance(currPos, node01Pos) <= 0.35f)
            {
                toNode01 = false;
                toNode02 = true;
                

            }
        }
        
        if(toNode02 == true)
        {
            transform.position += (node02Pos - transform.position).normalized * 0.02f;

            Vector3 relPos = (currPos - node03Pos).normalized;
            Quaternion rot = Quaternion.LookRotation(relPos, Vector3.forward);

            rot.x = 0.0f;
            rot.y = 0.0f;
            transform.rotation = rot;


            if (Vector3.Distance(currPos,node02Pos) <= 0.35f)
            {

                toNode02 = false;
                toNode03 = true;
            }
        }

        if (toNode03 == true)
        {
            transform.position += (node03Pos - transform.position).normalized * 0.02f;
            Vector3 relPos = (currPos - node04Pos).normalized;
            Quaternion rot = Quaternion.LookRotation(relPos, Vector3.forward);
            rot.x = 0.0f;
            rot.y = 0.0f;
            transform.rotation = rot;

            if (Vector3.Distance(currPos, node03Pos) <= 0.35f)
            {
                toNode03 = false;
                toNode04 = true;
            }
        }

        if(toNode04 == true)
        {
            transform.position += (node04Pos - transform.position).normalized * 0.02f;
            Vector3 relPos = (currPos - node05Pos).normalized;
            Quaternion rot = Quaternion.LookRotation(relPos, Vector3.forward);
            rot.x = 0.0f;
            rot.y = 0.0f;
            transform.rotation = rot;


            if (Vector3.Distance(currPos, node04Pos) <= 0.35f)
            {
                toNode04 = false;
                toNode05 = true;

            }
        }

        if (toNode05 == true)
        {
            transform.position += (node05Pos - transform.position).normalized * 0.02f;
            Vector3 relPos = (currPos - node06Pos).normalized *0.02f;
            Quaternion rot = Quaternion.LookRotation(relPos, Vector3.forward);
            rot.x = 0.0f;
            rot.y = 0.0f;
            transform.rotation = rot;

            if (Vector3.Distance(currPos, node05Pos) <= 0.35f)
            {
                toNode05 = false;
                toNode06 = true;


            }
        }

        if (toNode06 == true)
        {
            transform.position += (node06Pos - transform.position).normalized * 0.02f;
            Vector3 relPos = (currPos - node07Pos).normalized;
            Quaternion rot = Quaternion.LookRotation(relPos, Vector3.forward);
            rot.x = 0.0f;
            rot.y = 0.0f;
            transform.rotation = rot;

            if (Vector3.Distance(currPos, node06Pos) <= 0.35f)
            {
                toNode06 = false;
                toNode07 = true;


            }
        }

        if (toNode07 == true)
        {
            transform.position += (node07Pos - transform.position).normalized * 0.02f;
            Vector3 relPos = (currPos - node08Pos).normalized;
            Quaternion rot = Quaternion.LookRotation(relPos, Vector3.forward);
            rot.x = 0.0f;
            rot.y = 0.0f;
            transform.rotation = rot;

            if (Vector3.Distance(currPos, node07Pos) <= 0.35f)
            {
                toNode07 = false;
                toNode08 = true;


            }
        }

        if (toNode08 == true)
        {
            transform.position += (node08Pos - transform.position).normalized * 0.02f;
            Vector3 relPos = (currPos - node09Pos).normalized;
            Quaternion rot = Quaternion.LookRotation(relPos, Vector3.forward);
            rot.x = 0.0f;
            rot.y = 0.0f;
            transform.rotation = rot;

            if (Vector3.Distance(currPos, node08Pos) <= 0.35f)
            {
                toNode08 = false;
                toNode09 = true;


            }
        }


        if (toNode09 == true)
        {
            transform.position += (node09Pos - transform.position).normalized * 0.02f;
            Vector3 relPos = (currPos - node10Pos).normalized;
            Quaternion rot = Quaternion.LookRotation(relPos, Vector3.forward);
            rot.x = 0.0f;
            rot.y = 0.0f;
            transform.rotation = rot;

            if (Vector3.Distance(currPos, node09Pos) <= 0.35f)
            {
                toNode09 = false;
                toNode10 = true;


            }
        }

        if (toNode10 == true)
        {
            transform.position += (node10Pos - transform.position).normalized * 0.02f;
            Vector3 relPos = (currPos - node01Pos).normalized * 0.02f;
            Quaternion rot = Quaternion.LookRotation(relPos, Vector3.forward);
            rot.x = 0.0f;
            rot.y = 0.0f;
            transform.rotation = rot;

            if (Vector3.Distance(currPos, node10Pos) <= 0.35f)
            {
                toNode10 = false;
                toNode01 = true;


            }
        }
    }
}
