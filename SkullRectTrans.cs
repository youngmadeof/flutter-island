using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullRectTrans : MonoBehaviour {

    //Used for death screen
    Vector3 skullSize;
	// Use this for initialization
	public void GetSkullSize ()
    {
        skullSize = DeathScreenBehave.currSize;
        gameObject.GetComponent<RectTransform>().localScale = new Vector3 (skullSize.x,skullSize.y);
    }
	
}
