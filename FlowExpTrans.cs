using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowExpTrans : MonoBehaviour {


	
    public void FlowGoBang(Vector3 flowPos)
    {
        transform.position = flowPos;
        GetComponent<ParticleSystem>().Play();
    }

}
