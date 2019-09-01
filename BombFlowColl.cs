using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombFlowColl : MonoBehaviour {

    public GameObject butt;
    private bool destroy;
    public bool destroyComms;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == butt)
        {
            
           
            destroy = true;
            
            
        }
    }

    private void Update()
    {
        if(Input.GetButtonUp("Fire1") && destroy == true)
        {

            gameObject.SetActive(false);
            destroyComms = true;
            destroy = false;

        }
    }
}
