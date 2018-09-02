using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CountdownTimer : MonoBehaviour
{
    private float countdownTimerStartTime;
    private int countdownTimerDuration;

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

        //SliderTimerDisplay slider = GetComponent<SliderTimerDisplay>();
        //int addTime = slider.hitMeUp;
        FlowMgmt flowMgmt = GetComponent<FlowMgmt>();
        int addTime = flowMgmt.hitMeUp;
        //Debug.Log("add time " + addTime);
        int elapsedSeconds = (int)((Time.time - countdownTimerStartTime) -addTime);
        //Debug.Log("elapsed seconds " + elapsedSeconds);

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

