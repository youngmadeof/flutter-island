using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehave : MonoBehaviour {


    //private Rigidbody2D rb2d;
    private float cloudSpeed;
    public Camera cam;
 
    
    // Use this for initialization
    void Start ()

    {
        cloudSpeed = 30f;
        //rb2d = GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void FixedUpdate ()

    {
        //Debug.Log(Time.timeSinceLevelLoad);
        Vector3 desiredPos = new Vector3(11.3f, -2.86f);
        Vector3 currentPos = transform.position;
        Vector3 currentScreenPos = cam.WorldToViewportPoint(currentPos);
        Vector3 desiredScreenPos = cam.WorldToViewportPoint(desiredPos);
        //Debug.Log(currentScreenPos + " current");


        if (Time.timeSinceLevelLoad > 6.0f)
        {
            transform.position += (desiredScreenPos - currentScreenPos).normalized / cloudSpeed;
        }

        //Debug.Log(desiredScreenPos + " desired");

	}
}
