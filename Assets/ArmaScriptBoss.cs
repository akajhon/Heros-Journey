using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArmaScriptBoss : MonoBehaviour
{
    private int life = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boss")
        {
            if ((life - 1) == 0)
            {
              life = 0;
              Destroy(collision.gameObject);

              string currentScene = SceneManager.GetActiveScene().name;
              switch(currentScene) {
                case "FinalAlternativo":
                    SceneManager.LoadScene("EndSceneAlternativo");
                    break;
                case "Final1":
                    SceneManager.LoadScene("EndScene1");
                    break;
                default:
                    break;
              }
            }
            else
            {
                life--;
            }
        }
        else if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.DecreaseLife(1);
        }
    }
}
