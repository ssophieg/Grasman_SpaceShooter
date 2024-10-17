using Codice.Client.BaseCommands;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    //2nd Mechanic
    private float powerUpFront;
    private float powerUpRandom;

    //3rd Mechanic
    private bool poweredUp = false;
    private bool red = false;

    private Color lineColor = Color.green;
    private Color powerColor = Color.green;

    private float redTime = 0;

    //Bonus Mechanic
    public Text enemyHealth;
    public Text playerHealth;

    private float enemyHP = 5;
    private float playerHP = 5;

    void Start()
    {
        speed = defaultSpeed;
        acceleration = maxSpeed / accelerationTime;
        deceleration = maxSpeed / decelerationTime;
        //PowerUps();

    }

    void Update()
    {
        PlayerMovement();
        PlayerCircle();

        //Debug.DrawLine(transform.position, enemyTransform.position, Color.magenta);

        powerUpFront += Time.deltaTime;
        powerUpRandom += Time.deltaTime;

        spawnPowerUps();

        if (enemyHP <= 0)
        {
            enemyHealth.text = "YEAHH YOU WIN RAAAA";
        }
        else if (playerHP <= 0)
        {
            playerHealth.text = "dieded :(";
            enemyHealth.text = "L bozo loser L";
        }
        else
        {
            enemyHealth.text = enemyHP.ToString();
            playerHealth.text = playerHP.ToString();
        }
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
        degrees.Add(0);

        if (Vector3.Distance(transform.position, enemyTransform.position) <= radius && poweredUp == true && red == true)
        {

            //disable power up color

            powerColor = Color.green;
            poweredUp = false;
            enemyHP -= 1;
        }
        if(Vector3.Distance(transform.position, enemyTransform.position) <= radius && red == true)
        {
            lineColor = Color.red;

            redTime = redTime + Time.deltaTime;
            if (redTime >= 0.5)
            {
                red = false;
                redTime = 0;
            }
        }
        else
        {
            lineColor = powerColor;
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

    //2nd Mechanic
    void spawnPowerUps()
    {
        Vector3 powerUpPos = new Vector3();
        if (powerUpFront >= 20)
        {
            GameObject.Instantiate(powerUpPrefab, transform.position + Vector3.up * 5, Quaternion.identity);
            powerUpFront = 0;
        }

        if (powerUpRandom >= 15)
        {
            powerUpPos = new Vector3(UnityEngine.Random.Range(-18.0f, 40.0f), UnityEngine.Random.Range(-12.0f, 12.0f), 0f);
            GameObject.Instantiate(powerUpPrefab, powerUpPos, Quaternion.identity);
            powerUpRandom = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Power Up")
        {
            Debug.Log("powered up!!");
            GameObject.Destroy(collision.gameObject);
            powerColor = Color.yellow;
            poweredUp = true;
            red = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bomb")
        {
            playerHP -= 1;
        }
    }

}
