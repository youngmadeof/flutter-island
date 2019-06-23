using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudFlowColl : MonoBehaviour {

    public GameObject butt;
    public static bool cloudSpawn;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == butt)
        {
            cloudSpawn = true;
            gameObject.SetActive(false);
        }
    }


}
