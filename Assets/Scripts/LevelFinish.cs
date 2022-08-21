using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinish : MonoBehaviour
{
    private AudioSource finishSfx; 
    // Start is called before the first frame update
    private void Start()
    {
        finishSfx = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "PixelPlayer")
        {
            finishSfx.Play();
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        Scoring.savedScore = Scoring.totalScore;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}