using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreenBehave : MonoBehaviour {

    public GameObject skull;
    public GameObject butt;
    public GameObject slider;
    private int buttState;
    Vector3 startSize;
    Vector3 endSize;
    public bool skullSpawn;
    public static Vector3 currSize;
    private float getStartTime;
    public static string lastScene;


    private void Awake()
    {
        endSize = skull.GetComponent<RectTransform>().localScale;
        startSize = new Vector3(0f, 0f, 1.0f);
        skull.GetComponent<RectTransform>().localScale = startSize;


    }

    public void Start()
    {
        currSize = startSize;
        skullSpawn = true;
    }


    void FixedUpdate ()

    {
        BFly_Collision buttScript = butt.GetComponent<BFly_Collision>();
        buttState = buttScript.curState;

        if (buttState == 1)
        {

            //getStartTime = Time.time;
            //Debug.Log(getStartTime);
            //skullSpawn = true;
            lastScene = SceneManager.GetActiveScene().name;
            Resize();
    

        }
        


       

    }

    private void Resize()
    {
        if(skullSpawn == true)
        {
            skull.SetActive(true);
           
            skullSpawn = false;
            SliderTimerDisplay slidTimer = slider.GetComponent<SliderTimerDisplay>();
            slidTimer.enabled = false;
          
        }

        if(System.Math.Round(currSize.x, 2) < 0.70f)
        {
            skull.GetComponent<RectTransform>().localScale += new Vector3(0.02f, 0.02f, 0f);
            currSize = skull.GetComponent<RectTransform>().localScale;
      
            if (System.Math.Round(currSize.x, 2) >= 0.70f)
            {
                
                
                if(DeathLayFade.fading == false)
                {
                    skullSpawn = false;
                    SceneManager.LoadScene("GameIsDoneded");
                }
                
            }

        }
       


    }
}
