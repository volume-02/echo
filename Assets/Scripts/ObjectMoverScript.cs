using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class ObjectMoverScript : MonoBehaviour
{

    public List<Transform> travelPoints;
    public float speed = 10;
    public float minSpeed = 3;
    float currentSpeed = 10;
    public float pauseTime = 1;
    public bool withPause = false;
    public float slowDownDistance = 1;

    int currIndex = 0;

    bool isMoving = true;

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMoving)
        {
            var vectorToNextPoint = travelPoints[currIndex].position - transform.position;
            if (slowDownDistance > 0 && slowDownDistance >= vectorToNextPoint.magnitude)
            {
                currentSpeed = vectorToNextPoint.magnitude / slowDownDistance < minSpeed ? minSpeed : vectorToNextPoint.magnitude / slowDownDistance;
            }
            transform.Translate(vectorToNextPoint.normalized * Time.deltaTime * currentSpeed);
            if (vectorToNextPoint.magnitude < 0.1f)
            {
                currIndex = (currIndex + 1) % travelPoints.Count;
                if (withPause)
                {
                    isMoving = false;
                    Invoke("ContinueMoving", pauseTime);
                }
                else
                {
                    currentSpeed = speed;
                }
            }
        }
    }

    void ContinueMoving()
    {
        isMoving = true;
        currentSpeed = speed;
    }
}
