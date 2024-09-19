using Codice.CM.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance = 3;
    public float maxFloatDistance = 20;
    private float distance;

    private Vector3 pointRandom = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        pointRandom = new Vector3(Random.Range(-10, maxFloatDistance), Random.Range(-10, maxFloatDistance));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += pointRandom.normalized * 5f * Time.deltaTime;
        distance = Vector3.Distance(transform.position, pointRandom);
        Debug.DrawLine(transform.position, pointRandom, color: Color.red);

        if (distance <= arrivalDistance)
        {
             print("caught");
;            pointRandom = new Vector3(Random.Range(0, maxFloatDistance), Random.Range(0, maxFloatDistance));
        }
    }
}
