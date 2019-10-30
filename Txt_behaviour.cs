using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Txt_behaviour : MonoBehaviour
{

    public GameObject txtThere;
    public GameObject txtYou;
    public GameObject txtAre;
    public GameObject buttImage;

    public GameObject startBtn;
    public GameObject optionsBtn;

    private Graphic fade1;
    private Graphic fade2;
    private Graphic fade3;
    private Graphic fade4;

    private float nextTime;
    public bool fadeInDone;
    private bool fadeOutDone;
    private bool buttons;


    private void Start()
    {
        
        fade1 = txtThere.GetComponent<Graphic>();
        fade2 = txtAre.GetComponent<Graphic>();
        fade3 = txtYou.GetComponent<Graphic>();
        fade4 = buttImage.GetComponent<Graphic>();
        

        fade1.color = new Color32(28, 198, 204, 0);
        fade2.color = new Color32(28, 198, 204, 0);
        fade3.color = new Color32(28, 198, 204, 0);
        fade4.color = new Color32(248, 248, 248, 0);
        txtThere.SetActive(true);
        txtAre.SetActive(true);
        txtYou.SetActive(true);
        nextTime = Mathf.Round(Time.fixedTime);

    }

    void FixedUpdate()
    {


        if(fadeInDone == false)
        {
            if(nextTime + 1 == Mathf.Round(Time.fixedTime))
            {
                fade4.color += new Color32(0, 0, 0, 8);
            }
         

            if (nextTime + 2 == Mathf.Round(Time.fixedTime))
            {
                fade1.color += new Color32(0, 0, 0, 8);
            }

            if (nextTime + 4 == Mathf.Round(Time.fixedTime))
            {
                fade2.color += new Color32(0, 0, 0, 8);
            }

            if (nextTime + 6 == Mathf.Round(Time.fixedTime))
            {
                fade3.color += new Color32(0, 0, 0, 8);
            }


            if (nextTime + 8 == Mathf.Round(Time.fixedTime))
            {
                fadeInDone = true;
            }
        }

        if (fadeInDone == true && fadeOutDone == false)
        {
            fade1.color -= new Color32(0, 0, 0, 4);
            fade2.color -= new Color32(0, 0, 0, 4);
            fade3.color -= new Color32(0, 0, 0, 4);

            Debug.Log(System.Math.Round(fade2.color.a,1));

            if (System.Math.Round(fade2.color.a, 1) == 0.2)
            {
                fadeOutDone = true;
            }

        }

        if(fadeOutDone == true && buttons == false)
        {
            startBtn.SetActive(true);
            optionsBtn.SetActive(true);
            buttons = true;
        }

    }
}
