using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    public Text scoreText;

    public int life = 15;
    public Text lifeText;

    public void Start()
    {
        Invoke("HideInstructions", 15f);
    }

    private void HideInstructions()
    {
        GameObject instructions = GameObject.Find("Instrucoes");
        if (instructions != null) instructions.SetActive(false);
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void IncreaseScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }

    public void DecreaseLife(int value)
    {
        if (life - value == 0) {
            // reset life
            life = 15;
            lifeText.text = life.ToString();
            // reset score
            score = 0;
            scoreText.text = score.ToString();
            // reset scene
            SceneManager.LoadScene("Game");
            return;
        }
        life -= value;
        lifeText.text = life.ToString();
    }
}
