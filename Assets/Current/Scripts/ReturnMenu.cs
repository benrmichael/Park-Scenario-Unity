using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ReturnMenu : MonoBehaviour
{
    public GameObject confirmation_panel;

    public void Start()
    {
        confirmation_panel.SetActive(false);
    }   

    public void button_exit()
    {
        Application.Quit();
        //EditorApplication.isPlaying = false;
    }

    public void EnableConfirmation()
    {
        confirmation_panel.SetActive(true);
    }
    public void DisableConfirmation()
    {
        confirmation_panel.SetActive(false);
    }
}
