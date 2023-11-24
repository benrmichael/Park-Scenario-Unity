using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization;

public class Manager : MonoBehaviour
{
    //the manager takes in all the props and player commands and plays out the scenario

    //the NPCs we have in the scane, stored here
    [SerializeField] public GameObject NPC1;
    public NPCAction NPC1Actions;
    [SerializeField] public GameObject NPC2;
    public NPCAction NPC2Actions;
    [SerializeField] public GameObject NPC3;
    public NPCAction NPC3Actions;

    //the player
    [SerializeField] public GameObject playerObject;

    //the benches, to reference later for the NPCs to move towards
    [SerializeField] public GameObject bench1;
    [SerializeField] public GameObject bench2;
    [SerializeField] public GameObject bench3;

    [SerializeField] public GameObject startCanvas;
    [SerializeField] public GameObject endCanvas;

    [SerializeField] public GameObject scoreVoice;


    //stages of the scenario used to decide when to do what actions in the scenario
    public bool Part1 = false;  //instructions
    public bool Part2 = false;  //first NPC
    public bool Part3 = false;  //second NPC
    public bool Part4 = false;  //third NPC
    public bool Part5 = false;  //end screen


    //waiting fo conditions involving the controller. May not be needed with the change in menus
    private IEnumerator coroutine;
    public bool triggerPressed = false;

    public int numberCorrect;
    [SerializeField] private TextMeshPro scoreResults;
    // The text to be displayed with the score
    private const string ENGLISH_1 = "You got: ";
    private const string ENGLISH_2 = " correct! Good job!";
    private const string SPANISH_1 = "Tienes: ";
    private const string SPANISH_2 = " correcto! ¡Buen trabajo!";
    private void Awake()
    {
        endCanvas.transform.localScale = new Vector3(0,0,0);
    }

    //save the NPC info when the scenario starts
    private void Start()
    {
        NPC1Actions = NPC1.GetComponent<NPCAction>();
        //NPC1Actions.active = false;
        NPC2Actions = NPC2.GetComponent<NPCAction>();
        //NPC2Actions.active = false;
        NPC3Actions = NPC3.GetComponent<NPCAction>();
        //NPC3Actions.active = false;

        //begin part 1
        Part1 = true;
        
    }

    //this occurs each frame. It involves button input, checking the stages of the scenario, and moving the scenario along
    private void Update()
    {
        //this section gets our controller information and stores it so we can easily reference it later
        //mostly taken from Sky's attempts, as newer versions have refused to work properly...
        var inputDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(UnityEngine.XR.InputDeviceCharacteristics.Controller, inputDevices);

        if (!(inputDevices.Count > 0)) 
        {
            //Debug.Log("WARNING: No input devices found!");
            return;
        }

        var device = inputDevices[0];

        //checks if the trigger was pressed. May need to be removed as it was intended to be used with the canvas/UI setup
        bool triggerValue = false;

        //this will be moved to tutorial manager... a lot of that
        if(Part1)
        {
                if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
                {

                    //checks the part 1 flag and starts the scenario
                    BeginScenario();
                }
        }   
        else if(Part2)
        {
            if(NPC1Actions.seated)
            {
                NPC2Script();
            }
            else
            {
                if(NPC1Actions.checkpointReached == false)
                {
                    MoveToCheckpoint(NPC1Actions);
                }
                else if(NPC1Actions.checkpointReached)
                {
                    //if it reached the checkpoint, stop moving and animating the walk, find the player and look at them. This will trigger the wave animation as well within the NPC class
                    NPC1Actions.walking = false;
                    NPC1Actions.FindTarget(playerObject);

                    if(NPC1Actions.receivedItem)
                    {
                        MoveToBench(NPC1Actions);

                        if(NPC1Actions.seated)
                        {
                            SitDown(NPC1Actions);
                            //WaitBetweenNPC(30);
                        }
                    }
                }
            }
                    
        }
        else if(Part3)
        {
            if(NPC2Actions.seated)
            {
                NPC3Script();
            }
            else
            {
                if(NPC2Actions.checkpointReached == false)
                {
                    MoveToCheckpoint(NPC2Actions);
                }
                else if(NPC2Actions.checkpointReached)
                {
                    //if it reached the checkpoint, stop moving and animating the walk, find the player and look at them. This will trigger the wave animation as well within the NPC class
                    NPC2Actions.walking = false;
                    NPC2Actions.FindTarget(playerObject);

                    if(NPC2Actions.receivedItem)
                    {
                        MoveToBench(NPC2Actions);

                        if(NPC2Actions.seated)
                        {
                            SitDown(NPC2Actions);
                            //WaitBetweenNPC(30);
                        }
                    }
                }
            }
        }
        else if(Part4)
        {
            if(NPC3Actions.seated)
            {
                EndScenario();
            }
            else
            {
                if(NPC3Actions.checkpointReached == false)
                {
                    MoveToCheckpoint(NPC3Actions);
                }
                else if(NPC3Actions.checkpointReached)
                {
                    //if it reached the checkpoint, stop moving and animating the walk, find the player and look at them. This will trigger the wave animation as well within the NPC class
                    NPC3Actions.walking = false;
                    NPC3Actions.FindTarget(playerObject);

                    if(NPC3Actions.receivedItem)
                    {
                        MoveToBench(NPC3Actions);

                        if(NPC3Actions.seated)
                        {
                            SitDown(NPC3Actions);
                            //WaitBetweenNPC(30);
                        }
                    }
                }
            }
        }
    }

