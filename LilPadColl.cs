using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilPadColl : MonoBehaviour {

    public GameObject butt;
    public GameObject bombFlow;
    private int count = 0;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == butt && count == 0)
        {
            bombFlow.SetActive(true);
            count += 1;
        }
    }
}
