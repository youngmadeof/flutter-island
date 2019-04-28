using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CountdownTimer : MonoBehaviour
{
    private float countdownTimerStartTime;
    private int countdownTimerDuration;
    public GameObject gameManage;

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

        FlowMgmt flowMgmt = gameManage.GetComponent<FlowMgmt>();
        int addTime = flowMgmt.hitMeUp;
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

