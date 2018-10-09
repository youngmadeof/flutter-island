using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FlowMgmt : MonoBehaviour
{

    public bool flowerTopUp;
    public int hitMeUp;
    private bool getFlowerTopUp;
    public int nextFlower;

    private Text textUI;

    public int flowGroup;
    private int hitMeUpAdd;

    private bool yellFlowerTopUp;
    private bool redFlowerTopUp;
    private bool redFlowerTopUp2;
    private bool redFlowerTopUp3;

    private int yellHitMeUpAdd;
    private int redHitMeUpAdd;
    private int redHitMeUpAdd2;
    private int redHitMeUpAdd3;


    private bool yellFlowDone;
    private bool redFlowDone;
    private bool yellFlow2Done;
    private bool redFlow3Done;
    private bool redFlow4Done;

    private bool waitForFlow;

    public GameObject redFlow;
    public GameObject yellFlow;
    public GameObject redFlow2;
    public GameObject yellFlow2;
    public GameObject redFlow3;
    public GameObject redFlow4;
    public GameObject yellFlow3;

    private void Awake()
    {
        yellFlow.SetActive(false);
        redFlow2.SetActive(false);
        yellFlow2.SetActive(false);
        redFlow3.SetActive(false);
        redFlow4.SetActive(false);
        yellFlow3.SetActive(false);


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


        if (getFlowerTopUp == true)
        {
            if (flowGroup == 0)
            {
                GameObject redFlow = GameObject.Find("Flower");
                Flower_Anim flowerScript = redFlow.GetComponent<Flower_Anim>();
                flowerTopUp = flowerScript.flowerDrained;
                hitMeUpAdd = flowerScript.hitMeUp + hitMeUp;

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


                }
                else if (redFlowerTopUp == true && redFlowDone == false)
                {
                    flowerTopUp = redFlowerTopUp;
                    hitMeUpAdd = redHitMeUpAdd;
                    HitMeUp();
                    redFlowDone = true;
                    getFlowerTopUp = true;
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
                }

                if (redFlowerTopUp2 == true && redFlow4Done == false)
                {
                    flowerTopUp = redFlowerTopUp2;
                    hitMeUpAdd = redHitMeUpAdd2;
                    HitMeUp();
                    redFlow4Done = true;
                    getFlowerTopUp = true;

                }

                if (yellFlowerTopUp == true && yellFlowDone == false)
                {
                    flowerTopUp = yellFlowerTopUp;
                    hitMeUpAdd = yellHitMeUpAdd;
                    HitMeUp();
                    yellFlowDone = true;
                    getFlowerTopUp = true;
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


            if (nextFlower == 1)
            {

                redFlow2.SetActive(true);
                yellFlow.SetActive(true);
                getFlowerTopUp = true;
                flowGroup += 1;
                
            }

            if (nextFlower == 3)
            {
                yellFlow2.SetActive(true);
                yellFlowDone = false;
                getFlowerTopUp = true;
                yellHitMeUpAdd = 0;
                flowGroup += 1;

            }

            if (nextFlower == 4)
            {
                redFlow3.SetActive(true);
                redFlow4.SetActive(true);
                yellFlow3.SetActive(true);
                getFlowerTopUp = true;
                yellFlowDone = false;
                yellHitMeUpAdd = 0;
                redHitMeUpAdd = 0;
                redHitMeUpAdd2 = 0;
                flowGroup += 1;
            }



        }
    }


}