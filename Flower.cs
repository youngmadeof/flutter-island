using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{

    // Use this for initialization
    public string colour;


    public Flower()
    {
        colour = "red";
    }

    public Flower(string otherColour)
    {
        colour = otherColour;
    }

    public void GetColour()
    {
        {
            //Debug.Log(colour);
        }
    }

}
