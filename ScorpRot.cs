using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpRot : MonoBehaviour
{
    private float dxRot;
    private float dyRot;
    private float dxPos;
    private float dyPos;
    public bool boolRestRot;
    public bool boolRotDone;
    // Update is called once per frame
    void Update()
    {
        Scorp_Behaviour scorBehavScrpt = GetComponent<Scorp_Behaviour>();
       

        if (scorBehavScrpt.boolRestRot)
        {
            dxPos = scorBehavScrpt.dxPos;
            dyPos = scorBehavScrpt.dyPos;

            float cx = transform.up.x;
            float cy = transform.up.y;

            float currentAngle = Mathf.Atan2(cy, cx);

            dxRot = dxPos - transform.position.x;
            dyRot = dyPos - transform.position.y;

            float dirAngle = Mathf.Atan2(dyRot, dxRot);

            transform.Rotate(0, 0, -1 * 35 * Time.deltaTime);

            Debug.Log(currentAngle + " currentangle");
            Debug.Log(dirAngle + " dirangle");

            if (System.Math.Round(currentAngle, 2) == System.Math.Round(dirAngle, 2))
            {

                scorBehavScrpt.boolRestRot = false;
                boolRotDone = true;
                
            }
        }







    }
}
