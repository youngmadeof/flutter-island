﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialsMgmt : MonoBehaviour {

    //Grab flower sequence and put in array
    //flowID + next flower
    // Use this for initialization
    public GameObject cloudFlow;
    public GameObject bombFlow;
    public GameObject lilly;
    public GameObject butt;

    ArrayList flowSeq = new ArrayList();
    private string strFlowSeq;

	public void CloudFlowSpesh (int flowID, int nextFlower)

    {
        
        int seqBuild = int.Parse(nextFlower.ToString() + flowID.ToString());
        flowSeq.Add(seqBuild);

        strFlowSeq = "";
        
        if(nextFlower >= 4)
        {
            for (int i = 3; i <= flowSeq.Count -1; i++)
            {
                strFlowSeq += flowSeq[i];
                Debug.Log(strFlowSeq);
            }


        }

        if(strFlowSeq == "41516070")
        {
            cloudFlow.SetActive(true);
            cloudFlow.transform.position = new Vector3(-0.75f, 1.78f, 0f);
        }
                     
    }

    

    
	

}
