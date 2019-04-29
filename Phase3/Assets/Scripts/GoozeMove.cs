using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoozeMove : MonoBehaviour
{

    public Transform[] waypoints;
    int cur = 0;

    public float speed = 0.3f;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position != waypoints[cur].position)
        {
            Vector2 p = Vector2.MoveTowards(transform.position,
                                            waypoints[cur].position,
                                            speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }
        // Waypoint reached, select next one
        else cur = (cur + 1) % waypoints.Length;
    }

    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "student")
            Destroy(co.gameObject);
    }
}