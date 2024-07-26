using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class User : MonoBehaviour
{
    public static User obj; // Singleton.

    public int lives = 3;

    public bool isGrounded = false; // Know if the user is touching the ground or not.
    public bool isMoving = false; // Know if the user is moving or not.
    public bool isImmune = false;

    public float speed = 5f; // speed with which the user can move.
    public float jumpForce = 3f; // The force with which the user can jump.
    public float movHor; // Horizontal movement of the user.

    public float immuneTimeCnt = 0f;
    public float immuneTime = 0.5f;

    public LayerMask groundLayer; // We will put a layer on the ground, to know when the user touches the ground.
    public float radius = 0.3f; // Know if the user is really touching the ground.
    public float groundRayDist = 0.5f; // Know if the user is really touching the ground.

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spr;

    private void Awake() // Singleton Awake.
    {
        obj = this;
    }

    // Start is called before the first frame update.
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // With this line, we now have access to the user's rigidbody.
        anim = GetComponent<Animator>(); // With this line, we now have access to the user's Animator.
        spr = GetComponent<SpriteRenderer>(); // With this line, we now have access to the user's SpriteRenderer.
    }

    // Update is called once per frame.
    void Update()
    {
        movHor = Input.GetAxisRaw("Horizontal"); // Being able to move the user horizontally (<- and -> in the keyboard).

        isMoving = (movHor != 0f); // To know if the user is moving or not.

        isGrounded = Physics2D.CircleCast(transform.position, radius, Vector3.down, groundRayDist, groundLayer); // To know if the user is touching the ground or not.

        if (Input.GetKeyDown(KeyCode.Space)) // Jump instroction, if input is received from the "space" key, it calls the jump function.
        Jump();

        Flip(movHor); // The function is called to make the user object change where it moves.

        anim.SetBool("isMoving", isMoving); // The variable is sent to make the animations.
        anim.SetBool("isGrounded", isGrounded); // The variable is sent to make the animations.
    }

    private void FixedUpdate() // Everything about physics.
    {
        rb.velocity = new Vector2(movHor * speed, rb.velocity.y); // Vector2 = It is a set of values {x} and {y}.
    }

    public void Jump() // Jump function.
    {
        if (!isGrounded) return; // If the user is not on the ground, go out and nothing happens {!}.

        rb.velocity = Vector2.up * jumpForce; // If the user is on the ground, jump.
    }

    private void Flip(float _xValue) // Change the direction of the user where they move.
    {
        Vector3 theScale = transform.localScale;

        if (_xValue < 0)
            theScale.x = Mathf.Abs(theScale.x) * -1;
        else
        if (_xValue > 0)
            theScale.x = Mathf.Abs(theScale.x);
        
        transform.localScale = theScale;
    }

    private void OnDestroy() // Singleton OnDestroy.
    {
        obj = null;
    }
}
