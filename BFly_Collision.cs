using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFly_Collision : MonoBehaviour {


    public GameObject cloud;
    public GameObject enemyObj;
    public GameObject subEnemyObj;

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

    //whack in some states
    public int curState;

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
        if (collision.gameObject == enemyObj)
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

   

    // Update is called once per frame
    void FixedUpdate ()

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
            FishControl fishScript = subEnemyObj.GetComponent<FishControl>();
            doColl = fishScript.collEnabled;
            
            if(doColl == true)
            {
                doDamageCol = true;
                damageTime = Time.fixedTime;
                Debug.Log("Fish Hit!");
                subCollision = false;
            }
        }
        
        
    }

    void DestroyObject()
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
