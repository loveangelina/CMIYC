using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeLevelExit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            // 함정 브금 
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }
        
    }
}
