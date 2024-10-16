using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * 8f * Time.deltaTime; 
        if(transform.position.y > 40 || transform.position.y < -40 || transform.position.x > 65 || transform.position.x < -65)
        {
            GameObject.Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject.Destroy(gameObject);
    }

}
