using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog_Controller : MonoBehaviour {

    private Rigidbody2D rb2d;

    Animator anim;

    public GameObject lil01;
    public GameObject lil02;
    public GameObject lil03;
    public GameObject lil04;
    public GameObject lil05;

    private bool toLil01;
    private bool toLil02;
    private bool toLil03;
    private bool toLil04;
    private bool toLil05;

    public int curState;

    private enum State
    {
        idle,
        leap
    }

	// Use this for initialization
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        toLil02 = true;

        curState = (int)State.leap;
    }
	
	void FixedUpdate()
    {
        MoveToPad();
	}

    private void MoveToPad()
    {
        Vector3 currentPos = transform.position;

        Vector3 lilPos01 = lil01.transform.position;
        Vector3 lilPos02 = lil02.transform.position;
        Vector3 lilPos03 = lil03.transform.position;
        Vector3 lilPos04 = lil04.transform.position;
        Vector3 lilPos05 = lil05.transform.position;

        Quaternion lilRot02 = lil02.transform.rotation;
        Quaternion lilRot03 = lil03.transform.rotation;

        if (curState == (int)State.leap)
        {
            anim.SetBool("IdleToLeap", true);

            if(toLil02==true)
            {
                
                transform.position += (lilPos02 - currentPos) * 0.1f;

                if (Vector3.Distance(currentPos, lilPos02) <= 0.1f)
                {
                    anim.SetBool("IdleToLeap", false);
                }

                float angle = Vector2.Angle(transform.position, lilPos02);
                float frogAngle = Vector2.Angle(transform.up, transform.position);

                

                transform.rotation = Quaternion.Slerp(transform.rotation, lilRot03, 0.1f);
            }
        }



    }
}
