using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehave : MonoBehaviour {


    //private Rigidbody2D rb2d;
    public float cloudSpeed;
    public Camera cam;
    public bool cloudSpawn;



    // Use this for initialization
    void Start ()

    {
        
        //rb2d = GetComponent<Rigidbody2D>();
        

    }

	// Update is called once per frame
	void FixedUpdate ()

    {
        //Debug.Log(Time.timeSinceLevelLoad);   
        
        Vector3 desiredPos = new Vector3(11.85f , 2.31f);
        Vector3 currentPos = transform.position;
        Vector3 currentScreenPos = cam.WorldToViewportPoint(currentPos);
        Vector3 desiredScreenPos = cam.WorldToViewportPoint(desiredPos);
        //Debug.Log(currentScreenPos + " current");

        //CloudFlowColl cloudFlowScript = cloudFlow.GetComponent<CloudFlowColl>();
        bool  cloudSpawn = CloudFlowColl.cloudSpawn;

        if(cloudSpawn == true)
        {
            cloudSpeed = 0.5f;
        }

        else
        {
            cloudSpeed = 30f;
        }

        transform.position += (desiredScreenPos - currentScreenPos).normalized / cloudSpeed;
 

        //CONDITIONS FOR STATES
         
 

        if (transform.position.x >= desiredPos.x)
        {
            gameObject.SetActive(false);
        }




        //Debug.Log(desiredScreenPos + " desired");

	}

}
