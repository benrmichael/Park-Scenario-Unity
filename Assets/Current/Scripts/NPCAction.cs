using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAction : MonoBehaviour
{
    //this object stuff
    public Rigidbody myBody;
    public Animator myAnimator;

    //storing the player for when the NPC looks at the player
    //storing the bench and checkpoint used in the script to time out scenario
    [SerializeField] public GameObject thePlayer;
    [SerializeField] public GameObject myBench;
    [SerializeField] public GameObject myCheckpoint;

    //determines which item is desired by the NPC (later, maybe randomize the options?)
    [SerializeField] public GameObject myItem;

    //these flags are used to determine timing for the script, animation states, and to make sure the NPC is on the ground
    public bool active;             //so the scenarior knows this character will start their script
    public bool walking;            //used when the NPC is moving toward their goal. When walking, the walking animation plays
    public bool checkpointReached;  //when the NPC reaches the spot near the player, they are set to stop walking, turn to the player, and wave. Then they wait for their item
    public bool seated;             //after they receive an item, the NPC will go to a bench and take a seat before starting the next NPC script
    public bool receivedItem;       //this is for when an item collides with the NPC, triggering the sequence of the NPC moving away from the player toward its designated bench
    public bool correctItem;        //this flag is used in the end screen to show which items were correctly given to the NPC
    public bool isGrounded;         //used to make sure the NPC is on the ground, to keep it from walking on air


    //useful later, currently putting off audio for now until the scenario is closer to being complete
   // [SerializeField] public AudioSource myAudio;
   // [SerializeField] public AudioClip myHello;
    //[SerializeField] public AudioClip myThanks;
//
    //used later as well for the end screen
    //[SerializeField] public GameObject Correct;
    //[SerializeField] public GameObject Wrong;

    //when we start
    /*private void Start()
    {
        //declare the tools on the NPC object
        myBody = GetComponent<Rigidbody>();
        myAnimator = GetComponent<Animator>();
       // myAudio = GetComponent<AudioSource>();

        //time to set up some variables
        active = true;
        walking = false;
        checkpointReached = false;
        receivedItem = false;
        seated = false;
        isGrounded = false;
    }*/

    // Called from SetNpcItem() : safe since it will only be called once per scene
    private void StartScriptExecution()
    {
        Debug.Log("I am (" + this.name + ") and my item is: " + myItem.name);
        //declare the tools on the NPC object
        myBody = GetComponent<Rigidbody>();
        myAnimator = GetComponent<Animator>();
        // myAudio = GetComponent<AudioSource>();

        //time to set up some variables
        active = true;
        walking = false;
        checkpointReached = false;
        receivedItem = false;
        seated = false;
        isGrounded = false;
    }

    //once a frame, helps keep track of the state of the NPC
    private void Update()
    {
           //currently empty, as all the important parts are in fixedupdate instead (better for animations)

    }

    private void FixedUpdate()
    {   
        //this class is just for handling collisions and animations, so we handle movement here every frame
        //UpdateForward();
        HandleMovement();

    }

    //we use collision detection to trigger when the NPC hits its checkpoint or its bench to continue the scenario script
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Deadzone")
        {
            
        }

        //if the NPC hits the checkpoint object, it stops walking, it flags the checkpointreached, and it finds the player, turns to them, and plays the wave animation
        //all other stuff is handled in the manager object
        //later: add audio plays when they reach the checkpoint for a greeting and when receiving the item
        /*if(other.gameObject.tag == "Checkpoint")
        {
            
            checkpointReached = true;
            walking = false;
            Destroy(other);
            FindTarget(thePlayer);
            myAnimator.Play("Wave");
            //playAudio();
        }
        //when the NPC reaches its bench, it flags the seated, which will handle the rest in manager. It will turn around and sit on the bench where it will remain until the end of the scenario
        if(other.gameObject.tag == "Bench")
        {
            seated = true;
        }*/
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Item")
        {
            receivedItem = true;
        }

        if(other.gameObject.tag == "Checkpoint")
        {
            checkpointReached = true;
            walking = false;
            Destroy(other.gameObject);
            FindTarget(thePlayer);
            myAnimator.Play("Wave");
        }

        if(other.gameObject.tag == "Bench")
        {
            seated = true;
            walking = false;
            Destroy(other.gameObject);
            FindTarget(thePlayer);
            myAnimator.Play("Sit");
        }
    }

    //once a frame, the NPC checks the status of this object to see if it needs to play an animation or move
    private void HandleMovement()
    {
        //in order to avoid walking on air, we need to make sure the character falls first before moving or animating. so, we call the isGrounded function to make sure before we can trigger animation
        IsGrounded();
        //if we are grounded, and the NPC is active, they will move forward, play the walking animation, and continue until it reaches its destination (checkpoint or bench)
        if(isGrounded && active)
        {
            //if the character is walking, the walk animation plays and it moves forward
            if(walking == true)
            {
                myAnimator.Play("Walk");
                //myBody.velocity = Vector3.forward * 1.5f;
            }
            else
            {
                //if walking isnt falgged, the idle animation plays and the NPC stops moving forward
                myBody.velocity = new Vector3(0,0,0);
                //transform.forward = transform.forward;
            }
        }

        //UpdateForward();
    }

    //we need to have the NPC look at the player and at its bench when it is needed, so we pass in a target object and rotate the NPC toward it before it moves/interacts
    public void FindTarget(GameObject target)
    {
        Vector3 current = transform.forward;
        Vector3 to = target.transform.position - transform.position;
        to.y = 0;   //keeps the NPC from rotating upward... and floating to the sky forever
        transform.forward = Vector3.RotateTowards(current, to, 1100 * Time.deltaTime, 0.0f);
        
        //myBody.rotation = Quaternion.Euler(0.0f, 0.0f, myBody.velocity.x * )
        //myBody.forward = transform.forward;
    }

    //used to keep the character down on the ground before being able to move/rotate or animate. called once a frame within the handlemovement function
    private void IsGrounded()
    {
        //looks directly down, and if something is there, we are grounded, otherwise, we aren't, so we need to move down until we hit something
        //this means, if the character leaves the park, they fall forward... and fast
        RaycastHit raycastHit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down * 3), out raycastHit, 0.1f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

    }   

    private void UpdateForward()
    {
        Vector3 m_EulerAngleVelocity = new Vector3(0,100,0);
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
        myBody.MoveRotation(myBody.rotation * deltaRotation);
    }

    public void SetNpcItem(GameObject item)
    {
        myItem = item;
        StartScriptExecution();
    }

    public GameObject GetItemObject()
    {
        return myItem;
    }

}
