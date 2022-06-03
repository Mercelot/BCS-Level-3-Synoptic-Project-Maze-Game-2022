using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character")]
public class Character : ScriptableObject
{
    // Definitions 
    public new string name;
    public string description;
    public int speed;
    public string power;
    public Vector3 size;

    // Debug logs 
    private int enemyGigas;
    private int enemyBesek;
    private int playerTitus;

    // Initial SO Testing 
    public void Print()
    {
        Debug.Log("Name: " + name + ". Description: " + description + " Speed: " + speed + ": ");
    }

    // DEBUG 
    public void BesekDebug()
    {
        // BESEK
        enemyBesek = GameObject.FindGameObjectsWithTag("Besek").Length;
        // Debug.Log("Besek Count: " + enemyBesek);
        // Besek Count exception.
        if (enemyBesek < 3)
        {
            Debug.Log("EnemyBesekException: There should be 3 Besek for the full gaming experience. Restart Game to reload.");
        }
        else
        {
            Debug.Log("Besek count optimal for player conditions");
        }
    }

    public void GigasDebug()
    {
        // GIGAS
        enemyGigas = GameObject.FindGameObjectsWithTag("Gigas").Length;
        // Debug.Log("Gigas Count: " + enemyGigas);
        // Gigas Count exception.
        if (enemyGigas < 1)
        {
            Debug.Log("EnemyBesekException: There should be 1 Gigas for the full gaming experience. Restart Game to reload.");
        }
        else
        {
            Debug.Log("Gigas count optimal for player experience");
        }
    }

    public void TitusDebug()
    {
        // TITUS
        playerTitus = GameObject.FindGameObjectsWithTag("Titus").Length;
        // Debug.Log("Titus Count: " + playerTitus);
        // Titus Count exception.
        if (playerTitus < 1)
        {
            Debug.Log("PlayerNonExistentException: You cant play without Titus! Restart Game to reload.");
        }
        else
        {
            Debug.Log("Titus count optimal for Win Conditions");
        }
    }
}   


