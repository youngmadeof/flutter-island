using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactCol : MonoBehaviour
{
    // Start is called before the first frame update

    Collider2D cactCollider;
    void Start()
    {
        cactCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Flower_Anim.blInteract == true)
        {
            cactCollider.isTrigger = true;
        }

        else
        {
            cactCollider.isTrigger = false;
        }
    }
}
