
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseTrigExercize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Cos(45): " + Mathf.Cos(45 * Mathf.Deg2Rad));
        Debug.Log("Cos(-45): " + Mathf.Cos(-45 * Mathf.Deg2Rad));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
