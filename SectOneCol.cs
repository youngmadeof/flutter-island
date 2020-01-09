using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectOneCol : MonoBehaviour
{
    public GameObject scorp;
    public bool boolSect;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == scorp)
        {
            boolSect = true;
        }
    }


    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject == scorp)
        {
            boolSect = false;
        }
    }

}
