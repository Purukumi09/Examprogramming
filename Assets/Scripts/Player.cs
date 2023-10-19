using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;

    float rotation = 0.0f;
    float rotationSpeed = 250.0f * Mathf.Deg2Rad;
    float MoveSpeed = 2.0f;
    float BulletSpeed = 5.0f;
    

    void Start()
    {
        // Example code to create a bullet and change its velocity:
        GameObject bulletClone = Instantiate(bullet, new Vector3(0.0f, 2.5f, 0.0f), Quaternion.identity);
        bulletClone.GetComponent<Rigidbody2D>().velocity = Vector3.up * 5.0f;
        Destroy(bulletClone, 1.0f);
    }

    void Update()
    {
        float dt = Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
        {
            rotation += rotationSpeed * dt;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rotation -= rotationSpeed * dt;
        }

        Vector3 direction = new Vector3(Mathf.Cos(rotation), Mathf.Sin(rotation), 0.0f);
        Debug.DrawLine(transform.position, transform.position + direction * 10.0f);

        // Task 1: Move the player forwards when W is held, and backwards when D is held
        // Ensure movement is time-based

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += direction * Time.deltaTime * MoveSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position -= direction * Time.deltaTime * MoveSpeed;
        }
        // Task 2: Create a bullet when space is pressed
        // Ensure the bullet is not touching the player when it's created

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bulletClone = Instantiate(bullet, transform.position + direction, transform.rotation);
            bulletClone.GetComponent<Rigidbody2D>().velocity = direction * BulletSpeed;
        }
        // I'm adding the ability to poop bullets infinitely AND NOBODY CAN STOP ME, aka this is the extra task
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject bulletClone = Instantiate(bullet, transform.position - direction, transform.rotation);
            bulletClone.GetComponent<Rigidbody2D>().velocity = direction * BulletSpeed * -1;
        }
    }
}
