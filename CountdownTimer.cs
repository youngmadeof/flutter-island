using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CountdownTimer : MonoBehaviour
{
    private float countdownTimerStartTime;
    private int countdownTimerDuration;
    public GameObject gameManage;
    public GameObject butt;
    private bool buttDamage;
    private string levelStr;
    private int addTime;
    private int minusTime;
    public int count;

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
        levelStr = flowRun.levelNo;
        FlowMgmt101 flowMgmt101 = gameManage.GetComponent<FlowMgmt101>();
        FlowMgmt102 flowMgmt102 = gameManage.GetComponent<FlowMgmt102>();
        FlowMgmt103 flowMgmt103 = gameManage.GetComponent<FlowMgmt103>();
        FlowMgmt104 flowMgmt104 = gameManage.GetComponent<FlowMgmt104>();
        FlowMgmt105 flowMgmt105 = gameManage.GetComponent<FlowMgmt105>();
        FlowMgmt201 flowMgmt201 = gameManage.GetComponent<FlowMgmt201>();
        BFly_Collision buttColl = butt.GetComponent<BFly_Collision>();
        buttDamage = buttColl.doDamageCol;

        if (levelStr == "101")
        {
            addTime = flowMgmt101.hitMeUp;
        }

        if(levelStr == "102")
        {
            addTime = flowMgmt102.hitMeUp;
        }
        
        if (levelStr == "103")
        {
            addTime = flowMgmt103.hitMeUp;
        }

        if(levelStr == "104")
        {
            addTime = flowMgmt104.hitMeUp;
        }

        if(levelStr == "105")
        {
            addTime = flowMgmt105.hitMeUp;
        }
              

        if (levelStr == "201")
        {
            addTime = flowMgmt201.hitMeUp;
        }

        if(buttDamage == true && count == 0)
        {
            minusTime = buttColl.damageVal + minusTime;
            Debug.Log(minusTime + " minusTime");
            buttDamage = false;
            count += 1;
        }



        int elapsedSeconds = (int)((Time.time - countdownTimerStartTime) -addTime + minusTime);
        //Debug.Log(elapsedSeconds + " elapsedSeconds");
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

