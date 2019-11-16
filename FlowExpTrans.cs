using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowExpTrans : MonoBehaviour {

    
    private GameObject slider;
    public GameObject gameManage;
    private string levelStr;
    private int flowID;

    private void Start()
    {
        //Setting up gradients
     


        ParticleSystem ps = GetComponent<ParticleSystem>();
      
    }


    public void FlowGoBang(Vector3 flowPos)
    {
        FlowRuntime flowRun = gameManage.GetComponent<FlowRuntime>();
        levelStr = flowRun.levelNo;
        FlowMgmt101 flowMgmt101 = gameManage.GetComponent<FlowMgmt101>();
        FlowMgmt102 flowMgmt102 = gameManage.GetComponent<FlowMgmt102>();
        FlowMgmt103 flowMgmt103 = gameManage.GetComponent<FlowMgmt103>();
        FlowMgmt104 flowMgmt104 = gameManage.GetComponent<FlowMgmt104>();
        FlowMgmt201 flowMgmt201 = gameManage.GetComponent<FlowMgmt201>();

        if (levelStr == "101")
        {
            flowID = flowMgmt101.flowID;
        }

        else if(levelStr == "102")
        {
            flowID = flowMgmt102.flowID;
        }

        else if (levelStr == "103")
        {
            flowID = flowMgmt103.flowID;

        }

        else if(levelStr == "104")
        {
            flowID = flowMgmt104.flowID;
        }

        else if (levelStr == "201")
        {
            flowID = flowMgmt201.flowID;
        }
        

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
