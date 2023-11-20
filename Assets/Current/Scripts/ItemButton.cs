using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : MonoBehaviour
{
    [SerializeField] public GameObject itemButton;
    [SerializeField] public GameObject item;
    [SerializeField] public GameObject manager;
    

    public void PressButton(int x)
    {
        if(x == 1)
        {
            if(manager.GetComponent<Manager>().Part4 == true)
            {
                if(manager.GetComponent<Manager>().NPC3Actions.checkpointReached == true)
                {
                    manager.GetComponent<Manager>().NPC3Actions.receivedItem = true;
                    manager.GetComponent<Manager>().NPC3Actions.correctItem = false;
                    manager.GetComponent<Manager>().MoveToBench(manager.GetComponent<Manager>().NPC3Actions);
                    manager.GetComponent<Manager>().Part5 = true;
                }
            }
            else if(manager.GetComponent<Manager>().Part3 == true)
            {
                if(manager.GetComponent<Manager>().NPC2Actions.checkpointReached == true)
                {
                    manager.GetComponent<Manager>().NPC2Actions.receivedItem = true;
                    manager.GetComponent<Manager>().NPC2Actions.correctItem = false;
                    manager.GetComponent<Manager>().MoveToBench(manager.GetComponent<Manager>().NPC2Actions);
                    manager.GetComponent<Manager>().Part4 = true;
                }
            }
            else if(manager.GetComponent<Manager>().Part2 == true)
            {
                if(manager.GetComponent<Manager>().NPC1Actions.checkpointReached == true)
                {
                    manager.GetComponent<Manager>().NPC1Actions.receivedItem = true;
                    manager.GetComponent<Manager>().NPC1Actions.correctItem = true;
                    manager.GetComponent<Manager>().MoveToBench(manager.GetComponent<Manager>().NPC1Actions);
                    manager.GetComponent<Manager>().Part3 = true;
                }
            }

            if(manager.GetComponent<Manager>().NPC1Actions.correctItem == true)
            {
                manager.GetComponent<Manager>().numberCorrect += 1;
            }
            
        }
        else if(x == 2)
        {
            if(manager.GetComponent<Manager>().Part4 == true)
            {
                if(manager.GetComponent<Manager>().NPC3Actions.checkpointReached == true)
                {
                    manager.GetComponent<Manager>().NPC3Actions.receivedItem = true;
                    manager.GetComponent<Manager>().NPC3Actions.correctItem = false;
                    manager.GetComponent<Manager>().MoveToBench(manager.GetComponent<Manager>().NPC3Actions);
                    manager.GetComponent<Manager>().Part5 = true;
                }
            }
            else if(manager.GetComponent<Manager>().Part3 == true)
            {
                if(manager.GetComponent<Manager>().NPC2Actions.checkpointReached == true)
                {
                    manager.GetComponent<Manager>().NPC2Actions.receivedItem = true;
                    manager.GetComponent<Manager>().NPC2Actions.correctItem = true;
                    manager.GetComponent<Manager>().MoveToBench(manager.GetComponent<Manager>().NPC2Actions);
                    manager.GetComponent<Manager>().Part4 = true;
                }
            }
            else if(manager.GetComponent<Manager>().Part2 == true)
            {
                if(manager.GetComponent<Manager>().NPC1Actions.checkpointReached == true)
                {
                    manager.GetComponent<Manager>().NPC1Actions.receivedItem = true;
                    manager.GetComponent<Manager>().NPC1Actions.correctItem = false;
                    manager.GetComponent<Manager>().MoveToBench(manager.GetComponent<Manager>().NPC1Actions);
                    manager.GetComponent<Manager>().Part3 = true;
                }
            }

            if(manager.GetComponent<Manager>().NPC2Actions.correctItem == true)
            {
                manager.GetComponent<Manager>().numberCorrect += 1;
            }
            
        }
        else if(x == 3)
        {
            if(manager.GetComponent<Manager>().Part4 == true)
            {
                if(manager.GetComponent<Manager>().NPC3Actions.checkpointReached == true)
                {
                    manager.GetComponent<Manager>().NPC3Actions.receivedItem = true;
                    manager.GetComponent<Manager>().NPC3Actions.correctItem = true;
                    manager.GetComponent<Manager>().MoveToBench(manager.GetComponent<Manager>().NPC3Actions);
                    manager.GetComponent<Manager>().Part5 = true;
                }
            }
            else if(manager.GetComponent<Manager>().Part3 == true)
            {
                if(manager.GetComponent<Manager>().NPC2Actions.checkpointReached == true)
                {
                    manager.GetComponent<Manager>().NPC2Actions.receivedItem = true;
                    manager.GetComponent<Manager>().NPC2Actions.correctItem = false;
                    manager.GetComponent<Manager>().MoveToBench(manager.GetComponent<Manager>().NPC2Actions);
                    manager.GetComponent<Manager>().Part4 = true;
                }
            }
            else if(manager.GetComponent<Manager>().Part2 == true)
            {
                if(manager.GetComponent<Manager>().NPC1Actions.checkpointReached == true)
                {
                    manager.GetComponent<Manager>().NPC1Actions.receivedItem = true;
                    manager.GetComponent<Manager>().NPC1Actions.correctItem = false;
                    manager.GetComponent<Manager>().MoveToBench(manager.GetComponent<Manager>().NPC1Actions);
                    manager.GetComponent<Manager>().Part3 = true;
                }
            }
            
            if(manager.GetComponent<Manager>().NPC3Actions.correctItem == true)
            {
                manager.GetComponent<Manager>().numberCorrect += 1;
            }
        }
        else
        {

        }

        
    }
}
