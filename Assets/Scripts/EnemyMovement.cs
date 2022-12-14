using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D rigidbody;
    CapsuleCollider2D enemyCollider;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        enemyCollider = GetComponent<CapsuleCollider2D>();
    }


    void Update()
    {
        rigidbody.velocity = new Vector2(moveSpeed, 0f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // ���� ������ ���� �ٲٱ�
        if(collision.tag == "Ground")
        {
            moveSpeed = -moveSpeed;

            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }

    }
}
