using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowRuntime : MonoBehaviour
{

    public GameObject slidTimer;
    public bool timeStopped;
    public string levelNo;
    private FlowMgmt101 flowerMgmt101;
    private FlowMgmt102 flowerMgmt102;
    private FlowMgmt103 flowerMgmt103;
    private FlowMgmt201 flowerMgmt201;


    // Update is called once per frame
    void Update()
    {

        if(levelNo == "101")
        {
            flowerMgmt101 = GetComponent<FlowMgmt101>();

            flowerMgmt101.FlowerTopUp();
        }

        else if(levelNo == "102")
        {
            flowerMgmt102 = GetComponent<FlowMgmt102>();
            flowerMgmt102.FlowerTopUp();
        }

        else if (levelNo == "103")
        {
            flowerMgmt103 = GetComponent<FlowMgmt103>();

            flowerMgmt103.FlowerTopUp();
        }

        else if (levelNo == "201")
        {
            flowerMgmt201 = GetComponent<FlowMgmt201>();

            flowerMgmt201.FlowerTopUp();
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