    public void BeginScenario()
    {
        startCanvas.transform.localScale = new Vector3(0,0,0);
        NPC1Script();
    }

    public void NPC1Script()
    {
        Part1 = false;
        Part2 = true;

        //NPC1Actions.active = true;
        NPC1Actions.walking = true;      
    }

    public void NPC2Script()
    {
        Part3 = true;
        Part2 = false;

        //NPC2Actions.active = true;
        NPC2Actions.walking = true;
    }

    public void NPC3Script()
    {
        Part3 = false;
        Part4 = true;

        //NPC3Actions.active = true;
        NPC3Actions.walking = true;

    }
    IEnumerator WaitBetweenNPC(int wait)
    {
        yield return new WaitForSeconds(wait);
    }
    
    public void EndScenario()
    {
        Part4 = false;
        Part5 = true;
        Locale currentLanguage;

        // This is the lazy way of not rewriting this since it is so embedded
        if (LocalizationSettings.Instance == null || (currentLanguage = LocalizationSettings.SelectedLocale) == null)
        {
            scoreResults.text = ENGLISH_1 + numberCorrect + ENGLISH_2;
            DisplayCanvas();
            return;
        }


        if (currentLanguage.LocaleName.Contains("Spanish"))
        {
            scoreResults.text = SPANISH_1 + numberCorrect + SPANISH_2;
        }
        else 
        {
            scoreResults.text = ENGLISH_1 + numberCorrect + ENGLISH_2;
        }

        DisplayCanvas();
    }

    private void DisplayCanvas()
    {
        endCanvas.transform.localScale = new Vector3(0.008f, 0.008f, 0.008f);
        scoreVoice.GetComponent<AudioTrigger>().PlayTheSoundClip();
    }


    public void MoveToBench(NPCAction currentNPC)
    {
        currentNPC.FindTarget(currentNPC.myBench);
        WaitBetweenNPC(5);
        currentNPC.walking = true;
        
        Vector3 velocity = Vector3.zero;

        if(currentNPC.isGrounded == true)
        {
            currentNPC.transform.position = Vector3.MoveTowards(currentNPC.transform.position, currentNPC.myBench.transform.position, 0.03f);
            //currentNPC.transform.position = Vector3.SmoothDamp(currentNPC.transform.position, currentNPC.myBench.transform.position, ref velocity, 0.6f);
        }
    }

    public void MoveToCheckpoint(NPCAction currentNPC)
    {
        currentNPC.FindTarget(currentNPC.myCheckpoint);
        WaitBetweenNPC(5);
        currentNPC.walking = true;
        
        Vector3 velocity = Vector3.zero;
        if(currentNPC.isGrounded == true)
        {
            currentNPC.transform.position = Vector3.MoveTowards(currentNPC.transform.position, currentNPC.myCheckpoint.transform.position, 0.035f);
            //currentNPC.transform.position = Vector3.SmoothDamp(currentNPC.transform.position, currentNPC.myCheckpoint.transform.position, ref velocity, 0.6f);
        }
        
    }

    public void SitDown(NPCAction currentNPC)
    {
        currentNPC.FindTarget(currentNPC.thePlayer);
        currentNPC.walking = false;
        currentNPC.myAnimator.Play("Sit");
    }


}
