using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Animator animator;

    [SerializeField] private AudioSource deathSfx;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Collision detection with colision objact that has the informaiton
    // with what we colided with.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the player has colided with trap it should die.
        if (collision.gameObject.CompareTag("Trap") ||
           collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }

    // Death method that set the trigger which in return executes death animation
    private void Die()
    {
        deathSfx.Play();
        rigidBody.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("death");
    }

    private void RestartLevel()
    {
        Scoring.totalScore = Scoring.savedScore;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
