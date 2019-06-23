using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCreate : MonoBehaviour
{


    //public GameObject prefab;
    public GameObject cloud;
    public bool cloudSpawn;
    public GameObject cloudFlow;
    public static Vector3 startPos1;
    public static Vector3 startPos2;
    public Vector3 scale;
    public Camera cam;
    public bool cloudSpawned;


    // Use this for initialization
    void Start()
    {
        startPos1 = new Vector3(-9.9f, 2.3f);
        startPos2 = new Vector3(-9.9f, 0.0f);
        cloudSpawned = false;
        scale = new Vector3(1.5f, 2.5f);
        
        /*Vector3 cloudHere = new Vector3(-9f, -2.86f);
        Instantiate(prefab, cloudHere, transform.rotation);
        Debug.Log("you're not creating loads of these fucking things are you?");*/
    }

    // Update is called once per frame
    void FixedUpdate()

    {
        
        if (Mathf.Round(Time.timeSinceLevelLoad) == 15.0f || CloudFlowColl.cloudSpawn == true)
        {

            if (CloudFlowColl.cloudSpawn == true)
            {
                cloud.transform.localScale = new Vector3(scale.x, scale.y);
                cloud.transform.position = startPos2;
                cloud.SetActive(true);
                CloudFlowColl.cloudSpawn = false;
            }

            else
            {
                cloud.transform.position = startPos1;
                cloud.SetActive(true);
                CloudFlowColl.cloudSpawn = false;
            }
                

     

        }
    }
}
