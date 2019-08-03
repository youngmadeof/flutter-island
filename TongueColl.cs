using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueColl : MonoBehaviour {


    private Animator animator;
    private int bloomHash;
    public bool animDone;

    Collider2D tongueColl;

    // Use this for initialization
    void Start ()
    {
        animDone = false;
	}

    // Update is called once per frame
    private void Update()
    {
        //OH THIS STUFF NEEDS TO BE IN AN UPDATE
        bloomHash = Animator.StringToHash("Base Layer.Tongue");
       // Debug.Log(bloomHash + " animation");
        animator = GetComponent<Animator>();
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
       // Debug.Log(stateInfo.length + " anim len");
        //Debug.Log(stateInfo.normalizedTime + " anim time");

        if (stateInfo.length > 0)
        {
            if (stateInfo.normalizedTime >= stateInfo.length +1f /*&& animDone == false*/)
            {

                animDone = true;
                gameObject.SetActive(false);

                

                Debug.Log(animDone + " animDone");


            }

        }

    }
}
