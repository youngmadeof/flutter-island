using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeshEnvColl : MonoBehaviour {

    public GameObject butt;
    public GameObject speshFlow;
    private int count = 0;
    private bool rezFlow;
    private Vector3 currSize;
    private bool shrink;
    private Vector3 origSize;
    public int level;
    private Vector3 target;

    private void Start()
    {
        origSize = speshFlow.transform.localScale;

        if(level == 1)
        {
            target = new Vector3(1.2f, -1.2f, 0f);
        }
        if(level == 2)
        {
            target = new Vector3(-3.2f, 0f, 0f);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == butt && count == 0)
        {
            
            count += 1;
            rezFlow = true;
        }
    }

    private void FixedUpdate()
    {
        if(rezFlow == true)
        {
            speshFlow.SetActive(true);

            speshFlow.transform.position += (target - speshFlow.transform.position)*0.2f;

            currSize = speshFlow.transform.localScale;

            float halfDist = Vector3.Distance(target, speshFlow.transform.position) / 2;

            float curDist = Vector3.Distance(target, speshFlow.transform.position);

            if (shrink == false)
            {
                speshFlow.transform.localScale += new Vector3(0.2f, 0.2f);
            }

            if (Mathf.Round(curDist) <= Mathf.Round(halfDist))

            {              


                if (System.Math.Round(currSize.y, 2) > origSize.y)

                {


                    if (System.Math.Round(currSize.y, 2) != origSize.y)

                    {
                        speshFlow.transform.localScale -= new Vector3(0.1f, 0.1f);
                        shrink = true;
                        
                   
                    }

                }

                if (System.Math.Round(currSize.y, 2) == origSize.y)
                {
                    rezFlow = false;
                }


            }
        }
    }


}
