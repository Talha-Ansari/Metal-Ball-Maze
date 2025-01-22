using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControlar : MonoBehaviour
{
    [SerializeField] LimitedObjectRotator[] limitedObjectRotator;


    public void SwitchToGyro()
    {
        foreach (LimitedObjectRotator item in limitedObjectRotator)
        {
            item.useGyro = true;
        }
    }

    public void SwitchToJoystick()
    {

        foreach (LimitedObjectRotator item in limitedObjectRotator)
        {
            item.useGyro = false;
        }

    }
}
