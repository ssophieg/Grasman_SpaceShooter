using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{

    public float degree = 0;
    public Transform moonTransform;

    public float radius = 3;
    public float orbitalSpeed = 70f;

    Vector3 moonPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        degree += 0.5f * orbitalSpeed * Time.deltaTime;
        moonPos = new Vector3(Mathf.Cos(degree * Mathf.Deg2Rad), Mathf.Sin(degree * Mathf.Deg2Rad)) * radius + transform.position;
        moonTransform.position = moonPos;
    }
}
