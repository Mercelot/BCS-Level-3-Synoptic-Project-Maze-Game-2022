using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gigas : MonoBehaviour
{
    // ref the SO 
    public Character character;

    // speed of character which wont be used. I will be using SO. 
    // below variable is used for testing...
    // public float speed = 0;
    public List<Transform> waypoints;

    private int waypointIndex;
    // within what range the enemy is to the waypoint point. 
    private float range;

    // moved to Titus as I wanted to call the respawn function
    // player death on touch
    // public GameObject titus;

    // Start is called before the first frame update
    void Start()
    {
        waypointIndex = 0;
        // forgot to add the f to the float
        // didnt work for 30 minutes
        range = 1.0f;

        // character.Print();
        // to set size fo Besek using SO. (Polymorphism too). 
        transform.localScale = character.size;

        // debug for gigas
        character.GigasDebug();
    }

    // calls the function ever frame 
    void Update()
    {
        Move();

        // Height Exception
        if (transform.position.y < -10)
        {
            Debug.Log("EnemyOutOfBoundsException: You can still play but the player experience is not complete.");
        }
    }

    void Move()
    {
        // Takes (looks at) the target transform (which is a waypoint)
        // Besek is looking at this waypoint. 
        transform.LookAt(waypoints[waypointIndex]);
        // move the enemy in the forward direction (to the waypoint its looking at. multiplied by speed and time.deltatime for
        // in seconds rather than in frame. (Makes it smoother)
        transform.Translate(Vector3.forward * character.speed * Time.deltaTime);
        // checks where enemy is in relation to the waypoint, and identifies 
        // if it should go to the next waypoint
        // uses the scope variable for range. 
        // is the distance between besek and the waypoint less than 1.0f? move to next waypoint!
        if (Vector3.Distance(transform.position, waypoints[waypointIndex].position) < range)
        {
            // plus one to the waypoint index
            waypointIndex++;
            // make sure we are not out of scope
            // if we are out of range, set waypoint back to 0
            if (waypointIndex >= waypoints.Count)
            {
                // setting it back to 0 means this will go on indefinitely 
                waypointIndex = 0;
            }
        }
    }

    
}
