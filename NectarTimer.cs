using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NectarTimer : MonoBehaviour
{
    private float nectarTimerStartTime;
    private float nectarTimerDuration;
   // private Flower_Anim flowerTime;

    public float NectarTotalSeconds()
    {
        return nectarTimerDuration;
    }

    public void NectarTimerReset(float seconds)
    {
        //flowerTime = GetComponent<Flower_Anim>();
        nectarTimerStartTime = Time.time;
        nectarTimerDuration = seconds;
    }

    public float NectarSecondsRemaining()
    {
        float elapsedSeconds = (float)(Time.time - nectarTimerStartTime);
        float secondsLeft = (nectarTimerDuration - elapsedSeconds);
        return secondsLeft; 
    }

    public float NectarProportionTimeRemain()
    {
        float proportionLeft = (float)NectarSecondsRemaining() / (float)NectarTotalSeconds();
        //Debug.Log(proportionLeft);
        return proportionLeft;
    }


}
