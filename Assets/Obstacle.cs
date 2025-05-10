using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // Move backward in the Z-axis (towards the player)
        transform.Translate(0, 0, -speed * Time.deltaTime, Space.World);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject); // Remove the obstacle when off screen
    }
}
