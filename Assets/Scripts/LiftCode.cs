using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftCode : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    private bool isMoving = false;
    // Speed is declared with game units
    [SerializeField] private float speed = 2f;

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {   // Here we verify if the distance between current waypoint and this gameobject is less then .1.
        // If that is the case we know that they are touching.
        Debug.Log("lift code started");
        if (collision.gameObject.CompareTag("Player"))
        {
            isMoving = true;
        }
    }

    private void Update()
    {
        if (isMoving)
        {
            if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = 0;
                }
            }
            // We set the position of the object here relative to the observed waypoint. We use Time.deltaTime to 
            // make the movement FrameRate independent.
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
        }
    }
}
