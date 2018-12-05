﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FlowMgmt : MonoBehaviour
{

    public bool flowerTopUp;
    public int hitMeUp;
    public bool getFlowerTopUp;
    public int nextFlower;

    private Text textUI;

    public int flowGroup;
    private int hitMeUpAdd;

    private bool yellFlowerTopUp;
    private bool redFlowerTopUp;
    private bool redFlowerTopUp2;
    private bool redFlowerTopUp3;
    private bool yellFlowerTopUp2;

    private int yellHitMeUpAdd;
    private int yellHitMeUpAdd2;
    private int redHitMeUpAdd;
    private int redHitMeUpAdd2;
    private int redHitMeUpAdd3;


    private bool yellFlowDone;
    private bool redFlowDone;
    private bool yellFlow2Done;
    private bool redFlow3Done;
    private bool redFlow4Done;

    private bool waitForFlow;

    //All yer flowers in here
    public GameObject redFlow;
    public GameObject yellFlow;
    public GameObject redFlow2;
    public GameObject yellFlow2;
    public GameObject redFlow3;
    public GameObject redFlow4;
    public GameObject yellFlow3;
    public GameObject yellFlow4;
    public GameObject redFlow5;
    public GameObject yellFlow5;

    //Slap all the Flower_Anim gumph in here
    private GameObject flowAnimRed;
    private GameObject flowAnimYel;
    public bool flowAnimDone;
    public bool flowAnimDone2;


    private void Awake()
    {
        yellFlow.SetActive(false);
        redFlow2.SetActive(false);
        yellFlow2.SetActive(false);
        redFlow3.SetActive(false);
        redFlow4.SetActive(false);
        yellFlow3.SetActive(false);
        yellFlow4.SetActive(false);
        yellFlow5.SetActive(false);
        redFlow5.SetActive(false);


    }

    private void Start()
    {
        getFlowerTopUp = true;
        nextFlower = 0;
        flowGroup = 0;
        textUI = GameObject.Find("Text").GetComponent<Text>();
        waitForFlow = false;

    }
    // Update is called once per frame
    void Update()
    {
        FlowerTopUp();
    }


    private void FlowerTopUp()
    {
        if(getFlowerTopUp == false)
        {
            FlowSpawn();
        }
   

        if (getFlowerTopUp == true)
        {

            
            if (flowGroup == 0)
            {
                //GameObject redFlow = GameObject.Find("Flower");
                Flower_Anim flowerScript = redFlow.GetComponent<Flower_Anim>();                
                flowerTopUp = flowerScript.flowerDrained;
                hitMeUpAdd = flowerScript.hitMeUp + hitMeUp;

                if(flowerTopUp == true)
                {
                    redFlow.SetActive(false);
                }
                HitMeUp();

            }

            else if (flowGroup == 1)
            {
                Flower_Anim flowerScript1 = yellFlow.GetComponent<Flower_Anim>();
                yellFlowerTopUp = flowerScript1.flowerDrained;
                yellHitMeUpAdd = flowerScript1.hitMeUp + hitMeUp;

                Flower_Anim flowerScript2 = redFlow2.GetComponent<Flower_Anim>();
                redFlowerTopUp = flowerScript2.flowerDrained;
                redHitMeUpAdd = flowerScript2.hitMeUp + hitMeUp;

                if (yellFlowerTopUp == true && yellFlowDone == false)
                {
                    flowerTopUp = yellFlowerTopUp;
                    hitMeUpAdd = yellHitMeUpAdd;
                    HitMeUp();
                    yellFlowDone = true;
                    getFlowerTopUp = true;
                    yellFlow.SetActive(false);


                }
                else if (redFlowerTopUp == true && redFlowDone == false)
                {
                    flowerTopUp = redFlowerTopUp;
                    hitMeUpAdd = redHitMeUpAdd;
                    HitMeUp();
                    redFlowDone = true;
                    getFlowerTopUp = true;
                    redFlow2.SetActive(false);
                 
                }

                if(redFlowDone == true && yellFlowDone == true)
                {
                    getFlowerTopUp = false;//needed to initiate flower spawn
                }

                


            }

            else if (flowGroup == 2)
            {
                Flower_Anim flowerScript1 = yellFlow2.GetComponent<Flower_Anim>();
                yellFlowerTopUp = flowerScript1.flowerDrained;
                yellHitMeUpAdd = flowerScript1.hitMeUp + hitMeUp;

                if (yellFlowerTopUp == true && yellFlow2Done == false)
                {
                    flowerTopUp = yellFlowerTopUp;
                    hitMeUpAdd = yellHitMeUpAdd;
                    HitMeUp();
                    yellFlow2Done = true;
                    getFlowerTopUp = false;
                    yellFlow2.SetActive(false);
                }
            }

            else if (flowGroup == 3)
            {
                Flower_Anim flowerScript = redFlow3.GetComponent<Flower_Anim>();
                redFlowerTopUp = flowerScript.flowerDrained;
                redHitMeUpAdd = flowerScript.hitMeUp + hitMeUp;

                Flower_Anim flowerScript1 = redFlow4.GetComponent<Flower_Anim>();
                redFlowerTopUp2 = flowerScript1.flowerDrained;
                redHitMeUpAdd2 = flowerScript1.hitMeUp + hitMeUp;

                Flower_Anim flowerScript2 = yellFlow3.GetComponent<Flower_Anim>();
                yellFlowerTopUp = flowerScript2.flowerDrained;
                yellHitMeUpAdd = flowerScript2.hitMeUp + hitMeUp;

                if (redFlowerTopUp == true && redFlow3Done == false)
                {
                    flowerTopUp = redFlowerTopUp;
                    hitMeUpAdd = redHitMeUpAdd;
                    HitMeUp();
                    redFlow3Done = true;
                    //ensure you keep the process going
                    getFlowerTopUp = true;
                    redFlow3.SetActive(false);
                }

                if (redFlowerTopUp2 == true && redFlow4Done == false)
                {
                    flowerTopUp = redFlowerTopUp2;
                    hitMeUpAdd = redHitMeUpAdd2;
                    HitMeUp();
                    redFlow4Done = true;
                    getFlowerTopUp = true;
                    redFlow4.SetActive(false);

                }

                if (yellFlowerTopUp == true && yellFlowDone == false)
                {
                    flowerTopUp = yellFlowerTopUp;
                    hitMeUpAdd = yellHitMeUpAdd;
                    HitMeUp();
                    yellFlowDone = true;
                    getFlowerTopUp = true;
                    yellFlow3.SetActive(false);
                }

                if (redFlow3Done == true && redFlow4Done == true && yellFlowDone == true)
                {
                    getFlowerTopUp = false;
                }
            }

            else if (flowGroup == 4)
            {
                Flower_Anim flowerScript = yellFlow4.GetComponent<Flower_Anim>();
                yellFlowerTopUp = flowerScript.flowerDrained;
                yellHitMeUpAdd = flowerScript.hitMeUp + hitMeUp;

                Flower_Anim flowerScript2 = yellFlow5.GetComponent<Flower_Anim>();
                yellFlowerTopUp2 = flowerScript2.flowerDrained;
                yellHitMeUpAdd2 = flowerScript2.hitMeUp + hitMeUp;

                Flower_Anim flowerScript3 = redFlow5.GetComponent<Flower_Anim>();
                redFlowerTopUp = flowerScript3.flowerDrained;
                redHitMeUpAdd = flowerScript3.hitMeUp + hitMeUp;

                if(yellFlowerTopUp == true && yellFlowDone == false)
                {
                    flowerTopUp = yellFlowerTopUp;
                    hitMeUpAdd = yellHitMeUpAdd;
                    HitMeUp();
                    yellFlowDone = true;
                    getFlowerTopUp = true;  
                    yellFlow4.SetActive(false);

                }

                if(yellFlowerTopUp2 == true && yellFlow2Done == false)
                {
                    flowerTopUp = yellFlowerTopUp2;
                    hitMeUpAdd = yellHitMeUpAdd2;
                    HitMeUp();
                    yellFlow2Done = true;
                    getFlowerTopUp = true;
                    yellFlow5.SetActive(false);
                }

                if(redFlowerTopUp == true && redFlowDone == false)
                {
                    flowerTopUp = redFlowerTopUp;
                    hitMeUpAdd = redHitMeUpAdd;
                    HitMeUp();
                    redFlowDone = true;
                    getFlowerTopUp = true;
                    redFlow5.SetActive(false);

                }

            }


        }

    }

    public void HitMeUp()
    {

        if (flowerTopUp == true)
        {
            hitMeUp = hitMeUpAdd;
            //Debug.Log("Hit me up " + hitMeUpAdd);
            flowerTopUp = false;
            getFlowerTopUp = false;
            nextFlower += 1;
            textUI.text = nextFlower + "/20";            

        }
    }

    public void FlowSpawn()
    {
        if (nextFlower == 1)
        {
            Flower_Anim flowAnimRedScript = redFlow2.GetComponent<Flower_Anim>(); 
            flowAnimDone = flowAnimRedScript.animDone;

            redFlow2.SetActive(true);

            if (flowAnimDone == true)
            {                
                flowAnimDone = flowAnimRedScript.animDone;
                yellFlow.SetActive(true);
                getFlowerTopUp = true;
                flowGroup += 1;
            }
            

        }

        if (nextFlower == 3)
        {
            yellFlow2.SetActive(true);
            //Clear down previous flower groups variables
            yellFlowDone = false;
            redFlowDone = false;
            getFlowerTopUp = true;
            yellHitMeUpAdd = 0;
            flowGroup += 1;

        }

        if (nextFlower == 4)
        {
            redFlow3.SetActive(true);
            Flower_Anim flowAnimRedScript = redFlow3.GetComponent<Flower_Anim>();
            flowAnimDone = flowAnimRedScript.animDone;

            if(flowAnimDone == true)
            {
                yellFlow3.SetActive(true);
                yellFlowDone = false;
                yellHitMeUpAdd = 0;
            }

            Flower_Anim flowAnimYellScript1 = yellFlow3.GetComponent<Flower_Anim>();
            flowAnimDone2 = flowAnimYellScript1.animDone;

            if(flowAnimDone2 == true)
            {
                redFlow4.SetActive(true);                
                getFlowerTopUp = true;//remember needed at the end of each group. IT'S A BLOODY REQUIREMENT NOT AN OPTION!
                //Clear down previous flower groups variables
                redFlowDone = false;                
                flowGroup += 1;
            }


            
        }
        if(nextFlower == 7)
        {
            yellFlow4.SetActive(true);
            Flower_Anim flowAnimYellScript = yellFlow4.GetComponent<Flower_Anim>();
            flowAnimDone = flowAnimYellScript.animDone;

            if(flowAnimDone == true)
            {
                yellFlow5.SetActive(true);
            }

            Flower_Anim flowAnimYellScript2 = yellFlow5.GetComponent<Flower_Anim>();
            flowAnimDone2 = flowAnimYellScript2.animDone;

            if(flowAnimDone2 == true)
            {
                redFlow5.SetActive(true);
                getFlowerTopUp = true;
                //Clear down previous flower groups variables
                yellFlowDone = false;
                redFlow3Done = false;
                redFlow4Done = false;
                yellFlow2Done = false;
                redHitMeUpAdd2 = 0;
                redHitMeUpAdd3 = 0;
                yellHitMeUpAdd = 0;
                flowGroup += 1;
            }
        }


    }


}