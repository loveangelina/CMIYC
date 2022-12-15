using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            StartCoroutine(GameOver());
        }
        
    }
    
    IEnumerator GameOver()
    {
        yield return new WaitForSecondsRealtime(2f);

        Debug.Log("Game Clear");
        SceneManager.LoadScene("Exit");
        Destroy(gameObject); 
    }
}
