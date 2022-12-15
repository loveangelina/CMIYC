using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    //[SerializeField] int playerLives = 1;
    [SerializeField] float timelimit = 99;
    [SerializeField] float sceneLoadDelay = 2f;

    [SerializeField] TextMeshProUGUI timeText;
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
        timeText.text = timelimit.ToString();
        scoreText.text = score.ToString();
    }

    void Update()
    {
        timelimit -= Time.deltaTime;
        if(timelimit <= 0)
        {
            SceneManager.LoadScene("GameOver");
            Destroy(gameObject);
        }
        timeText.text = Mathf.Round(timelimit).ToString();
        
    }


    public void ProcessPlayerDeath()
    {
        StartCoroutine(GameOver());
        
        /*
        if(playerLives > 1)
        {
            StartCoroutine(ResetGameSession());
        }
        else
        {
            GameOver();
        }
        */
    }

    public void IncreaseScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSecondsRealtime(sceneLoadDelay);

        Debug.Log("Game Over");
        SceneManager.LoadScene("GameOver");
        Destroy(gameObject); // ���� �ٽý��� ���� �� �������̶� ���� �����ϱ� ����
    }

    /*
    IEnumerator ResetGameSession()
    {
        yield return new WaitForSecondsRealtime(sceneLoadDelay);

        playerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        
        livesText.text = playerLives.ToString();

        FindObjectOfType<ScenePersist>().ResetScenePersist();
    }
    */
}
