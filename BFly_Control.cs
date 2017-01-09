using UnityEngine;
using System.Collections;

public class BFly_Control : MonoBehaviour {

    private Rigidbody2D rb2d;
    private BoxCollider2D bxCol;

    public float speed;

  
    void Start()
    {


        rb2d = GetComponent<Rigidbody2D>();
        bxCol = GetComponent<BoxCollider2D>();

      


    }
	

	void FixedUpdate ()
	{
       


        float MoveButtY = Input.GetAxisRaw ("Horizontal");
		float MoveButtX = Input.GetAxisRaw ("Vertical");

		Vector2 movement = new Vector2 (MoveButtY, MoveButtX);

        rb2d.AddForce(movement * speed);

        //8 directional movement
        if (MoveButtY > 0 && MoveButtX > 0)
        {
            rb2d.MoveRotation(-45);
        }

        else if (MoveButtY < 0 && MoveButtX > 0)
        {
            rb2d.MoveRotation(45);
        }

        else if (MoveButtY > 0 && MoveButtX < 0)
        {
            rb2d.MoveRotation(-135);
        }

        else if (MoveButtY < 0 && MoveButtX < 0)
        {
            rb2d.MoveRotation(135);
        }
        else if (MoveButtY > 0)
        {
            rb2d.MoveRotation(-90);
        }
        else if (MoveButtY < 0){ 
            
            rb2d.MoveRotation(90);
               }
        else if (MoveButtX > 0)
        {
            rb2d.MoveRotation(0);
        }
        else if (MoveButtX < 0)
        {
            rb2d.MoveRotation(180);
        }


}



}
