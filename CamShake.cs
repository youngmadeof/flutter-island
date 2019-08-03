using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour {

    private Transform transform;
    public float shakeDuration = 0f;
    private float shakeMag = 0.03f;
    private float dampSpeed = 1.0f;
    Vector3 initialPos;
    // Use this for initialization

    private void Awake()
    {
        if(transform == null)
        {
            transform = GetComponent(typeof(Transform)) as Transform;
        }
        
    }

    private void OnEnable()
    {
        initialPos = transform.localPosition;
    }

	
	// Update is called once per frame
	void Update ()
    {
		if(shakeDuration > 0)
        {
            transform.localPosition = initialPos + Random.insideUnitSphere * shakeMag;

            shakeDuration -= Time.deltaTime * dampSpeed;
        }

        else
        {
            shakeDuration = 0f;
            transform.position = initialPos;
        }
	}

    public void TriggerShake()
    {
        shakeDuration = 0.3f;
    }
}
