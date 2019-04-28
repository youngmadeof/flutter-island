using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour {

    private Vector2 velocity;
    public GameObject player;
    public GameObject backGround;
    int playerState;
    private Vector3 startCamPos;
    private Vector3 bgPos;
    float zoomInSpeed;
    float zoomOutSpeed;
    float journeyLength;
    private float timer;

    private bool zoomGo;

    public bool bounds;

    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;


    private Vector3 offset;
    // Use this for initialization
    void Start ()
    {
        //offset = transform.position - player.transform.position;
        startCamPos = new Vector3(transform.position.x,transform.position.y, -4.0f);
        bgPos = new Vector3(backGround.transform.position.x, backGround.transform.position.y, -4.0f);

        zoomInSpeed = 10.0f;
        zoomOutSpeed = 10.0f;
        timer = 0f;

    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
      

        BFly_Control bFlyScript = player.GetComponent<BFly_Control>();

        playerState = bFlyScript.movState;


        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, 0.05f);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, 0.05f);

        //transform.position = new Vector3(posX, posY, -4.0f);

 

       if (playerState == 1)
        {
            //ResetTime();
            timer += Time.deltaTime;
                                                                              
            Debug.Log(timer);
            zoomGo = false;

            if (Camera.main.orthographicSize > 3.0f)
            {
                Camera.main.orthographicSize -= 0.1f / zoomInSpeed;

                minCameraPos.x -= 0.01f;
                minCameraPos.y -= 0.01f;
                maxCameraPos.x -= 0.01f;
                maxCameraPos.y -= 0.01f;


                if (bounds)
                    {
                        transform.position = new Vector3(Mathf.Clamp(posX, minCameraPos.x, maxCameraPos.x),
                            Mathf.Clamp(posY, minCameraPos.y, maxCameraPos.y), -4.0f);

                    }


            }
            //float distCovered = (Time.time - startTime) * 1.0f;
            //Vector3 playerPos = new Vector3(player.transform.position.x,player.transform.position.y,-4.0f);
            // offset = playerPos - bgPos;
            //Debug.Log(offset + " offset ");
            //Vector3 newCamPos = transform.position;
            //Vector3 newPlayerPos = playerPos - offset;
            // Vector3 newOffset = newCamPos - newPlayerPos;
            // Debug.Log(newOffset + " new offset ");
            //journeyLength = Vector3.Distance(newCamPos, playerPos) * Time.smoothDeltaTime;
            //transform.position = Vector3.Lerp(newCamPos, playerPos, journeyLength);  


        }
        else if (playerState == 0)
        {


            // Vector3 newCamPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            //Debug.Log(newCamPos + " new cam pos");
            //Debug.Log(startCamPos + " start cam pos");
            //journeyLength = Vector3.Distance(newCamPos, startCamPos) * Time.smoothDeltaTime;
            //transform.position = Vector3.Lerp(newCamPos, startCamPos, journeyLength);
            transform.position = new Vector3(Mathf.Clamp(posX, minCameraPos.x, maxCameraPos.x),
                            Mathf.Clamp(posY, minCameraPos.y, maxCameraPos.y), -4.0f);
            WaitBeforeZoom();

            if (Camera.main.orthographicSize < 5.0f)
            {
                Camera.main.orthographicSize += 0.1f / zoomOutSpeed;
                minCameraPos.x += 0.01f;
                minCameraPos.y += 0.01f;
                maxCameraPos.x += 0.01f;
                maxCameraPos.y += 0.01f;

            }






        }
 

    
        
    }

    IEnumerator WaitBeforeZoom()
    {
        yield return new WaitForSeconds(1);
        zoomGo = true;
    }
    /*private void ResetTime()
    {

        timer = 0f;
    }*/
}
