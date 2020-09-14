using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public int totalScore = 0;
    public Text scoreText;

    public GameObject gameOver;

    float currentTime = 0f;
    float startingTime = 20f;

    [SerializeField]
    Text timerText;

    public static GameController instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentTime = startingTime;
    }

    void Update ()
    {
        currentTime -= 1 * Time.deltaTime;
        timerText.text = currentTime.ToString("00");

        if(currentTime <= 0)
        {
            currentTime = 0;
            ShowGameOver();
        }
    }

    public void UpdateScoreText()
    {
        currentTime += 5f;
        scoreText.text = totalScore.ToString();
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    public void RestartGame(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }
}
