﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFly_LHealth : MonoBehaviour {


    SpriteRenderer m_SpriteRenderer;
    Color32 lowHealthColor;
    Color normColor;
    Color lerpColor;

    public bool lowHealth;
    private bool damage;


    // Use this for initialization
    void Start ()

    {
        lowHealthColor = new Color32(250,0,0,255);
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        normColor = m_SpriteRenderer.color;
        

    }

    // Update is called once per frame
    void Update ()
    {
        BFly_Collision BFly = GetComponent<BFly_Collision>();
        lowHealth = BFly.lowHealth;

        if (lowHealth == true)
        {
            lerpColor = Color.Lerp(normColor, lowHealthColor, Mathf.PingPong(Time.time, 1));
            m_SpriteRenderer.color = lerpColor;
        }

        else
        {
            m_SpriteRenderer.color = normColor;
        }

        damage = BFly.doDamageCol;

        float damageTime = BFly.damageTime;


        if (Time.fixedTime <= damageTime + 0.65f)
        {
            if (damage == true)
            {
                lerpColor = Color.Lerp(normColor, lowHealthColor, Mathf.PingPong(Time.time, 2));
                m_SpriteRenderer.color = lerpColor;
            }

            else
            {
                m_SpriteRenderer.color = normColor;
            }
        }
               
      
    }
}
