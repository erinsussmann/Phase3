using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float increment;
    public float maxY;
    public float minY;

    private Vector2 targetPos;

    public int health = 3;

    private void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxY)
        {
            
            targetPos = new Vector2(transform.position.x, transform.position.y + increment);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minY)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - increment);
        }
    }
}
