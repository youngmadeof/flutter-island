﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastFlowExplode : MonoBehaviour {

    public GameObject bird;
    public GameObject enemyExplode;
	

	// Update is called once per frame
    public void LastFlowBang(Vector3 flowPos)
    {
        gameObject.SetActive(true);
        transform.position = flowPos;
    }

    private void Update()
    {
        Vector3 getScale = transform.localScale;

        if(getScale.x < 8.0f)
        {
            transform.localScale += new Vector3(0.05f, 0.05f, 0);
        }
        
        if(getScale.x >= 8.0f)
        {
            gameObject.SetActive(false);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == bird)
        {
            Vector3 birdPos = bird.transform.position;
            Destroy(bird);
            EnemyExplode getEnemyBang = enemyExplode.GetComponent<EnemyExplode>();
            getEnemyBang.EnemyGoBang(birdPos);
        }

    }

}
