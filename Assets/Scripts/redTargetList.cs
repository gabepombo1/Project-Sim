using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redTargetList : MonoBehaviour
{
    //will it not consider it self as a target if it is attached to a hostile game object?
    public bool Target(string gameObjectTag)
    {
            switch (gameObjectTag)
            {

                case "Red":
                    return true;
                case "Blue":
                    return false;
                default:
                    return true;
                
            }
            
    }
}
