using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpCol : MonoBehaviour
{

    public GameObject butt;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == butt)
        {
            if(Flower_Anim.blInteract == false)
            {
                Scorp_Behaviour scorpScript = GetComponentInParent<Scorp_Behaviour>();
                scorpScript.curMainState = 1;
            }
            
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == butt)
        {
            Scorp_Behaviour scorpScript = GetComponentInParent<Scorp_Behaviour>();
            scorpScript.GetNextPos();
            scorpScript.curMainState = 3;
        }
    }


}
