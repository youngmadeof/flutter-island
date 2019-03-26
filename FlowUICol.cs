using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowUICol : MonoBehaviour
{
    public void FlowColChange(ref int flowID)
    {
        SpriteRenderer m_SpriteRenderer;
        Color32 redUICol;
        Color32 yellUICol;
        Color32 bluUICol;
        
        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        if(flowID == 0)
        {
            redUICol = new Color32(237, 2, 2, 255);

            m_SpriteRenderer.color = redUICol;
        }

        if(flowID == 1)
        {
            yellUICol = new Color32(252, 252, 37, 255);

            m_SpriteRenderer.color = yellUICol;
        }

        if(flowID == 2)
        {
            bluUICol = new Color32(37, 37, 252, 255);

            m_SpriteRenderer.color = bluUICol;
        }


    }

	
}
