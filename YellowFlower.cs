using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowFlower : Flower
{
    public YellowFlower()
    {
        colour = "yellow";
    }

    public YellowFlower(string otherColour) : base(otherColour)
    {

    }


}
