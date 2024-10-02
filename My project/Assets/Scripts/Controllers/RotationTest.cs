using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour
{
    public float AngularSpeed = 50f;
    public float TargetAngle = 170;
    public Transform targetTransform;

    public float angle1;
    public float angle2;
    public float angle3;
    // Start is called before the first frame update
    void Start()
    {
        angle1 = Mathf.Atan2(transform.position.y, transform.position.x);
        angle2 = Mathf.Atan2(targetTransform.position.y, targetTransform.position.x);

        angle3 = angle1 - angle2;

        angle3 = angle3 % 360;
        angle3 = (angle3 + 360) % 360;
        if (angle3 > 180)
        {
            angle3 -= 360;
        }

        angle3 *= Mathf.Rad2Deg;
        print(angle3);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, new Vector3(transform.position.x, 10), Color.cyan);
        transform.Rotate(0, 0, AngularSpeed * Time.deltaTime);

        Debug.DrawLine(transform.position, targetTransform.position, Color.blue);

        if (transform.eulerAngles.z > angle3)
        {
            AngularSpeed = 0;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, angle3);
        }


    }
}
