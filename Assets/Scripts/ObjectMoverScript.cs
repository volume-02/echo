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
    void Update()
    {
        transform.Translate((travelPoints[currIndex].position - transform.position).normalized * Time.deltaTime * speed);
        if ((transform.position - travelPoints[currIndex].position).magnitude < 0.1f)
        {
            currIndex = (currIndex + 1) % travelPoints.Count;
        }
        
    }
}
