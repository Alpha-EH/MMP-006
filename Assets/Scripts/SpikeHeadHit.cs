using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHeadHit : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Collision detection with colision objact that has the informaiton
    // with what we colided with.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the player has colided with trap it should die.
        if (collision.gameObject.CompareTag("Player"))
        {
            HitAnimation();
        }
    }

    // Death method that set the trigger which in return executes death animation
    private void HitAnimation()
    {
        animator.SetTrigger("hit");
    }
}
