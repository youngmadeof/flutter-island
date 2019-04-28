using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowExpTrans : MonoBehaviour {

    
    private GameObject slider;
    public GameObject gameManage;

    private void Start()
    {
        //Setting up gradients
     


        ParticleSystem ps = GetComponent<ParticleSystem>();
      
    }


    public void FlowGoBang(Vector3 flowPos)
    {
        FlowMgmt flowMgmt = gameManage.GetComponent<FlowMgmt>();
        int flowID = flowMgmt.flowID;

        ParticleSystem ps = GetComponent<ParticleSystem>();
        var psMain = ps.main;
        Gradient g;
        GradientColorKey[] gck;
        GradientAlphaKey[] gak;

        if (flowID == 0)
        {            
            g = new Gradient();
            gck = new GradientColorKey[2];
            gck[0].color = Color.red;
            gck[0].time = 0.0F;
            gck[1].color = Color.yellow;
            gck[1].time = 1.0F;
            gak = new GradientAlphaKey[2];
            gak[0].alpha = 1.0F;
            gak[0].time = 0.0F;
            gak[1].alpha = 1.0F;
            gak[1].time = 1.0F;
            g.SetKeys(gck, gak);
            psMain.startColor = g;
        }

        else if (flowID == 1)
        {
            g = new Gradient();
            gck = new GradientColorKey[2];
            gck[0].color = Color.yellow;
            gck[0].time = 0.2F;
            gck[1].color = Color.red;
            gck[1].time = 1.0F;
            gak = new GradientAlphaKey[2];
            gak[0].alpha = 5.0F;
            gak[0].time = 0.0F;
            gak[1].alpha = 1.0F;
            gak[1].time = 1.0F;
            g.SetKeys(gck, gak);
            psMain.startColor = g;
        }

        else if (flowID == 2)
        {
            g = new Gradient();
            gck = new GradientColorKey[2];
            gck[0].color = Color.blue;
            gck[0].time = 0.2F;
            gck[1].color = Color.black;
            gck[1].time = 1.0F;
            gak = new GradientAlphaKey[2];
            gak[0].alpha = 5.0F;
            gak[0].time = 0.0F;
            gak[1].alpha = 1.0F;
            gak[1].time = 1.0F;
            g.SetKeys(gck, gak);
            psMain.startColor = g;
        }

        transform.position = flowPos;
        GetComponent<ParticleSystem>().Play();
    }

}
