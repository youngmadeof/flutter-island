using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishRipEffect : MonoBehaviour {

    public GameObject fishy;
    private float jumpTime;
    private float jumpLen;
    private bool jumpDone;
    private Vector3 fishPos;
    public bool ripDone;
    private float fishSpeed;

    private Animator anim;

	// Use this for initialization
	void Start ()

    {
        anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update ()

    {
        
        FishControl fishScript = fishy.GetComponent<FishControl>();

        fishPos = fishy.transform.position;
        jumpTime = fishScript.jumpTime;
        jumpLen = fishScript.jumpLen;
        jumpDone = fishScript.jumpDone;
        fishSpeed = fishScript.speed;

       

        if(jumpTime > 0 && ripDone == false)
        {
            if (Time.fixedTime >= (jumpTime + jumpLen)+0.3f)
            {
                transform.position = fishPos;
                anim.Play("FishRipEffect");      
                Debug.Log("Ripple");
                ripDone = true;
                //fishSpeed = 0.02f;
            }
        }

        if(jumpDone == true)
        {
            ripDone = false;
        }


	}
}
