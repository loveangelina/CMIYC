using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] float sceneLoadDelay = 2f;

    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    int score = 0;
    CoinPickup coinPickup;

    public Image fadePlane;

    void Awake()
    {
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;
        if(numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
    }


    public void ProcessPlayerDeath()
    {
        if(playerLives > 1)
        {
            StartCoroutine(ResetGameSession());
        }
        else
        {
            GameOver();
        }
    }

    public void IncreaseScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();
    }

    void GameOver()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene("GameOver");
        Destroy(gameObject); // 게임 다시시작 했을 때 생명력이랑 점수 리셋하기 위함
    }

    IEnumerator ResetGameSession()
    {
        yield return new WaitForSecondsRealtime(sceneLoadDelay);

        playerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        
        livesText.text = playerLives.ToString();

        FindObjectOfType<ScenePersist>().ResetScenePersist();
    }
}
