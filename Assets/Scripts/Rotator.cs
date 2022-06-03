using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Kuin kuin;

    void Start()
    {
        // console logs the count 21 times rather than states 21.
        kuin.KuinCount();
    }

    void Update()
    {
        // Rotate x axis by 15, y axis by 30 and z axis by 45
        // multiplied by delta time means per second 
        // not per frame. 
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
        
    }
}
