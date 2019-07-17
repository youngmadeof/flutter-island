using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CountdownTimer : MonoBehaviour
{
    private float countdownTimerStartTime;
    private int countdownTimerDuration;
    public GameObject gameManage;
    private int levelInt;
    private int addTime;

    //-----------------------------
    public int GetTotalSeconds()
    {
        return countdownTimerDuration;
    }

    //-----------------------------
    public void ResetTimer(int seconds)
    {
        countdownTimerStartTime = Time.time;
        countdownTimerDuration = seconds;
    }

    //-----------------------------
    public int GetSecondsRemaining()
    {
        FlowRuntime flowRun = gameManage.GetComponent<FlowRuntime>();
        levelInt = flowRun.levelNo;
        FlowMgmt flowMgmt = gameManage.GetComponent<FlowMgmt>();
        FlowMgmt_L2 flowMgmt2 = gameManage.GetComponent<FlowMgmt_L2>();

        if(levelInt == 1)
        {
            addTime = flowMgmt.hitMeUp;
        }
        
        if (levelInt == 2)
        {
            addTime = flowMgmt2.hitMeUp;
        }

        int elapsedSeconds = (int)((Time.time - countdownTimerStartTime) -addTime);

        int secondsLeft = (countdownTimerDuration - (elapsedSeconds));
        return secondsLeft;


    }

    //-----------------------------
    public float GetProportionTimeRemaining()
    {
        float proportionLeft = (float)GetSecondsRemaining() / (float)GetTotalSeconds();
        return proportionLeft;
    }
}

