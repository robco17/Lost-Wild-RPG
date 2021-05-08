using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// References were from https://answers.unity.com/questions/802253/how-to-restart-scene-properly.html

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Restarts the scene
    public void RestartScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
