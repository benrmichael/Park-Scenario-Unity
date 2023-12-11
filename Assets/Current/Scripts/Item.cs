using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //This class is mainly to make sure items know how to work with other stuff in the scene
    //for the most part, it is to tell it to respawn if it hits the floor, to keep the items within reach of the player
    //the other is to update things when the item is thrown at the NPCs

    //we store the original position of the item so it can respawn correctly. currently faulty, as forward momentum is stored when respawned, so I need to set momentum to zero on respawn
    public Vector3 origin;

    //store the NPC type character
    [SerializeField] private GameObject NPC;
    [SerializeField] private GameObject manager;
    
    private void Start()
    {
        //saves the original position at the start
        origin = GetComponent<Rigidbody>().transform.position;
        manager = GameObject.Find("ScenarioManager");
    }

    //when the item collides with the floor, or deadzone, it is moved to the origin position again
    //this is where I would adjust the momentum problem later
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "DeadZone")
        {
            
            gameObject.transform.position =  origin;
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        }

        
    }

    //when the item collides with an NPC object, we check the information stored in the NPC and delete this object
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Inventory")
        {

        }
        else if(other.gameObject.tag ==  "NPCBox")
        {
            //first, we store the NPC we collided with's data
            NPC = other.gameObject;

            //we look for its receivedItem flag and set it to true because it has received an item
            //NPC.GetComponent<NPCAction>().receivedItem = true;

            //we then look to see if this item is the same as the desired item stored in the NPC scripts
            //if it is, the correctItem flag is set to true
<<<<<<< HEAD
	    Debug.Log("NPC (" + NPC.name + ") item -> " + NPC.GetComponent<NPCAction>().GetItemObject().name
		+ ". Actual item: " + gameObject.name);
            if(GameObject.ReferenceEquals(gameObject, NPC.GetComponent<NPCAction>().GetItemObject()))
=======
            if(GameObject.ReferenceEquals(gameObject, NPC.GetComponent<NPCAction>().myItem))
>>>>>>> 7f6ba21916b8b97113b7c9b0a2eb474cb61d23fd
            {
                NPC.GetComponent<NPCAction>().correctItem = true;
                manager.GetComponent<Manager>().numberCorrect += 1;
            }
            else        //if it isn't, the correct item isn't flag true
            {
                NPC.GetComponent<NPCAction>().correctItem = false;
            }

            //either way, the scenario continues with these updated values
            //then, we destroy the item to keep it out of the scenario
            //Destroy(gameObject);

            gameObject.transform.position =  origin;
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        }
        else if(other.gameObject.tag == "Deadzone")
        {
            gameObject.transform.position =  origin;
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        }
    }
}
