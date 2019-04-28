using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FlowMgmt : MonoBehaviour
{
    private SpecialsMgmt specMan;
    public bool flowerTopUp;
    public int hitMeUp;
    public bool getFlowerTopUp;
    public int nextFlower;

    //private Text textUI;

    public int flowGroup;
    private int hitMeUpAdd;

    private bool yellFlowerTopUp;
    private bool redFlowerTopUp;
    private bool redFlowerTopUp2;
    private bool redFlowerTopUp3;
    private bool yellFlowerTopUp2;
    private bool bluFlowerTopUp;

    private int yellHitMeUpAdd;
    private int yellHitMeUpAdd2;
    private int redHitMeUpAdd;
    private int redHitMeUpAdd2;
    private int redHitMeUpAdd3;
    private int bluHitMeUpAdd;


    private bool yellFlowDone;
    private bool redFlowDone;
    private bool yellFlow2Done;
    private bool redFlow3Done;
    private bool redFlow4Done;
    private bool bluFlowDone;

    public int flowID;
 
    //private bool waitForFlow;

    public List<GameObject> flowUIs = new List<GameObject>();

    public GameObject slidTimer;

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
    public GameObject redFlow6;
    public GameObject redFlow7;
    public GameObject redFlow8;
    public GameObject yellFlow6;
    public GameObject bluFlow;
    public GameObject redFlow9;
    public GameObject redFlow10;
    public GameObject redFlow11;
    public GameObject redFlow12;
    public GameObject yellFlow7;

    //Slap all the Flower_Anim gumph in here
    private GameObject flowAnimRed;
    private GameObject flowAnimYel;
    private GameObject flowAnimBlu;
    private bool flowAnimDone;
    private bool flowAnimDone2;

    private GameObject flowUICol;

    public GameObject flowExplode;
    public GameObject lastFlowExplode;
    private ParticleSystem ps;

    private Vector3 flowPos;

    public bool lastFlow;

    private bool timeStopped;

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
        redFlow6.SetActive(false);
        redFlow7.SetActive(false);
        redFlow8.SetActive(false);
        yellFlow6.SetActive(false);
        bluFlow.SetActive(false);
        redFlow9.SetActive(false);
        redFlow10.SetActive(false);
        redFlow11.SetActive(false);
        redFlow12.SetActive(false);
        yellFlow7.SetActive(false);
        
        for(int i = 0; i < flowUIs.Count; i++)
        {
            flowUIs[i].SetActive(false);
        }

    }

    private void Start()
    {
        getFlowerTopUp = true;
        nextFlower = 0;
        flowGroup = 0;
        //textUI = GameObject.Find("Text").GetComponent<Text>();
        //waitForFlow = false;



    }
    // Update is called once per frame
    void Update()
    {
        FlowerTopUp();
    }

    public void StopTimer()
    {
        SliderTimerDisplay slidTimerStop = slidTimer.GetComponent<SliderTimerDisplay>();
        float healthRemain = slidTimerStop.healthRemain;
        Debug.Log(healthRemain * 100);
        slidTimerStop.enabled = false;
        timeStopped = true;
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
                flowID = flowerScript.flowID;

                if (flowerTopUp == true)
                {
                    flowPos = redFlow.transform.position;//flow pos for partical effect

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
                    flowID = flowerScript1.flowID;
                    flowPos = yellFlow.transform.position;//flow pos for partical effect
                    HitMeUp();
                    yellFlowDone = true;
                    getFlowerTopUp = true;
                    yellFlow.SetActive(false);


                }
                else if (redFlowerTopUp == true && redFlowDone == false)
                {
                    flowerTopUp = redFlowerTopUp;
                    hitMeUpAdd = redHitMeUpAdd;
                    flowID = flowerScript2.flowID;
                    flowPos = redFlow2.transform.position;//flow pos for partical effect
                    HitMeUp();
                    redFlowDone = true;
                    getFlowerTopUp = true;
                    redFlow2.SetActive(false);

                }

                if (redFlowDone == true && yellFlowDone == true)
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
                    flowID = flowerScript1.flowID;
                    flowPos = yellFlow2.transform.position;//flow pos for partical effect
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
                    flowID = flowerScript.flowID;
                    flowPos = redFlow3.transform.position;//flow pos for partical effect
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
                    flowID = flowerScript1.flowID;
                    flowPos = redFlow4.transform.position;//flow pos for partical effect
                    HitMeUp();
                    redFlow4Done = true;
                    getFlowerTopUp = true;
                    redFlow4.SetActive(false);

                }

                if (yellFlowerTopUp == true && yellFlowDone == false)
                {
                    flowerTopUp = yellFlowerTopUp;
                    hitMeUpAdd = yellHitMeUpAdd;
                    flowID = flowerScript2.flowID;
                    flowPos = yellFlow3.transform.position;//flow pos for partical effect
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

                if (yellFlowerTopUp == true && yellFlowDone == false)
                {
                    flowerTopUp = yellFlowerTopUp;
                    hitMeUpAdd = yellHitMeUpAdd;
                    flowID = flowerScript.flowID;
                    flowPos = yellFlow4.transform.position;//flow pos for partical effect
                    HitMeUp();
                    yellFlowDone = true;
                    getFlowerTopUp = true;
                    yellFlow4.SetActive(false);

                }

                if (yellFlowerTopUp2 == true && yellFlow2Done == false)
                {
                    flowerTopUp = yellFlowerTopUp2;
                    hitMeUpAdd = yellHitMeUpAdd2;
                    flowID = flowerScript2.flowID;
                    flowPos = yellFlow5.transform.position;//flow pos for partical effect
                    HitMeUp();
                    yellFlow2Done = true;
                    getFlowerTopUp = true;
                    yellFlow5.SetActive(false);
                }

                if (redFlowerTopUp == true && redFlowDone == false)
                {
                    flowerTopUp = redFlowerTopUp;
                    hitMeUpAdd = redHitMeUpAdd;
                    flowID = flowerScript3.flowID;
                    flowPos = redFlow5.transform.position;//flow pos for partical effect
                    HitMeUp();
                    redFlowDone = true;
                    getFlowerTopUp = true;
                    redFlow5.SetActive(false);

                }

                if (yellFlowDone == true && yellFlow2Done == true && redFlowDone == true)
                {
                    getFlowerTopUp = false;
                }

            }
            else if (flowGroup == 5)
            {
                Flower_Anim flowerScript = redFlow6.GetComponent<Flower_Anim>();
                redFlowerTopUp = flowerScript.flowerDrained;
                redHitMeUpAdd = flowerScript.hitMeUp + hitMeUp;

                Flower_Anim flowerScript1 = redFlow7.GetComponent<Flower_Anim>();
                redFlowerTopUp2 = flowerScript1.flowerDrained;
                redHitMeUpAdd2 = flowerScript1.hitMeUp + hitMeUp;

                Flower_Anim flowerScript2 = redFlow8.GetComponent<Flower_Anim>();
                redFlowerTopUp3 = flowerScript2.flowerDrained;
                redHitMeUpAdd3 = flowerScript2.hitMeUp + hitMeUp;

                Flower_Anim flowerScript3 = yellFlow6.GetComponent<Flower_Anim>();
                yellFlowerTopUp = flowerScript3.flowerDrained;
                yellHitMeUpAdd = flowerScript3.hitMeUp + hitMeUp;

                //TODO: ADD flower checks 
                if (redFlowerTopUp == true && redFlowDone == false)
                {
                    flowerTopUp = redFlowerTopUp;
                    hitMeUpAdd = redHitMeUpAdd;
                    flowID = flowerScript.flowID;
                    flowPos = redFlow6.transform.position;//flow pos for partical effect
                    HitMeUp();
                    redFlowDone = true;
                    getFlowerTopUp = true;
                    redFlow6.SetActive(false);

                }

                if (redFlowerTopUp2 == true && redFlow3Done == false)
                {
                    flowerTopUp = redFlowerTopUp2;
                    hitMeUpAdd = redHitMeUpAdd2;
                    flowID = flowerScript1.flowID;
                    flowPos = redFlow7.transform.position;//flow pos for partical effect
                    HitMeUp();
                    redFlow3Done = true;
                    getFlowerTopUp = true;
                    redFlow7.SetActive(false);
                }

                if (redFlowerTopUp3 == true && redFlow4Done == false)
                {
                    flowerTopUp = redFlowerTopUp3;
                    hitMeUpAdd = redHitMeUpAdd3;
                    flowID = flowerScript2.flowID;
                    flowPos = redFlow8.transform.position;//flow pos for partical effect
                    HitMeUp();
                    redFlow4Done = true;
                    getFlowerTopUp = true;
                    redFlow8.SetActive(false);

                }

                if (yellFlowerTopUp == true && yellFlowDone == false)
                {
                    flowerTopUp = yellFlowerTopUp;
                    hitMeUpAdd = yellHitMeUpAdd;
                    flowID = flowerScript3.flowID;
                    flowPos = yellFlow6.transform.position;//flow pos for partical effect
                    HitMeUp();
                    yellFlowDone = true;
                    getFlowerTopUp = true;
                    yellFlow6.SetActive(false);

                }

                if (redFlowDone == true && redFlow3Done == true && redFlow4Done == true && yellFlowDone == true)
                {
                    getFlowerTopUp = false;
                }


            }

            else if (flowGroup == 6)
            {
                Flower_Anim flowerScript = bluFlow.GetComponent<Flower_Anim>();
                bluFlowerTopUp = flowerScript.flowerDrained;
                bluHitMeUpAdd = flowerScript.hitMeUp + hitMeUp;

                Flower_Anim flowerScript2 = redFlow9.GetComponent<Flower_Anim>();
                redFlowerTopUp = flowerScript2.flowerDrained;
                redHitMeUpAdd = flowerScript.hitMeUp + hitMeUp;

                if(bluFlowerTopUp == true && bluFlowDone == false)
                {
                    flowerTopUp = bluFlowerTopUp;
                    hitMeUpAdd = bluHitMeUpAdd;
                    flowID = flowerScript.flowID;
                    flowPos = bluFlow.transform.position;//flow pos for partical effect
                    HitMeUp();
                    bluFlowDone = true;
                    getFlowerTopUp = true;
                    bluFlow.SetActive(false);
                }

                if(redFlowerTopUp == true && redFlowDone == false)
                {
                    flowerTopUp = redFlowerTopUp;
                    hitMeUpAdd = redHitMeUpAdd;
                    flowID = flowerScript2.flowID;
                    flowPos = redFlow9.transform.position;//flow pos for partical effect
                    HitMeUp();
                    redFlowDone = true;
                    getFlowerTopUp = true;
                    redFlow9.SetActive(false);

                }

                if(redFlowerTopUp == true && bluFlowerTopUp == true && redFlowDone == true && bluFlowDone == true)
                {
                    getFlowerTopUp = false;
                }

            }

            else if (flowGroup == 7)
            {
                Flower_Anim flowerScript = redFlow10.GetComponent<Flower_Anim>();
                redFlowerTopUp = flowerScript.flowerDrained;
                redHitMeUpAdd = flowerScript.hitMeUp + hitMeUp;

                Flower_Anim flowerScript2 = redFlow11.GetComponent<Flower_Anim>();
                redFlowerTopUp2 = flowerScript2.flowerDrained;
                redHitMeUpAdd2 = flowerScript2.hitMeUp + hitMeUp;

                Flower_Anim flowerScript3 = redFlow12.GetComponent<Flower_Anim>();
                redFlowerTopUp3 = flowerScript3.flowerDrained;
                redHitMeUpAdd3 = flowerScript3.hitMeUp + hitMeUp;

                if(redFlowerTopUp == true && redFlowDone == false)
                {
                    flowerTopUp = redFlowerTopUp;
                    hitMeUpAdd = redHitMeUpAdd;
                    flowID = flowerScript.flowID;
                    flowPos = redFlow10.transform.position;//flow pos for partical effect
                    HitMeUp();
                    redFlowDone = true;
                    getFlowerTopUp = true;
                    redFlow10.SetActive(false);
                }
                if(redFlowerTopUp2 == true && redFlow3Done == false)
                {
                    flowerTopUp = redFlowerTopUp2;
                    hitMeUpAdd = redHitMeUpAdd2;
                    flowID = flowerScript2.flowID;
                    flowPos = redFlow11.transform.position;//flow pos for partical effect
                    HitMeUp();
                    redFlow3Done = true;
                    getFlowerTopUp = true;
                    redFlow11.SetActive(false);
                }
                if(redFlowerTopUp3 == true && redFlow4Done == false)
                {
                    flowerTopUp = redFlowerTopUp3;
                    hitMeUpAdd = redHitMeUpAdd3;
                    flowID = flowerScript3.flowID;
                    flowPos = redFlow12.transform.position;//flow pos for partical effect
                    HitMeUp();
                    redFlow4Done = true;
                    getFlowerTopUp = true;
                    redFlow12.SetActive(false);
                }

                if(redFlowDone == true && redFlow3Done == true && redFlow4Done == true)
                {
                    getFlowerTopUp = false;
                }
            }

            else if (flowGroup == 8)
            {
                Flower_Anim flowerScript = yellFlow7.GetComponent<Flower_Anim>();
                yellFlowerTopUp = flowerScript.flowerDrained;
                yellHitMeUpAdd = flowerScript.hitMeUp + hitMeUp;

                if(yellFlowerTopUp == true)
                {
                    flowerTopUp = yellFlowerTopUp;
                    hitMeUpAdd = yellHitMeUpAdd;
                    flowID = flowerScript.flowID;
                    flowPos = yellFlow7.transform.position;//flow pos for partical effect
                    lastFlow = true;
                    HitMeUp();
                    //getFlowerTopUp = true;
                    yellFlow7.SetActive(false);

                    if(timeStopped == false)
                    {
                        StopTimer();
                    }
                    
                    
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

            if(lastFlow == true)
            {
                LastFlowExplode getFlowBang = lastFlowExplode.GetComponent<LastFlowExplode>();
                getFlowBang.LastFlowBang(flowPos);
            }

            else
            {
                FlowExpTrans getFlowBang = flowExplode.GetComponent<FlowExpTrans>();
                getFlowBang.FlowGoBang(flowPos);
            }


            specMan = GetComponent<SpecialsMgmt>();
            specMan.CloudFlowSpesh(flowID,nextFlower);


            for (int i = nextFlower -1; i < nextFlower; i++)
            {

                flowUIs[i].SetActive(true);

                
                FlowUICol flowUIScript = flowUIs[i].GetComponent<FlowUICol>();

                flowUIScript.FlowColChange(ref flowID);

            }

           

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
        if(nextFlower == 10)
        {

            redFlow6.SetActive(true);
            Flower_Anim flowAnimRedScript = redFlow6.GetComponent<Flower_Anim>();
            flowAnimDone = flowAnimRedScript.animDone;

            if(flowAnimDone == true)
            {
                redFlow7.SetActive(true);
            }

            Flower_Anim flowAnimRedScript2 = redFlow7.GetComponent<Flower_Anim>();
            flowAnimDone2 = flowAnimRedScript2.animDone;

            if(flowAnimDone2 == true)
            {
                redFlow8.SetActive(true);
            }

            Flower_Anim flowAnimRedScript3 = redFlow8.GetComponent<Flower_Anim>();
            bool flowAnimDone3 = flowAnimRedScript3.animDone;

            if(flowAnimDone3 == true)
            {
                getFlowerTopUp = true;
                yellFlow6.SetActive(true);
                yellFlowDone = false;
                yellFlow2Done = false;
                redFlowDone = false;
                redHitMeUpAdd = 0;
                yellHitMeUpAdd = 0;
                yellHitMeUpAdd2 = 0;
                flowGroup += 1;
            }


        }

        if(nextFlower == 14)
        {
            bluFlow.SetActive(true);
            Flower_Anim flowAnimBluScript = bluFlow.GetComponent<Flower_Anim>();
            flowAnimDone = flowAnimBluScript.animDone;

            if(flowAnimDone == true)
            {
                redFlow9.SetActive(true);
                getFlowerTopUp = true;
                redFlowDone = false;
                redFlow3Done = false;
                redFlow4Done = false;
                yellFlowDone = false;
                redHitMeUpAdd = 0;
                redHitMeUpAdd2 = 0;
                redHitMeUpAdd3 = 0;
                yellHitMeUpAdd = 0;
                flowGroup += 1;

            }

        }

        if(nextFlower == 16)
        {
            redFlow10.SetActive(true);
            Flower_Anim flowAnimRedScript = redFlow10.GetComponent<Flower_Anim>();
            flowAnimDone = flowAnimRedScript.animDone;

            if(flowAnimDone == true)
            {
                redFlow11.SetActive(true);

            }

            Flower_Anim flowAnimRedScript2 = redFlow11.GetComponent<Flower_Anim>();
            flowAnimDone2 = flowAnimRedScript2.animDone;

            if (flowAnimDone2 == true)
            {
                redFlow12.SetActive(true);
                getFlowerTopUp = true;
                bluFlowDone = false;
                redFlowDone = false;
                bluHitMeUpAdd = 0;
                redHitMeUpAdd = 0;
                flowGroup += 1;
            }


        }
        if(nextFlower == 19)
        {
            yellFlow7.SetActive(true);
            getFlowerTopUp = true;
            redFlowDone = false;
            redFlow3Done = false;
            redFlow4Done = false;
            redHitMeUpAdd = 0;
            redHitMeUpAdd2 = 0;
            redHitMeUpAdd3 = 0;
            flowGroup += 1;
           
        }


    }


}