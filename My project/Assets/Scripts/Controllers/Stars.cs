using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;
    public LineRenderer line;

    public List<Vector3> lineEnds;

    public Vector3 beginning;
    public Vector3 end;
    
    private Vector3 drawDirection = new Vector3();
    private Vector3 lineEnd = new Vector3();

    public int cycle = 0;
    public int add = 1;

    // Update is called once per frame

    private void Start()
    {
        lineEnd = starTransforms[0].position;
        lineEnds.Add(lineEnd);
    }
    void Update()
    {

        drawDirection = starTransforms[cycle+add].position - starTransforms[cycle].position;
        lineEnds[cycle] += drawDirection.normalized * 5f * Time.deltaTime;
        Debug.DrawLine(starTransforms[cycle].position, lineEnds[cycle], color: Color.blue);

        if (Vector3.Distance(starTransforms[cycle+add].position, lineEnds[cycle]) < 0.1)
        {
            lineEnds[cycle] = starTransforms[cycle+add].position;
            lineEnds.Add(starTransforms[cycle+add].position);
            Debug.DrawLine(starTransforms[cycle].position, starTransforms[cycle +1].position);

            cycle += 1;
            if (cycle == starTransforms.Count - 2)
            {
                cycle = 0;
            }
           
        }
    }
}
