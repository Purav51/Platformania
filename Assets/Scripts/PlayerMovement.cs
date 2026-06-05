using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    Vector2 MoveInput;
    Rigidbody2D rb;
    Animator animator;
    CapsuleCollider2D myCapsCollider;

    float gravityScaleAtStart;
    bool isAlive = true;

    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    [SerializeField] float playerMoveSpeed = 6.43f;
    [SerializeField] float jumpSpeed = 6.43f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2(-20f, 27f);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        myCapsCollider = GetComponent<CapsuleCollider2D>();
        gravityScaleAtStart = rb.gravityScale;
    }
    void Update()
    {
        if (!isAlive)
        {
            return;
        }
        Run();
        FlipSprite();
        ClimbLadder();
        GameOver();
    }
    void OnMove(InputValue val)
    {
        if (!isAlive)
        {
            return;
        }
        MoveInput = val.Get<Vector2>();
    }
    void OnJump(InputValue value)
    {
        if (!isAlive)
        {
            return;
        }
        if (!myCapsCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }
        if (value.isPressed)
        {
            rb.linearVelocity += new Vector2(0f, jumpSpeed);
        }
    }
    void OnAttack(InputValue val)
    {
        if (!isAlive)
        {
            return;
        }
        // if (!myCapsCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }
        if (val.isPressed)
        {
            Instantiate(bullet, gun.position, transform.rotation);
        }
    }
    void Run()
    {
        Vector2 playerVel = new Vector2(MoveInput.x * playerMoveSpeed, rb.linearVelocity.y);
        rb.linearVelocity = playerVel;
        bool hasHorizntalSpeed = Mathf.Abs(rb.linearVelocity.x) > Mathf.Epsilon;
        animator.SetBool("isRunning", hasHorizntalSpeed);

    }
    void FlipSprite()
    {
        bool hasHorizntalSpeed = Mathf.Abs(rb.linearVelocity.x) > Mathf.Epsilon;
        if (hasHorizntalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.linearVelocity.x), 1f);
        }
    }
    void ClimbLadder()
    {

        if (!myCapsCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            rb.gravityScale = gravityScaleAtStart;
            animator.SetBool("isClimbing", false);
            return;
        }
        Vector2 playerVel = new Vector2(rb.linearVelocity.x, MoveInput.y * climbSpeed);
        rb.linearVelocity = playerVel;
        rb.gravityScale = 0f;
        bool hasClimbSpeed = Mathf.Abs(rb.linearVelocity.y) > Mathf.Epsilon;
        animator.SetBool("isClimbing", hasClimbSpeed);
    }
    void GameOver()
    {
        if (myCapsCollider.IsTouchingLayers(LayerMask.GetMask("Enemies", "Hazards")))
        {
            isAlive = false;
            animator.SetTrigger("GameOver");
            rb.linearVelocity = deathKick;
            StartCoroutine(Respawn());
        }

    }
    IEnumerator Respawn()
    {
        yield return new WaitForSecondsRealtime(1f);
        FindAnyObjectByType<GameSession>().ProcessPlayerDeath();
    }
}
