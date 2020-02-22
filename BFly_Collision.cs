using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFly_Collision : MonoBehaviour {


    public GameObject cloud;
    public GameObject enemyObj;
    public GameObject enemyObj2;
    public GameObject enemyObj3;
    public GameObject subEnemyObj;
    public GameObject cactObj1;
    public GameObject cactObj2;
    public GameObject cactObj3;

    public GameObject buttExp;

    public GameObject slidTime;

    public bool lowHealth;

    private float healthRemain;
    private bool healthSet;

    private bool coneCollision;
    private bool cloudCollision;

    private bool subCollision;
    private bool doColl;
    public bool doDamageCol;
    public float damageTime;
    public int damageVal;

    //whack in some states
    public int curState;
    private int count;

    private enum State
    {
        normal,
        dead
    }

    private void Awake()
    {

    }
    // Use this for initialization
    void Start ()

    {
        curState = (int)State.normal;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == enemyObj || collision.gameObject == enemyObj2)
        {
            if (cloudCollision == false)
            {
                coneCollision = true;
            }

        }

        if(collision.gameObject == subEnemyObj)
        {
            subCollision = true;
        }

        if (collision.gameObject == cloud)
        {
            cloudCollision = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == cloud)
        {
            cloudCollision = false;
        }

        //subEnemy collision
        if (collision.gameObject == subEnemyObj)
        {
            subCollision = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == cactObj1 || collision.gameObject == cactObj2 || collision.gameObject == cactObj3)
        {
            if(Flower_Anim.blInteract == false)
            {
                coneCollision = true;
            }
            
        }
    }

    // Update is called once per frame
    void Update ()

    {

        if (coneCollision == true && cloudCollision == false)
        {
            curState = (int)State.dead;
        }

        
        else if (Input.GetButton("Fire1"))
        {
            if (coneCollision == false || cloudCollision == true)
            {
                curState = (int)State.normal;               
               
            }

        }

        else
        {
            curState = (int)State.normal;

        }

        
        SliderTimerDisplay slidTimeScript = slidTime.GetComponent<SliderTimerDisplay>();
        healthRemain = slidTimeScript.healthRemain;
        healthSet = slidTimeScript.healthSet;

        if(healthSet == true)
        {
            if (healthRemain >= 0 && healthRemain <= 0.15f)
            {
                lowHealth = true;

                if (healthRemain == 0)
                {
                    curState = (int)State.dead;
                }

            }

            else
            {
                lowHealth = false;
            }
        }


        if (curState == (int)State.dead)
        {
            //gameObject.SetActive(false);
            Vector3 buttPos = transform.position;   
            ButtExplosion getButtBang = buttExp.GetComponent<ButtExplosion>();
            getButtBang.buttGoBang(buttPos);
            DestroyObject();
        }

        //This stuff for subEnemy collision

        if(subCollision == true)
        {
            //TODO: Put in Scorp Script here
            FishControl fishScript = subEnemyObj.GetComponent<FishControl>();
            ScorpDmgCol scorpScript = subEnemyObj.GetComponent<ScorpDmgCol>();

            if(subEnemyObj == GameObject.Find("AttackCol"))
            {
                doColl = scorpScript.collEnabled;
                damageVal = scorpScript.damageVal;
            }

            else
            {
                doColl = fishScript.collEnabled;
                damageVal = fishScript.damageVal;
            }
            

            
            

            CountdownTimer timer = slidTime.GetComponent<CountdownTimer>();

            if (doColl == true)
            {
                doDamageCol = true;
                Debug.Log(doDamageCol + " dodamage BFLY COLL");
                damageTime = Time.fixedTime;
                //Debug.Log("Fish Hit!");
                subCollision = false;
                timer.count = 0;
               
            }

 


        }

        else
        {
            doDamageCol = false;
            //Debug.Log(doDamageCol + " dodamage BFLY COLL");
        }


    }

    void DestroyObject()
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
