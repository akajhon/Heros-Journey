using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadGameScene", 10f);
    }

    // Load the Game scene
    void LoadGameScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        switch(currentScene) {
            case "Final1CutScene":
                SceneManager.LoadScene("Final1");
                break;
            case "FinalAlternativoCutScene":
                SceneManager.LoadScene("FinalAlternativo");
                break;
            default:
            case "CutScene":
                SceneManager.LoadScene("Game");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
