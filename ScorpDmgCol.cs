using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpDmgCol : MonoBehaviour
{
    public GameObject butt;
    public int damageVal;
    public bool collEnabled;

    public void Start()
    {
        damageVal = 6;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == butt)
        {
            Debug.Log("damage");
            collEnabled = true;

        }
    }
}
