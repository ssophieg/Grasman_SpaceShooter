using UnityEngine;
using System.Collections;
using Codice.CM.Common;
using System;

public class Enemy : MonoBehaviour
{
    private Boolean up = true;
    private void Update()
    {
        EnemyMovement();
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

}
