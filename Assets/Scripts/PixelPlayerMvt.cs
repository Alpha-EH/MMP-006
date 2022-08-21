using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelPlayerMvt : MonoBehaviour
{
    //Script Parameters
    private Rigidbody2D player;
    private BoxCollider2D groundColl;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jmpGround;

    private float xDir = 0f;
    [SerializeField] private float mvtSpeed = 8f;
    [SerializeField] private float jmpHeight = 15f;

    //MvtState states all possible movement states of the player, enum values are referenced in Unity by an int value
    private enum MvtState { IDLE, RUNNING, JUMPING, FALLING };
    //Audio source for when a melon is collected
    [SerializeField] private AudioSource jumpSfx;

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Player movement started.");
        player = GetComponent<Rigidbody2D>(); //player model is a rigid body
        groundColl = GetComponent<BoxCollider2D>(); //checks for collisions with the ground
        anim = GetComponent<Animator>(); 
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        // player can exit the game with escape key
        if (Input.GetKey("escape"))
        {
            Debug.Log("Player has quit the game");
            Application.Quit();
        }

        xDir = Input.GetAxisRaw("Horizontal");
        player.velocity = new Vector2(xDir * mvtSpeed, player.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded()) //checks that the jump button is pressed and that the player is standing on a jumpable ground
        {
            jumpSfx.Play();
            player.velocity = new Vector2(0, jmpHeight);
        }

        UpdateAnimation();

    }
    private void UpdateAnimation()
    {
        MvtState state;
        xDir = Input.GetAxisRaw("Horizontal");
        //Movement states on the ground
        if (xDir > 0f)
        {
            state = MvtState.RUNNING;
            sprite.flipX = false;
        }
        else if (xDir < 0f)
        {
            state = MvtState.RUNNING;
            sprite.flipX = true;
        }
        else
        {
            state = MvtState.IDLE;
        }
        //Movement states in mid-air
        if(player.velocity.y > .1f)
        {
            state = MvtState.JUMPING;
        } else if(player.velocity.y < -.1f)
        {
            state = MvtState.FALLING;
        }
        
        //SetInteger expects an int value as its second argument
        anim.SetInteger("state", (int)state);
    }

    //Checks if the player is on the layer 'Ground', from which jumping is possible
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(groundColl.bounds.center, groundColl.bounds.size, 0f, Vector2.down, .1f, jmpGround);
    }
}
