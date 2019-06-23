using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowRuntime : MonoBehaviour
{

    public GameObject slidTimer;
    private bool timeStopped;
    public int levelNo;
    private FlowMgmt flowerMgmt1;
    private FlowMgmt_L2 flowerMgmt2;


    // Update is called once per frame
    void Update()
    {
        if (levelNo == 1)
        {
            flowerMgmt1 = GetComponent<FlowMgmt>();

            flowerMgmt1.FlowerTopUp();
        }

        else if (levelNo == 2)
        {
            flowerMgmt2 = GetComponent<FlowMgmt_L2>();

            flowerMgmt2.FlowerTopUp();
        }

    }



    public void StopTimer()
    {
        SliderTimerDisplay slidTimerStop = slidTimer.GetComponent<SliderTimerDisplay>();
        float healthRemain = slidTimerStop.healthRemain;
        Debug.Log(healthRemain * 100);
        slidTimerStop.enabled = false;
        timeStopped = true;
    }
}
