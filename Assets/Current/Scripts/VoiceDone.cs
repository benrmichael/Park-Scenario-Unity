using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceDone : MonoBehaviour
{
    public bool isOn = false;

    public void TurnOnOff()
    {
        if(isOn == false)
        {
            gameObject.SetActive(true);
            isOn = true;
        }
        else if(isOn == true)
        {
            gameObject.SetActive(false);
            isOn = false;
        }
    }


}
