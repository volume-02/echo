using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class CameraScript : MonoBehaviour
//{
//    public GameObject player;

//    float offsetX = 10;
//    float offsetY = 0;
//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        calcCameraPosition();
//    }

//    void calcCameraPosition()
//    {
//        var diff = player.transform.position - transform.position;

//        if (diff.x >= offsetX)
//        {
//            transform.position = new Vector3(player.transform.position.x - offsetX, 3.2f, -9.8f);
//        }

//        if (diff.x <= -offsetX)
//        {
//            transform.position = new Vector3(player.transform.position.x + offsetX, 3.2f, -9.8f);
//        }

//        if (diff.y >= offsetY)
//        {
//            transform.position = new Vector3(transform.position.x, player.transform.position.y - offsetY, -9.8f);
//        }

//        if (diff.y <= -offsetY)
//        {
//            transform.position = new Vector3(transform.position.x, player.transform.position.y + offsetY, -9.8f);
//        }
//    }
//}


public class CameraScript : MonoBehaviour
{
    public GameObject player;

    float offsetX = 10;
    float offsetY = 0;
    public GameObject background;
    // Start is called before the first frame update
    void Start()
    {
        offsetX = transform.position.x - player.transform.position.x;
        offsetY = transform.position.y - player.transform.position.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        calcCameraPosition();
    }

    void calcCameraPosition()
    {
        var diff = player.transform.position - transform.position;

        var posX = player.transform.position.x + (diff.x >= offsetX ? -offsetX : offsetX);
        var posY = player.transform.position.y + (diff.y >= offsetY ? -offsetY : offsetY);

        var transX = posX - transform.position.x;
        var transY = posY - transform.position.y;

        transform.Translate(transX, transY, 0);
        background.transform.Translate(-transX/2, 0, 0);
    }
}