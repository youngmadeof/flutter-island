using UnityEngine;
using System.Collections;

public class Flower_Anim : MonoBehaviour
{
    private GameObject flower;
    private GameObject butt;
    private Rigidbody2D rb2d;
    public float rot;
    private bool hit;
    
    
    public void Start()
    {
        //flower = GameObject.Find("Flower");
        butt = GameObject.Find("BFly_Player");
        rb2d = GetComponent<Rigidbody2D>();
        


    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject == butt)
        {
                                 
            hit = true;
            Debug.Log(hit);
        }
    }

    void OnTriggerExit2D(Collider2D Other)
    {
        if (Other.gameObject == butt)
        {
            hit = false;
            Debug.Log(hit);
        }
    }

    public void FixedUpdate()
    {
        if (hit == true)
        {
            rb2d.MoveRotation(rb2d.rotation + rot * Time.fixedDeltaTime);
        }
    }


}
