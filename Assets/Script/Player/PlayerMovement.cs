using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private Collider2D coll;
    public float thrownSpace;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private PlayerShooting playerShooting;

    public enum MovementState { idle, running, jumping, falling }
    public MovementState currentMovementState = MovementState.idle;

    public GameObject frogDead, playerDead;
    public GameObject panelDead;

    private float dirX;
    private bool canMove = true; // Flag to allow or block player movement

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        playerShooting = GetComponent<PlayerShooting>();
    }

    void Update()
    {
        if (!canMove) // Block movement if `canMove` is false
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            return;
        }

        HandleMovement();
        UpdateAnimationState();
    }

    private void HandleMovement()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void UpdateAnimationState()
    {
        MovementState state = currentMovementState;

        if (dirX > 0f)
        {
            SetPlayerMovementState(MovementState.running);
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            SetPlayerMovementState(MovementState.running);
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            SetPlayerMovementState(MovementState.jumping);
        }
        else if (rb.velocity.y < -.1f)
        {
            SetPlayerMovementState(MovementState.falling);
        }

        anim.SetInteger("state", (int)state);
    }

    public void SetPlayerMovementState(MovementState state)
    {
        currentMovementState = state;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("AmmunitionBox"))
        {
            Destroy(collision.gameObject);
            PlayerShooting shootingScript = GetComponent<PlayerShooting>();
            if (shootingScript != null)
            {
                shootingScript.MountOfBullet += 10;
                shootingScript.BulletLeftText.text = shootingScript.MountOfBullet.ToString();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TouchTop"))
        {
            Destroy(collision.attachedRigidbody.gameObject);
            Instantiate(frogDead, collision.transform.position, collision.transform.rotation);
        }
    }

    public void ReloadScreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    private bool IsGrounded()
    {
        if (coll == null) return false;

        RaycastHit2D hit = Physics2D.BoxCast(
            coll.bounds.center,
            coll.bounds.size,
            0f,
            Vector2.down,
            0.1f,
            jumpableGround
        );

        return hit.collider != null;
    }

    // Disable player movement (called from TaskNPC or DialogManager)
    public void DisableMovement()
    {
        canMove = false;
        playerShooting.enabled = false;
        SetPlayerMovementState(MovementState.idle);
    }

    // Enable player movement (e.g., when exiting a dialog)
    public void EnableMovement()
    {
        canMove = true;
        playerShooting.enabled = true;
    }
}
