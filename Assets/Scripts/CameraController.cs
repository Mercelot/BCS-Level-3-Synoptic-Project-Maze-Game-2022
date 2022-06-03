using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    // I am going to find the difference between the transforms of titus and the camera
    // referencing the player 
    public GameObject titus;
    // this stores the offset value. Its a vector 3 variable. 
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // Calculates when the game starts.
        offset = transform.position - titus.transform.position;
    }

    // Update is called once per frame
    // LateUpdate is like update but it does this after every other update is done. 
    // Camera position wont be set until player has moved for that frame. 
    void LateUpdate()
    {
        // Using the camera game objects transfor postion (every frame as it follows). 
        // adding the offset to titus position creates the difference. 
        transform.position = titus.transform.position + offset;
    }
}
