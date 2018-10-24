using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCreate : MonoBehaviour {


    public GameObject prefab;


	// Use this for initialization
	void Start ()
    {

        Vector3 cloudHere = new Vector3(-9f, -2.86f);
        Instantiate(prefab, cloudHere, transform.rotation);
        Debug.Log("you're not creating loads of these fucking things are you?");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
