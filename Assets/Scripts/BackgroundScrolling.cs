using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    [SerializeField] [Range(0.1f, 10f)] float speed = 0.5f;
    [SerializeField] float posValue;

    Vector2 startPos;
    float newPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        newPos = Mathf.Repeat(Time.time * speed, posValue);
        transform.position = startPos + Vector2.right * newPos;
    }
}
