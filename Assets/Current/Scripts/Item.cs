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
    private Quaternion initialRotation;

    //store the NPC type character
    [SerializeField] private GameObject NPC;
    [SerializeField] private GameObject manager;
    
    private void Start()
    {
        //saves the original position at the start
        origin = GetComponent<Rigidbody>().transform.position;
	initialRotation = transform.rotation;
        manager = GameObject.Find("ScenarioManager");
    }

    // When an item collides with the floor (aka DeadZone) we reset it back to the original position/rotation, and set all velocity to 0.
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "DeadZone")
        {
            
            RespawnItem();
        }

        
    }

    //when the item collides with an NPC object, we check the information stored in the NPC and delete this object
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Inventory")
        {	
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
	    gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
        else if(other.gameObject.tag ==  "NPCBox")
        {
            //first, we store the NPC we collided with's data
            NPC = other.gameObject;

            //we look for its receivedItem flag and set it to true because it has received an item
            //NPC.GetComponent<NPCAction>().receivedItem = true;

            //we then look to see if this item is the same as the desired item stored in the NPC scripts
            //if it is, the correctItem flag is set to true
	    Debug.Log("NPC (" + NPC.name + ") item -> " + NPC.GetComponent<NPCAction>().GetItemObject().name
		+ ". Actual item: " + gameObject.name);
            if(GameObject.ReferenceEquals(gameObject, NPC.GetComponent<NPCAction>().GetItemObject()))
            {
                NPC.GetComponent<NPCAction>().correctItem = true;
                manager.GetComponent<Manager>().numberCorrect += 1;
            }
            else        //if it isn't, the correct item isn't flag true
            {
                NPC.GetComponent<NPCAction>().correctItem = false;
            }

            //either way, the scenario continues with these updated values
            RespawnItem();
        }
        else if(other.gameObject.tag == "Deadzone")
        {
            RespawnItem();
        }
    }

    // Reset the current game object back to it's original position/rotation with nil velocity
    private void RespawnItem()
    {
	gameObject.transform.position =  origin;
	gameObject.transform.rotation = initialRotation;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
	gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
