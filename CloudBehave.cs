using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehave : MonoBehaviour {


    //private Rigidbody2D rb2d;
    private float cloudSpeed;
   // private Camera cam;
    public GameObject cloud;
    public Camera cam;
    private bool cloudSpawn;


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
        
        Vector3 desiredPos = new Vector3(11.85f , 2.31f);
        Vector3 currentPos = cloud.transform.position;
        Vector3 currentScreenPos = cam.WorldToViewportPoint(currentPos);
        Vector3 desiredScreenPos = cam.WorldToViewportPoint(desiredPos);
        //Debug.Log(currentScreenPos + " current");


        if (Time.timeSinceLevelLoad > 15.0f)
        {
            if (cloudSpawn == false)
            {
                cloud.SetActive(true);

                cloudSpawn = true;
            }
            
 
            cloud.transform.position += (desiredScreenPos - currentScreenPos).normalized / cloudSpeed;

            
        }

        if(cloud.transform.position.x >= desiredPos.x)
        {
            cloud.SetActive(false);
        }

        //Debug.Log(desiredScreenPos + " desired");

	}

}
