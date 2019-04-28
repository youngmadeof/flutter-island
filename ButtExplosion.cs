using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtExplosion : MonoBehaviour {


	
	// Update is called once per frame
	public void buttGoBang(Vector3 buttPos)
    {

        transform.position = buttPos;
        GetComponent<ParticleSystem>().Play();
    }
}
