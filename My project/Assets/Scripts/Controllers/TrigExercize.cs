using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigExercize : MonoBehaviour
{
    public List<float> angles = new List<float>() { 0f, 45f, 90f, 135f, 180f, 270f, 360f };

    //adjust these in inspector
    public float radius;
    public Vector3 offset;
    public float updateFrequency;

    private int currentAngleIndex = 0;
    private float timeSinceLastUpdate = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float currentAngle = angles[currentAngleIndex];
        Vector3 startingPoint = Vector3.zero + offset;
        //We convert currentAngle to radians in order to be able to use Cos and Sin in Unity
        float endPointX = Mathf.Cos(currentAngle * Mathf.Deg2Rad);
        float endPointY = Mathf.Sin(currentAngle * Mathf.Deg2Rad);
        Vector3 endingPoint = (new Vector3(endPointX, endPointY)) * radius + offset;
        Debug.DrawLine(startingPoint, endingPoint, Color.red);

        timeSinceLastUpdate += Time.deltaTime;

        if (timeSinceLastUpdate > updateFrequency)
        {
            timeSinceLastUpdate = 0f;
            currentAngleIndex++;

            //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators
            //This allows us to divide currentAngleIndex by the number of angles and store the remainder
            //currentAngleIndex = currentAngleIndex % angles.Count;
            if (currentAngleIndex >= angles.Count)
            {
                currentAngleIndex = 0;
            }
        }
    }










}
