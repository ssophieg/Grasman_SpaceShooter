using UnityEngine;
using System.Collections;
using Codice.CM.Common;
using System;

public class Enemy : MonoBehaviour
{
    public GameObject bomb;
    private Boolean up = true;

    //Mechanic 1

    float spawnTime = 0f;
    float bombRotation = 0f;
    float bombAmount = 0;
    float division = 30;
    private void Update()
    {
        EnemyMovement();

        spawnTime += 1 * Time.deltaTime;

        if (spawnTime >= 0.05)
        {
            bombRotation = (360 / division * (bombAmount));
            bombAmount += 1;
            GameObject.Instantiate(bomb, transform.position, Quaternion.Euler(0, 0, bombRotation));
            spawnTime = 0;
        }
    }

    void EnemyMovement()
    {

        if(up == false)
        {
            transform.position += Vector3.down * 9f * Time.deltaTime;
        }
        else if(up == true)
        {
            transform.position += Vector3.up * 9f * Time.deltaTime;
        }

        if (transform.position.y > 15f)
        {
            up = false;
            print(up);
        }
        else if (transform.position.y < -3f)
        {
            up = true;
        }
    }

    void BombSpawn()
    {
        float bombRotation = 0f;
        for(int i = 0; i < 10; i++) 
        {
            bombRotation = (360 / 10 * (i + 1));

            GameObject.Instantiate(bomb, transform.position, Quaternion.Euler(0, 0, bombRotation));
        }
    }

}
