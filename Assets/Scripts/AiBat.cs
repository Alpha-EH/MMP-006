using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBat : MonoBehaviour
{
    [SerializeField] public float speed;
    private GameObject player;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player == null)
            return;
        Chase();
    }


    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}



