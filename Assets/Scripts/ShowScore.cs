using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowScore : MonoBehaviour
{
    int score = 0;
    TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        GameSession gameSession = GetComponent<GameSession>();
        score = gameSession.GetScore();
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = score.ToString();
    }
}
