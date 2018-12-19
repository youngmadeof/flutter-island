using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFly_LHealth : MonoBehaviour {


    SpriteRenderer m_SpriteRenderer;
    Color32 lowHealthColor;
    Color normColor;
    Color lerpColor;

    private GameObject slider;
    public bool lowHealth;

    // Use this for initialization
    void Start ()

    {
        slider = GameObject.Find("Slider");
        lowHealthColor = new Color32(244,66,133,255);
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        normColor = m_SpriteRenderer.color;

    }

    // Update is called once per frame
    void Update ()
    {
        SliderTimerDisplay sliderTimerDisplay = slider.GetComponent<SliderTimerDisplay>();
        lowHealth = sliderTimerDisplay.lowHealth;

        if (lowHealth == true)
        {
            lerpColor = Color.Lerp(normColor, lowHealthColor, Mathf.PingPong(Time.time, 1));
            m_SpriteRenderer.color = lerpColor;
        }

        else
        {
            m_SpriteRenderer.color = normColor;
        }
    }
}
