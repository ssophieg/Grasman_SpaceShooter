using Codice.Client.BaseCommands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    private Vector3 velocity = Vector3.right * 0.001f;

    private float accelerationTime = 5f;
    private float maxSpeed = 15f;
    private float acceleration;
    private float defaultSpeed = 6f;
    private float speed;

    //Task 1c
    private float decelerationTime = 2f;
    private float deceleration;
    
    void Start()
    {
        speed = defaultSpeed;
        acceleration = maxSpeed / accelerationTime;
        deceleration = maxSpeed / decelerationTime;
    }

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            speed += acceleration * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            speed += acceleration * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            speed += acceleration * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            speed += acceleration * Time.deltaTime;
        }

        //task1c
        if (Input.anyKey == false)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            speed -= deceleration * Time.deltaTime;
        }

        if (speed >= maxSpeed)
        {
            speed = maxSpeed;
        }

        if (speed < 0)
        {
            speed = 0;
        }
    }

}
