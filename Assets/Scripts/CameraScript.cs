using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;

    float offsetX = 10;
    float offsetY = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        calcCameraPosition();
    }

    void calcCameraPosition()
    {
        var diff = player.transform.position - transform.position;

        if (diff.x >= offsetX)
        {
            transform.position = new Vector3(player.transform.position.x - offsetX, 3.5f, -24);
        }

        if (diff.x <= -offsetX)
        {
            transform.position = new Vector3(player.transform.position.x + offsetX, 3.5f, -24);
        }

        if (diff.y >= offsetY)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y - offsetY, -24);
        }

        if (diff.y <= -offsetY)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y + offsetY, -24);
        }
    }
}
