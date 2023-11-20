using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeButton : MonoBehaviour
{
    ExitGame exi;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            exi.EnableConfirmation();
        }
    }
}
