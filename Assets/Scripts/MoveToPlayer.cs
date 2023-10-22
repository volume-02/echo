using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    public Transform leftBound;
    public Transform rightBound;

    public GameObject player;

    Vector3 startPosition;

    float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var playerPos = player.transform.position;
        if (playerPos.x > leftBound.position.x && playerPos.x < rightBound.position.x)
        {
            var direction = (playerPos - transform.position).normalized;

            transform.Translate(new Vector3(direction.x , 0, 0) * speed * Time.deltaTime);
        } else
        {
            var direction =  (startPosition - transform.position).normalized;
            transform.Translate(new Vector3(direction.x, 0, 0) * speed * Time.deltaTime);
        }

    }
}
