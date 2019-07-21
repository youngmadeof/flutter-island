using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplode : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        
    }
	
	
    public void EnemyGoBang(Vector3 emePos)
    {
        gameObject.SetActive(true);
        ParticleSystem ps = GetComponent<ParticleSystem>();
        var psMain = ps.main;
        Gradient g;
        GradientColorKey[] gck;
        GradientAlphaKey[] gak;
        g = new Gradient();
        gck = new GradientColorKey[2];
        gck[0].color = Color.black;
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
        transform.position = emePos;
        ps.Play();
    }
	
}
