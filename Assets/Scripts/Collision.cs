using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is applied to the Bullet prefab.
// collision.gameObject is the object that the bullet is colliding with.
// gameObject is the Bullet.
public class Collision : MonoBehaviour
{
    // Task 3: Destroy bullets when they collide with all game objects except the player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
