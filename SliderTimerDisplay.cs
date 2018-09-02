using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SliderTimerDisplay : MonoBehaviour
{
    private CountdownTimer countdownTimer;
    private Slider sliderUI;
    public int startSeconds;
    public float healthRemain;

  
    void Start()
    {
        SetupSlider();
        SetupTimer();


    }

    void Update()
    {

        sliderUI.value = countdownTimer.GetProportionTimeRemaining();
        healthRemain = countdownTimer.GetProportionTimeRemaining();

        //Comment out for now!
        //if(healthRemain == 0)
        //{
        //SceneManager.LoadScene("GameIsDoneded");
        //}

    }

    private void SetupSlider()
    {
        sliderUI = GetComponent<Slider>();
        sliderUI.minValue = 0;
        sliderUI.maxValue = 1;
        sliderUI.wholeNumbers = false;
    }

    private void SetupTimer()
    {
        countdownTimer = GetComponent<CountdownTimer>();
        countdownTimer.ResetTimer(startSeconds);
    }

   


}
