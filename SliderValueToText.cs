using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderValueToText : MonoBehaviour {

    public UnityEngine.UI.Slider sliderUI;
    private UnityEngine.UI.Text textSliderValue;


    // Use this for initialization
    void Start()
    {

        textSliderValue = GetComponent<UnityEngine.UI.Text>();
        ShowSliderValue();
    }
	
    public void ShowSliderValue()
    {
        string sliderMessage = "Slider value = " + sliderUI.value;
        textSliderValue.text = sliderMessage;

    }
	
}
