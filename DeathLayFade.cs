using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathLayFade : MonoBehaviour {

    private Graphic fade;
    public static bool fading;
    public GameObject canvas;
    
	// Use this for initialization
	void Start ()
    {
        //fade.enabled = false;
        //fading = false;
	}
	
	// Update is called once per frame
	void FixedUpdate ()

    {
        DeathScreenBehave deathScreenScript = canvas.GetComponent<DeathScreenBehave>();

        bool skullSpawn = deathScreenScript.skullSpawn;

        fade = GetComponent<Graphic>();

        if (skullSpawn == true)
        {
            fade.color += new Color32(0, 0, 0, 2);
            //Color32 checkCol = fade.color;

                if (System.Math.Round(fade.color.a,1) == 1)
                {
                
                    fade.color = new Color32(0, 0, 0, 255);
                    fading = false;
                } 
            

        }

    }
}
