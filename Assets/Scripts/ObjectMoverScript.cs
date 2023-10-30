using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class ObjectMoverScript : MonoBehaviour
{

    public List<Transform> travelPoints;
    public float speed = 10;

    int currIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var vectorToNextPoint = travelPoints[currIndex].position - transform.position;
        transform.Translate(vectorToNextPoint.normalized * Time.deltaTime * speed);

        if (vectorToNextPoint.magnitude < 0.1f)
        {
            currIndex = (currIndex + 1) % travelPoints.Count;
        }
        
    }
}
