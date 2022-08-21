using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //UI element object types are not supported by default

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI melonCounter; //text field in Unity that contains our melon counter
    [SerializeField] private AudioSource collectedSfx; //sound for when a melon is collected
    [SerializeField] private bool isEnding = false;

    private void Start()
    {
        melonCounter.text = $"Melons: {Scoring.savedScore}"; //updates the text 
        if (isEnding)
        {
            melonCounter.text = $"You have collected {Scoring.totalScore} melons!";
        }
    }
    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Melon")) //checks that an object with the tag "Melon" has been in collision
        {
            collectedSfx.Play();
            Destroy(collision.gameObject); //makes melon disappear
            Scoring.totalScore++;
            Debug.Log($"Melons eaten: {Scoring.totalScore}"); //logs the value of melonsCollected to the console
            melonCounter.text = $"Melons: {Scoring.totalScore}"; //updates the text 
        }
    }
}
