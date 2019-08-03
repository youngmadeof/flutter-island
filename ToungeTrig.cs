using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToungeTrig : MonoBehaviour {

    public GameObject butt;
    public GameObject tongue;
    public GameObject frog;
    
    private int curState;

    Collider2D tongueColl;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        Frog_Controller frogScpt = frog.GetComponent<Frog_Controller>();
        curState = frogScpt.curState;

        if (curState == 0)
        {
            if (collision.gameObject == butt)
            {
                tongue.SetActive(true);
                //tongueColl = tongue.GetComponent<Collider2D>();
                //tongueColl.enabled = true;

                //
            }
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject == butt)
        {
            tongue.SetActive(false);
        }
    }

}
