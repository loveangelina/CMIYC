using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] int pointsForCoinPickup = 100;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position, 0.5f);
            Destroy(gameObject);
            FindObjectOfType<GameSession>().IncreaseScore(pointsForCoinPickup);
        }
    }
}
