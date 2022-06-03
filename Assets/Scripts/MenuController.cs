using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public GameObject[] pauseUI; // Index 0 is button and index 2 is panel



    // Start is called before the first frame update
    void Start()
    {
        // Log some debug information only if this is a debug build
        if (Debug.isDebugBuild)
        {
            Debug.Log("This is a debug build!");
        }
    }

    // load the scene!
    public void TransitionScene(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void Pause()
    {
        // how slow and fast time moves in the game 
        // pause button will freeze the game. 
        // 0 is freeze
        Time.timeScale = 0;

        // index 0 is button
        pauseUI[0].SetActive(false);
        pauseUI[1].SetActive(true);
    }

    public void UnPause()
    {
        // how slow and fast time moves in the game 
        // pause button will freeze the game.
        // // 1 is real time
        Time.timeScale = 1;

        // index 0 is button
        pauseUI[0].SetActive(true);
        pauseUI[1].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
