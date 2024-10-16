using Codice.Client.BaseCommands;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    //power up
    public GameObject powerUpPrefab;

    private Vector3 velocity = Vector3.right * 0.001f;

    private float accelerationTime = 5f;
    private float maxSpeed = 15f;
    private float acceleration;
    private float defaultSpeed = 0f;
    private float speed;

    //Task 1c
    private float decelerationTime = 2f;
    private float deceleration;




    void Start()
    {
        speed = defaultSpeed;
        acceleration = maxSpeed / accelerationTime;
        deceleration = maxSpeed / decelerationTime;
        PowerUps();

    }

    void Update()
    {
        PlayerMovement();
        PlayerCircle();

        Debug.DrawLine(transform.position, enemyTransform.position, Color.magenta);
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

        Vector3 endingDirection = new Vector3();

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            endingDirection = Vector3.up;
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            endingDirection = Vector3.down;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            endingDirection = Vector3.right;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            endingDirection = Vector3.left;
        }

        if (Input.anyKey == false)
        {
            transform.position += endingDirection * speed * Time.deltaTime;
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

    //Journal 4 Task 1
    void PlayerCircle()
    {
        List<float> degrees = new List<float>();
        float circlePoints = 10;
        float radius = 5;
        List<Vector3> startPoints = new List<Vector3>();
        List<Vector3> endPoints = new List<Vector3>();

        Color lineColor = Color.green;
        degrees.Add(0);

        if (Vector3.Distance(transform.position, enemyTransform.position) <= radius)
        {
            lineColor = Color.red;
        }
        else
        {
            lineColor = Color.green;
        }

        for (int i = 0; i < circlePoints; i++)
        {
            degrees.Add(360 / circlePoints * (i+1));
            startPoints.Add(Vector3.zero);
            endPoints.Add(Vector3.zero);

            //calculate start and end points
            startPoints[i] = (new Vector3(Mathf.Cos(degrees[i] * Mathf.Deg2Rad), Mathf.Sin(degrees[i] * Mathf.Deg2Rad)) * radius + transform.position);
            endPoints[i] = (new Vector3(Mathf.Cos(degrees[i+1] * Mathf.Deg2Rad), Mathf.Sin(degrees[i+1] * Mathf.Deg2Rad)) * radius + transform.position);
            Debug.DrawLine(startPoints[i], endPoints[i], lineColor);
        }
    }

    void PowerUps()
    {
        List<float> degrees = new List<float>();
        float numberOfPowerUps = 5;
        float radius = 5;
        List<Vector3> powerPoints = new List<Vector3>();

        Color lineColor = Color.green;

        for (int i = 0; i <= numberOfPowerUps; i++)
        {
            degrees.Add(360 / numberOfPowerUps * (i));
            powerPoints.Add(Vector3.zero);

            //calculate start and end points
            powerPoints[i] = (new Vector3(Mathf.Cos(degrees[i] * Mathf.Deg2Rad), Mathf.Sin(degrees[i] * Mathf.Deg2Rad)) * radius + transform.position);
            Instantiate(powerUpPrefab, powerPoints[i], Quaternion.identity);
        }
    }

}
