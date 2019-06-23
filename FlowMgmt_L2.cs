using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FlowMgmt_L2 : MonoBehaviour
{
    private SpecialsMgmt specMan;
    public bool flowerTopUp;
    public int hitMeUp;
    public bool getFlowerTopUp;
    public int nextFlower;

    //private Text textUI;

    public int flowGroup;
    private int hitMeUpAdd;

    private bool flow1TopUp;
    private bool flow2TopUp;
    private bool flow3TopUp;
    private bool flow4TopUp;

    private int flow1HitMeUp;
    private int flow2HitMeUp;
    private int flow3HitMeUp;
    private int flow4HitMeUp;


    private bool flowDone1;
    private bool flowDone2;
    private bool flowDone3;
    private bool flowDone4;
    private bool flowDone5;
    private bool flowDone6;

    public int flowID;

    //private bool waitForFlow;

    public List<GameObject> flowUIs = new List<GameObject>();

    //public GameObject slidTimer;

    //All yer flowers in here
    public GameObject flow1;
    public GameObject flow2;
    public GameObject flow3;
    public GameObject flow4;
    public GameObject flow5;
    public GameObject flow6;
    public GameObject flow7;
    public GameObject flow8;
    public GameObject flow9;
    public GameObject flow10;
    public GameObject flow11;
    public GameObject flow12;
    public GameObject flow13;
    public GameObject flow14;
    public GameObject flow15;
    public GameObject flow16;
    public GameObject flow17;
    public GameObject flow18;
    public GameObject flow19;
    public GameObject flow20;

    //Slap all the Flower_Anim gumph in here
    private GameObject flowAnimRed;
    private GameObject flowAnimYel;
    private GameObject flowAnimBlu;
    private bool flowAnimDone;
    private bool flowAnimDone2;
    private bool flowAnimDone3;

    private GameObject flowUICol;

    public GameObject flowExplode;
    public GameObject lastFlowExplode;
    private ParticleSystem ps;

    private Vector3 flowPos;

    public bool lastFlow;

    private bool timeStopped;

    private void Awake()
    {
        flow1.SetActive(false);
        flow2.SetActive(false);
        flow3.SetActive(false);
        flow4.SetActive(false);
        flow5.SetActive(false);
        flow6.SetActive(false);
        flow7.SetActive(false);
        flow8.SetActive(false);
        flow9.SetActive(false);
        flow10.SetActive(false);
        flow11.SetActive(false);
        flow12.SetActive(false);
        flow13.SetActive(false);
        flow14.SetActive(false);
        flow15.SetActive(false);
        flow16.SetActive(false);
        flow17.SetActive(false);
        flow18.SetActive(false);
        flow19.SetActive(false);
        flow20.SetActive(false);

        for (int i = 0; i < flowUIs.Count; i++)
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
    /*void Update()
    {
        FlowerTopUp();
    }*/

    /*public void StopTimer()
    {
        SliderTimerDisplay slidTimerStop = slidTimer.GetComponent<SliderTimerDisplay>();
        float healthRemain = slidTimerStop.healthRemain;
        Debug.Log(healthRemain * 100);
        slidTimerStop.enabled = false;
        timeStopped = true;
    }*/

    //Consider putting this in an separate script
    public void FlowerTopUp()
    {
        if (getFlowerTopUp == false)
        {
            FlowSpawn();
        }


        if (getFlowerTopUp == true)
        {


            if (flowGroup == 0)
            {
                //GameObject redFlow = GameObject.Find("Flower");
                Flower_Anim flowerScript = flow1.GetComponent<Flower_Anim>();
                flow1TopUp = flowerScript.flowerDrained;
                flow1HitMeUp = flowerScript.hitMeUp + hitMeUp;

                Flower_Anim flowerScript2 = flow2.GetComponent<Flower_Anim>();
                flow2TopUp = flowerScript2.flowerDrained;
                flow2HitMeUp = flowerScript2.hitMeUp + hitMeUp;

                Flower_Anim flowerScript3 = flow3.GetComponent<Flower_Anim>();
                flow3TopUp = flowerScript3.flowerDrained;
                flow3HitMeUp = flowerScript3.hitMeUp + hitMeUp;

                if (flow1TopUp == true && flowDone1 == false)
                {
                    flowerTopUp = flow1TopUp;
                    hitMeUpAdd = flow1HitMeUp;
                    flowID = flowerScript.flowID;
                    flowPos = flow1.transform.position;//flow pos for partical effect
                    HitMeUp();
                    flowDone1 = true;
                    getFlowerTopUp = true;
                    flow1.SetActive(false);
                }
                
                else if(flow2TopUp == true && flowDone2 == false)
                {
                    flowerTopUp = flow2TopUp;
                    hitMeUpAdd = flow2HitMeUp;
                    flowID = flowerScript2.flowID;
                    flowPos = flow2.transform.position;
                    HitMeUp();
                    flowDone2 = true;
                    getFlowerTopUp = true;
                    flow2.SetActive(false);
                }

                else if(flow3TopUp == true && flowDone3 == false)
                {
                    flowerTopUp = flow3TopUp;
                    hitMeUpAdd = flow3HitMeUp;
                    flowID = flowerScript3.flowID;
                    flowPos = flow3.transform.position;
                    HitMeUp();
                    flowDone3 = true;
                    getFlowerTopUp = true;
                    flow2.SetActive(false);
                }

                if(flowDone1 == true && flowDone2 == true && flowDone3 == true)
                {
                    getFlowerTopUp = false;
                }

            }


            else if (flowGroup == 1)
            {
                Flower_Anim flowerScript = flow4.GetComponent<Flower_Anim>();
                flow1TopUp = flowerScript.flowerDrained;
                flow1HitMeUp = flowerScript.hitMeUp + hitMeUp;

 
                if (flow1TopUp == true && flowDone1 == false)
                {
                    flowerTopUp = flow1TopUp;
                    hitMeUpAdd = flow1HitMeUp;
                    flowID = flowerScript.flowID;
                    flowPos = flow4.transform.position;//flow pos for partical effect
                    HitMeUp();
                    flowDone1 = true;
                    getFlowerTopUp = true;
                    flow4.SetActive(false);

                }
 
            }

            
            else if (flowGroup == 2)
            {
                Flower_Anim flowerScript = flow4.GetComponent<Flower_Anim>();
                flow1TopUp = flowerScript.flowerDrained;
                flow1HitMeUp = flowerScript.hitMeUp + hitMeUp;

                if (flow1TopUp == true && flowDone1 == false)
                {
                    flowerTopUp = flow1TopUp;
                    hitMeUpAdd = flow1HitMeUp;
                    flowID = flowerScript.flowID;
                    flowPos = flow4.transform.position;//flow pos for partical effect
                    HitMeUp();
                    flowDone1 = true;
                    getFlowerTopUp = false;
                    flow4.SetActive(false);
                }
            }

            else if (flowGroup == 3)
            {
                Flower_Anim flowerScript = flow5.GetComponent<Flower_Anim>();
                flow1TopUp = flowerScript.flowerDrained;
                flow1HitMeUp = flowerScript.hitMeUp + hitMeUp;

                Flower_Anim flowerScript1 = flow6.GetComponent<Flower_Anim>();
                flow2TopUp = flowerScript1.flowerDrained;
                flow2HitMeUp = flowerScript1.hitMeUp + hitMeUp;

                Flower_Anim flowerScript2 = flow7.GetComponent<Flower_Anim>();
                flow3TopUp = flowerScript2.flowerDrained;
                flow3HitMeUp = flowerScript2.hitMeUp + hitMeUp;

                if (flow1TopUp == true && flowDone1 == false)
                {
                    flowerTopUp = flow1TopUp;
                    hitMeUpAdd = flow1HitMeUp;
                    flowID = flowerScript.flowID;
                    flowPos = flow5.transform.position;//flow pos for partical effect
                    HitMeUp();
                    flowDone1 = true;
                    //ensure you keep the process going
                    getFlowerTopUp = true;
                    flow5.SetActive(false);
                }

                if (flow2TopUp == true && flowDone2 == false)
                {
                    flowerTopUp = flow2TopUp;
                    hitMeUpAdd = flow2HitMeUp;
                    flowID = flowerScript1.flowID;
                    flowPos = flow6.transform.position;//flow pos for partical effect
                    HitMeUp();
                    flowDone2 = true;
                    getFlowerTopUp = true;
                    flow6.SetActive(false);

                }

                if (flow3TopUp == true && flowDone3 == false)
                {
                    flowerTopUp = flow3TopUp;
                    hitMeUpAdd = flow3HitMeUp;
                    flowID = flowerScript2.flowID;
                    flowPos = flow7.transform.position;//flow pos for partical effect
                    HitMeUp();
                    flowDone3 = true;
                    getFlowerTopUp = true;
                    flow7.SetActive(false);
                }

                if (flowDone1 == true && flowDone2 == true && flowDone3 == true)
                {
                    getFlowerTopUp = false;
                }
            }

            else if (flowGroup == 4)
            {
                Flower_Anim flowerScript = flow8.GetComponent<Flower_Anim>();
                flow1TopUp = flowerScript.flowerDrained;
                flow1HitMeUp = flowerScript.hitMeUp + hitMeUp;

                Flower_Anim flowerScript2 = flow9.GetComponent<Flower_Anim>();
                flow2TopUp = flowerScript2.flowerDrained;
                flow2HitMeUp = flowerScript2.hitMeUp + hitMeUp;

                if (flow1TopUp == true && flowDone1 == false)
                {
                    flowerTopUp = flow1TopUp;
                    hitMeUpAdd = flow1HitMeUp;
                    flowID = flowerScript.flowID;
                    flowPos = flow8.transform.position;//flow pos for partical effect
                    HitMeUp();
                    flowDone1 = true;
                    getFlowerTopUp = true;
                    flow8.SetActive(false);

                }

                if (flow2TopUp == true && flowDone2 == false)
                {
                    flowerTopUp = flow2TopUp;
                    hitMeUpAdd = flow2HitMeUp;
                    flowID = flowerScript2.flowID;
                    flowPos = flow9.transform.position;//flow pos for partical effect
                    HitMeUp();
                    flowDone2 = true;
                    getFlowerTopUp = true;
                    flow9.SetActive(false);
                }


                if (flowDone1 == true && flowDone2 == true)
                {
                    getFlowerTopUp = false;
                }

            }
            else if (flowGroup == 5)
            {
                Flower_Anim flowerScript = flow10.GetComponent<Flower_Anim>();
                flow1TopUp = flowerScript.flowerDrained;
                flow1HitMeUp = flowerScript.hitMeUp + hitMeUp;

                Flower_Anim flowerScript1 = flow11.GetComponent<Flower_Anim>();
                flow2TopUp = flowerScript1.flowerDrained;
                flow2HitMeUp = flowerScript1.hitMeUp + hitMeUp;

                Flower_Anim flowerScript2 = flow12.GetComponent<Flower_Anim>();
                flow3TopUp = flowerScript2.flowerDrained;
                flow3HitMeUp = flowerScript2.hitMeUp + hitMeUp;

                Flower_Anim flowerScript3 = flow13.GetComponent<Flower_Anim>();
                flow4TopUp = flowerScript3.flowerDrained;
                flow4HitMeUp = flowerScript3.hitMeUp + hitMeUp;

                //TODO: ADD flower checks 
                if (flow1TopUp == true && flowDone1 == false)
                {
                    flowerTopUp = flow1TopUp;
                    hitMeUpAdd = flow1HitMeUp;
                    flowID = flowerScript.flowID;
                    flowPos = flow10.transform.position;//flow pos for partical effect
                    HitMeUp();
                    flowDone1 = true;
                    getFlowerTopUp = true;
                    flow10.SetActive(false);

                }

                if (flow2TopUp == true && flowDone2 == false)
                {
                    flowerTopUp = flow2TopUp;
                    hitMeUpAdd = flow2HitMeUp;
                    flowID = flowerScript1.flowID;
                    flowPos = flow11.transform.position;//flow pos for partical effect
                    HitMeUp();
                    flowDone2 = true;
                    getFlowerTopUp = true;
                    flow11.SetActive(false);
                }

                if (flow3TopUp == true && flowDone3 == false)
                {
                    flowerTopUp = flow3TopUp;
                    hitMeUpAdd = flow3HitMeUp;
                    flowID = flowerScript2.flowID;
                    flowPos = flow12.transform.position;//flow pos for partical effect
                    HitMeUp();
                    flowDone3 = true;
                    getFlowerTopUp = true;
                    flow12.SetActive(false);

                }

                if (flow4TopUp == true && flowDone4 == false)
                {
                    flowerTopUp = flow4TopUp;
                    hitMeUpAdd = flow4HitMeUp;
                    flowID = flowerScript3.flowID;
                    flowPos = flow13.transform.position;//flow pos for partical effect
                    HitMeUp();
                    flowDone4 = true;
                    getFlowerTopUp = true;
                    flow13.SetActive(false);

                }

                if (flowDone1 == true && flowDone2 == true && flowDone3 == true && flowDone4 == true)
                {
                    getFlowerTopUp = false;
                }


            }

            else if (flowGroup == 6)
            {
                Flower_Anim flowerScript = flow14.GetComponent<Flower_Anim>();
                flow1TopUp = flowerScript.flowerDrained;
                flow1HitMeUp = flowerScript.hitMeUp + hitMeUp;

                Flower_Anim flowerScript2 = flow15.GetComponent<Flower_Anim>();
                flow2TopUp = flowerScript2.flowerDrained;
                flow2HitMeUp = flowerScript2.hitMeUp + hitMeUp;

                Flower_Anim flowerScript3 = flow16.GetComponent<Flower_Anim>();
                flow2TopUp = flowerScript3.flowerDrained;
                flow2HitMeUp = flowerScript3.hitMeUp + hitMeUp;

                if (flow1TopUp == true && flowDone1 == false)
                {
                    flowerTopUp = flow1TopUp;
                    hitMeUpAdd = flow1HitMeUp;
                    flowID = flowerScript.flowID;
                    flowPos = flow14.transform.position;//flow pos for partical effect
                    HitMeUp();
                    flowDone1 = true;
                    getFlowerTopUp = true;
                    flow14.SetActive(false);
                }

                if (flow2TopUp == true && flowDone2 == false)
                {
                    flowerTopUp = flow2TopUp;
                    hitMeUpAdd = flow2HitMeUp;
                    flowID = flowerScript2.flowID;
                    flowPos = flow15.transform.position;//flow pos for partical effect
                    HitMeUp();
                    flowDone2 = true;
                    getFlowerTopUp = true;
                    flow15.SetActive(false);

                }

                if (flow3TopUp == true && flowDone2 == false)
                {
                    flowerTopUp = flow3TopUp;
                    hitMeUpAdd = flow3HitMeUp;
                    flowID = flowerScript3.flowID;
                    flowPos = flow16.transform.position;//flow pos for partical effect
                    HitMeUp();
                    flowDone3 = true;
                    getFlowerTopUp = true;
                    flow16.SetActive(false);

                }

                if (flowDone1 == true && flowDone2 == true)
                {
                    getFlowerTopUp = false;
                }

            }

            else if (flowGroup == 7)
            {
                Flower_Anim flowerScript = flow17.GetComponent<Flower_Anim>();
                flow1TopUp = flowerScript.flowerDrained;
                flow1HitMeUp = flowerScript.hitMeUp + hitMeUp;

                Flower_Anim flowerScript2 = flow18.GetComponent<Flower_Anim>();
                flow2TopUp = flowerScript2.flowerDrained;
                flow2HitMeUp = flowerScript2.hitMeUp + hitMeUp;

                Flower_Anim flowerScript3 = flow19.GetComponent<Flower_Anim>();
                flow3TopUp = flowerScript3.flowerDrained;
                flow3HitMeUp = flowerScript3.hitMeUp + hitMeUp;

                if (flow1TopUp == true && flowDone1 == false)
                {
                    flowerTopUp = flow1TopUp;
                    hitMeUpAdd = flow1HitMeUp;
                    flowID = flowerScript.flowID;
                    flowPos = flow17.transform.position;//flow pos for partical effect
                    HitMeUp();
                    flowDone1 = true;
                    getFlowerTopUp = true;
                    flow17.SetActive(false);
                }
                if (flow2TopUp == true && flowDone2 == false)
                {
                    flowerTopUp = flow2TopUp;
                    hitMeUpAdd = flow2HitMeUp;
                    flowID = flowerScript2.flowID;
                    flowPos = flow18.transform.position;//flow pos for partical effect
                    HitMeUp();
                    flowDone2 = true;
                    getFlowerTopUp = true;
                    flow18.SetActive(false);
                }
                if (flow3TopUp == true && flowDone3 == false)
                {
                    flowerTopUp = flow3TopUp;
                    hitMeUpAdd = flow3HitMeUp;
                    flowID = flowerScript3.flowID;
                    flowPos = flow19.transform.position;//flow pos for partical effect
                    HitMeUp();
                    flowDone3 = true;
                    getFlowerTopUp = true;
                    flow19.SetActive(false);
                }

                if (flowDone1 == true && flowDone2 == true && flowDone3 == true)
                {
                    getFlowerTopUp = false;
                }
            }

            else if (flowGroup == 8)
            {
                Flower_Anim flowerScript = flow20.GetComponent<Flower_Anim>();
                flow1TopUp = flowerScript.flowerDrained;
                flow1HitMeUp = flowerScript.hitMeUp + hitMeUp;

                if (flow1TopUp == true)
                {
                    flowerTopUp = flow1TopUp;
                    hitMeUpAdd = flow1HitMeUp;
                    flowID = flowerScript.flowID;
                    flowPos = flow20.transform.position;//flow pos for partical effect
                    lastFlow = true;
                    HitMeUp();
                    //getFlowerTopUp = true;
                    flow20.SetActive(false);

                    if (timeStopped == false)
                    {
                        FlowRuntime flowerRT = GetComponent<FlowRuntime>();
                        flowerRT.StopTimer();
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

            if (lastFlow == true)
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
            specMan.CloudFlowSpesh(flowID, nextFlower);


            for (int i = nextFlower - 1; i < nextFlower; i++)
            {

                flowUIs[i].SetActive(true);


                FlowUICol flowUIScript = flowUIs[i].GetComponent<FlowUICol>();

                flowUIScript.FlowColChange(ref flowID);

            }



        }
    }

    public void FlowSpawn()
    {
        if(nextFlower == 0)
        {
            Flower_Anim flowAnimScript = flow1.GetComponent<Flower_Anim>();
            flowAnimDone = flowAnimScript.animDone;

            flow1.SetActive(true);

            if(flowAnimDone == true)
            {                
                flow2.SetActive(true);
                
            }

            Flower_Anim flowAmimScript2 = flow2.GetComponent<Flower_Anim>();
            flowAnimDone2 = flowAmimScript2.animDone;

            if(flowAnimDone2 == true)
            {
                flow3.SetActive(true);
                getFlowerTopUp = true;
                flowDone1 = false;
                flowDone2 = false;
                flowDone3 = false;
                flow1HitMeUp = 0;
                flow2HitMeUp = 0;
                flow3HitMeUp = 0;
                flowGroup += 1;

            }

        }

        if (nextFlower == 3)
        {

            flow4.SetActive(true);
            getFlowerTopUp = true;
            flowGroup += 1;
                       

        }

        
        if (nextFlower == 4)
        {
            flow5.SetActive(true);
            Flower_Anim flowAnimScript = flow5.GetComponent<Flower_Anim>();
            flowAnimDone = flowAnimScript.animDone;

            if(flowAnimDone == true)
            {
                flow6.SetActive(true);
            }
            //Clear down previous flower groups variables
            Flower_Anim flowAnimScript2 = flow6.GetComponent<Flower_Anim>();
            flowAnimDone2 = flowAnimScript2.animDone;

            if(flowAnimDone2 == true)
            {
                flow7.SetActive(true);
                flowDone1 = false;
                flow1HitMeUp = 0;
                getFlowerTopUp = true;
                flowGroup += 1;
            }
            
            

        }
 
        if (nextFlower == 7)
        {
            flow8.SetActive(true);
            Flower_Anim flowAnimScript = flow8.GetComponent<Flower_Anim>();
            flowAnimDone = flowAnimScript.animDone;
       

            if (flowAnimDone == true)
            {
                flow9.SetActive(true);
                flowDone1 = false;
                flowDone2 = false;
                flowDone3 = false;
                flow1HitMeUp = 0;
                flow2HitMeUp = 0;
                flow3HitMeUp = 0;
                getFlowerTopUp = true;
                flowGroup += 1;
            }


        }
        if (nextFlower == 9)
        {
            flow10.SetActive(true);
            Flower_Anim flowAnimScript = flow10.GetComponent<Flower_Anim>();
            flowAnimDone = flowAnimScript.animDone;

            if (flowAnimDone == true)
            {
                flow11.SetActive(true);
            }

            Flower_Anim flowAnimScript2 = flow11.GetComponent<Flower_Anim>();
            flowAnimDone2 = flowAnimScript2.animDone;

            if (flowAnimDone2 == true)
            {
                flow12.SetActive(true);
          
            }

            Flower_Anim flowAnimScript3 = flow12.GetComponent<Flower_Anim>();
            flowAnimDone3 = flowAnimScript3.animDone;

            if(flowAnimDone3 == true)
            {
                flow13.SetActive(true);
                getFlowerTopUp = true;
                //Clear down previous flower groups variables
                flowDone1 = false;
                flowDone2 = false;
                flow1HitMeUp = 0;
                flow2HitMeUp = 0;
                flowGroup += 1;

            }

       
        }
        if (nextFlower == 13)
        {

            flow14.SetActive(true);
            Flower_Anim flowAnimScript = flow14.GetComponent<Flower_Anim>();
            flowAnimDone = flowAnimScript.animDone;

            if (flowAnimDone == true)
            {
                flow15.SetActive(true);
            }

            Flower_Anim flowAnimScript2 = flow15.GetComponent<Flower_Anim>();
            flowAnimDone2 = flowAnimScript2.animDone;

            if (flowAnimDone2 == true)
            {
                getFlowerTopUp = true;
                flow16.SetActive(true);
                flowDone1 = false;
                flowDone2 = false;
                flowDone3 = false;
                flowDone4 = false;
                flow1HitMeUp = 0;
                flow2HitMeUp = 0;
                flow3HitMeUp = 0;
                flow4HitMeUp = 0;
                flowGroup += 1;
            }


        }

        if (nextFlower == 16)
        {
            flow17.SetActive(true);
                    getFlowerTopUp = true;
                    flowDone1 = false;
                    flowDone2 = false;
                    flowDone3 = false;
                    flowDone4 = false;
                    flow1HitMeUp = 0;
                    flow2HitMeUp = 0;
                    flow3HitMeUp = 0;
                    flow4HitMeUp = 0;
                    flowGroup += 1;

            

        }

        if (nextFlower == 16)
        {
            flow17.SetActive(true);
            Flower_Anim flowAnimScript = flow17.GetComponent<Flower_Anim>();
            flowAnimDone = flowAnimScript.animDone;

            if (flowAnimDone == true)
            {
                flow18.SetActive(true);

            }

            Flower_Anim flowAnimScript2 = flow18.GetComponent<Flower_Anim>();
            flowAnimDone2 = flowAnimScript2.animDone;

            if (flowAnimDone2 == true)
            {
                flow19.SetActive(true);
                getFlowerTopUp = true;
                flowDone1 = false;
                flowDone2 = false;
                flow1HitMeUp = 0;
                flow2HitMeUp = 0;
                flowGroup += 1;
            }


        }
        if (nextFlower == 19)
        {
            flow20.SetActive(true);
            getFlowerTopUp = true;
            flowDone1 = false;
            flowDone2 = false;
            flowDone3 = false;
            flow1HitMeUp = 0;
            flow2HitMeUp = 0;
            flow3HitMeUp = 0;
            flowGroup += 1;

        }


    }


}