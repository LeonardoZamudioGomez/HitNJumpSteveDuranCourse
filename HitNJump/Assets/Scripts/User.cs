using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class User : MonoBehaviour
{
    public static User obj; // Singleton.

    public int lives = 3;

    public bool isGrounded = false; // Know if the user is touching the floor or not.
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
        
    }

    // Update is called once per frame.
    void Update()
    {
        movHor = Input.GetAxisRaw("Horizontal"); // Being able to move the user horizontally.
    }

    private void FixedUpdate() // Everything about physics.
    {
        
    }

    private void OnDestroy() // OnDestroy Singleton.
    {
        obj = null;
    }
}
