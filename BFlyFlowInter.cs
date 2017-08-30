using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFlyFlowInter : MonoBehaviour
{
    private GameObject flower;
    private Rigidbody2D rb2d;
    private bool hitFlow;
    public int linDrag;
    public int angDrag;
   //private float flowLinDrag;




	// Use this for initialization
	void Start ()
    {
        flower = GameObject.Find("Flower");
        rb2d = GetComponent<Rigidbody2D>();
        hitFlow = false;
        //flowLinDrag = BFly_Control.buttLinDrag;
        //linDrag = 80;
        //angDrag = 80;
		
	}

    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject == flower)
        {
            hitFlow = true;
        }
    }

    private void OnTriggerExit2D(Collider2D Other)
    {
        if (Other.gameObject == flower)
        {
            hitFlow = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        if (hitFlow == true)
        {
            rb2d.drag = linDrag;
            rb2d.angularDrag = angDrag;
        }

        else if (hitFlow == false)
        {
            rb2d.drag = 10;
            rb2d.angularDrag = 40;
        }

		
	}
}
