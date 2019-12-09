using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpColExit : MonoBehaviour
{
    public GameObject butt;
    public GameObject scorp;


    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == butt)
        {
            Scorp_Behaviour scorpScript = scorp.GetComponent<Scorp_Behaviour>();
            scorpScript.curMainState = 0;
        }
    }

}
