using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Titus : MonoBehaviour
{
    // Referencing the scriptable object
    // Data container that stores configuration's. 
    public Character character;
    // in game UI
    // holds ref to ui text component.
    public TextMeshProUGUI kuinText;
    // you win text object
    public GameObject winTextObject;
    // Creates a private variable of the type rigidbody
    // ref to rigid body that I am accessing for player movement. 
    private Rigidbody rb;
    // Ref gate game object
    // destroys gate when kuin limit reached
    public GameObject gate;
    // ref to respawn point
    public List<Transform> respawnPoint;
    // destroy besek variable
    public GameObject besek;
    
    // start with a count value of 0. Each time Titus picks up a Kuin,
    // it will increase
    private int kuin;

    // declaring move variables for vector 3. 
    private float moveX;
    private float moveY;
    // public float mSpeed = 5.0f;

    // Start is called before the first frame update
    private void Start()
    {
        // this function lives in character SO.
        // its a debug that prints specified data to console. 
        // character.Print();
        // Sets rb variable to rigidbody that is already attached to Titus. 
        rb = GetComponent<Rigidbody>();

        // Setting the scale of Titus using SO
        transform.localScale = character.size;
        // initial count value 
        // will increase when playing collects a kuin. 
        kuin = 0;
        // function to se the kuintext
        SetKuinText();
        winTextObject.SetActive(false);
        // debug for titus
        character.TitusDebug();

    }

    private void Update()
    {
        // if height is below -10 on the y axis then respawn player. 
        if(transform.position.y < -10)
        {
            Respawn();
        }
    }

    // This is where te Unity Input System will be sending data to my script. The type of is InputValue. movementValue is the variable
    // I will be using that captures the directional input of the keyboard arrows. 
    void OnMove(InputValue moveValue)
    {
        // Get movement input data from the sphere and store as variable. Vector 2 covers (x,y). 
        // I then store this data in the movementVector variable
        Vector2 moveVector = moveValue.Get<Vector2>();
        // Apply force to the rigid body in order to move the player.
        moveX = moveVector.x;
        moveY = moveVector.y;
    }

    void SetKuinText()
    {
        // setting the kuinText component to kuin. 
        // So we can show the count! 
        kuinText.text = "Kuin: " + kuin.ToString();
        // win conditions
        if (kuin >= 2100)
        {
            winTextObject.SetActive(true);
            // invoke coroutine disable after 5 seconds
            StartCoroutine(DisableAfter5Seconds());
        }
    }
    // disable after 5 seconds function
    IEnumerator DisableAfter5Seconds()
    {
        // 5 second wait
        yield return new WaitForSeconds(5);
        // then return false
        winTextObject.SetActive(false);
        
    }

    void FixedUpdate()
    {
        Vector3 move = new Vector3(moveX, 0.0f, moveY);

        // AddForce adds force to the rigidbody for movement! 
        // 1. Access rigid body component on titus
        // 2. uses user input
        // 3. adds force to the rigidbody 
        // as I have a Vector2 moveVector variable that stores the input I created 2 new variables that deals
        // specifically with the axis of movement. 
        rb.AddForce(move * character.speed);

        // Power up speed
        if (kuin >= 1400)
        {
            rb.AddForce(move * character.speed * 1.2f);
        } 
        
        // Destroy gate
        if (kuin == 2000)
        {
            Destroy(gate);
        }

        // debug as movement not working
        // 1st issue found moveX twice in playermove function. 
        // 2nd issue, I idnt name the OnMove function appropriately. 
        // fixed and now working. 
        // used this debug to check if this class is receiving the speed from SO.
        // Debug.Log(character.speed);
    }

    // Setting up the collider function
    // deactivating the game object 
    // On trigger I can disable the game object. 
    // I have to set what I am going to disable. 
    private void OnTriggerEnter(Collider other)
    {
        // if a game object has a tag, and we collide with it
        // then set its status to false
        // i can also use destroy
        if (other.gameObject.CompareTag("Pickup")) 
        {
            other.gameObject.SetActive(false);
            // adds the value of a kuin to the variable. 
            // kuin = kuin + 100;
            kuin = kuin + 100;
            SetKuinText();
        }
    }

    // One Touch Kill
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Gigas")
        {
            Debug.Log("You are dead");
            Respawn();
        }
        // Power up over 1400 collision besek!
        if (kuin >= 1400) 
        {
            // To select specific names of objects 
            if (collision.gameObject.name == "Besek" 
                || collision.gameObject.name == "Besek (1)" 
                || collision.gameObject.name == "Besek (2)")
            {
                Destroy(collision.gameObject);
            }
            
        }
    }

    void Respawn()
    {
        // 0 the velocity as its a rigidbody and forces still apply on respawn
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        // dont process rb for atleast one frame.
        rb.Sleep();
        // take rb and make its position equal to the respawn point
        // count the length of the list, getting a random index and indexing it 
        // count is 3 
        transform.position = respawnPoint[Random.Range(0, respawnPoint.Count)].position;
    }
}
