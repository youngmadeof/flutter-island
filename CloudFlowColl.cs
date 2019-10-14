using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudFlowColl : MonoBehaviour {

    public GameObject butt;
    public static bool cloudSpawn;
    private bool spawnSet;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == butt)
        {
            spawnSet = true;
           
            
        }
    }

    private void Update()
    {
        if (Input.GetButtonUp("Fire1") && spawnSet == true)
        {

            gameObject.SetActive(false);
            cloudSpawn = true;
            spawnSet = false;

        }
    }

}
