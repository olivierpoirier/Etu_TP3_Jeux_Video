using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{

    public void QuitGame()
    {
        // #if UNITY_EDITOR
        //         UnityEditor.EditorApplication.isPlaying = false;  
        // #else 
        //         Application.Quit();
        // #endif      
        print("Quit game"); 
    }


    public void PlayGame()
    {
        SceneManager.LoadScene ("DemoScene");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
