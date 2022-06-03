using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Kuin", menuName = "Kuin")]
public class Kuin : ScriptableObject
{
    // Start is called before the first frame update
    public new string name;
    public string description;
    public int value;

    // was a game object first. I used count.Length in debug log and it didnt print 21,
    // it logged 21 times and that it was an object
    // changed to int and now logs 21, 21 times. one step closer! 
    private int count;
    

    
    // Printing the base variables 
    public void Print()
    {
        Debug.Log("Name: " + name + ". Description: " + description + " Value: " + value + ": ");
    }

    // Kuin Count Debug
    public void KuinCount()
    {
        count = GameObject.FindGameObjectsWithTag("Pickup").Length;
        Debug.Log("Kuin Count: " + count);

        // Kuin Count exception.
        if (count < 21)
        {
            Debug.Log("WinConditionException: You need 21 Kuins to reach win state. Restart Game to reload.");
        }
        else
        {
            Debug.Log("Kuin Count optimal for Win Conditions");
        }
    }
}
