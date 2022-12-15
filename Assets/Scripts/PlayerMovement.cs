using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2(10f, 10f);
    //[SerializeField] GameObject bullet;
    //[SerializeField] Transform gun;

    Vector2 moveInput;
    Rigidbody2D rigidbody;
    Animator animator;

    CapsuleCollider2D bodyCollider;
    BoxCollider2D feetCollider;

    float gravityScaleAtStart;

    bool isAlive = true;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        bodyCollider = GetComponent<CapsuleCollider2D>();
        feetCollider = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = rigidbody.gravityScale;
    }


    void Update()
    {
        if (!isAlive) { return; }
        Run();
        FlipSprite();
        ClimbLadder();
        Die();
    }

    void OnMove(InputValue value)
    {
        if (!isAlive) { return; }
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (!isAlive) { return; }
        if (!feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) // ���� 2�� ���ϰ� ����
        {
            return;
        }

        if(value.isPressed)
        {
            rigidbody.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    /*
    void OnFire(InputValue value)
    {
        if (!isAlive) { return; }
        Instantiate(bullet, gun.position, transform.rotation);
    }
    */

    void Run()
    {
        Vector2 myPlayerVelocity = new Vector2(moveInput.x * runSpeed, rigidbody.velocity.y);
        rigidbody.velocity = myPlayerVelocity;

        bool playerhasHorizontalSpeed = Mathf.Abs(rigidbody.velocity.x) > Mathf.Epsilon;
        animator.SetBool("IsRunning", playerhasHorizontalSpeed);
    }

    void FlipSprite()
    {
        bool playerhasHorizontalSpeed = Mathf.Abs(rigidbody.velocity.x) > Mathf.Epsilon;

        if(playerhasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rigidbody.velocity.x), 1f);
        }
    }
   
    void ClimbLadder()
    {
        if (!feetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            rigidbody.gravityScale = gravityScaleAtStart; // ��ٸ��� �ȹ�� ������ gravity�� �������
            animator.SetBool("IsClimbing", false);
            return;
        }

        Vector2 climbVelocity = new Vector2(rigidbody.velocity.x, moveInput.y * climbSpeed);
        rigidbody.velocity = climbVelocity;
        rigidbody.gravityScale = 0; // ��ٸ����� ���� �������� ���� ����

        bool playerhasVerticalSpeed = Mathf.Abs(rigidbody.velocity.y) > Mathf.Epsilon;
        animator.SetBool("IsClimbing", playerhasVerticalSpeed);
    }    

    void Die()
    {
        if (bodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemies", "Hazards"))) 
        {
            isAlive = false;

            animator.SetTrigger("Dying");
            rigidbody.velocity = deathKick;

            FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }
    }
}
