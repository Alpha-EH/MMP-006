using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    // Speed is declared with game units
    [SerializeField] private float speed = 2f;

    // Update is called once per frame
    private void Update()
    {
        // Here we verify if the distance between current waypoint and this gameobject is less then .1.
        // If that is the case we know that they are touching.
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
