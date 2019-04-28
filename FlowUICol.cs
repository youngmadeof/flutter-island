using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowUICol : MonoBehaviour
{

    private Graphic graphic;

    public void FlowColChange(ref int flowID)
    {
        
        //SpriteRenderer m_SpriteRenderer;
        Color32 redUICol;
        Color32 yellUICol;
        Color32 bluUICol;

        graphic = GetComponent<Graphic>();
        
        //m_SpriteRenderer = GetComponent<SpriteRenderer>();

        if(flowID == 0)
        {
            redUICol = new Color32(237, 2, 2, 255);

            graphic.color = redUICol;
        }

        if(flowID == 1)
        {
            yellUICol = new Color32(252, 252, 37, 255);

            graphic.color = yellUICol;
        }

        if(flowID == 2)
        {
            bluUICol = new Color32(37, 37, 252, 255);

            graphic.color = bluUICol;
        }


    }

	
}
