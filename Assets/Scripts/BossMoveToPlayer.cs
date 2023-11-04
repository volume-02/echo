using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMoveToPlayer : MonoBehaviour
{
    public Transform leftBound;
    public Transform rightBound;

    public GameObject player;
    public GameObject fire;
    //Animator animator;

    Vector3 startPosition;
    bool isMoving = false;

    float speed = 5;
    float cooldown = 5;
    public float distance = 5;
    // Start is called before the first frame update


    void Start()
    {
        startPosition = transform.position;
        player = GameObject.FindWithTag("Player");
        //animator = enemyMesh.GetComponent<Animator>();
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        var d = GetDirection();
        TurnEnemy(d);
        MoveEnemy(d);
    }

    void MoveEnemy(Vector3 direction)
    {
        transform.Translate(new Vector3(direction.x, 0, 0) * speed * Time.deltaTime, Space.World);
        //animator.SetBool("isMoving", isMoving);
    }

    Vector3 GetDirection()
    {
        Vector3 direction = Vector3.zero;

        if (transform.position.x > leftBound.position.x && transform.position.x < rightBound.position.x)
        {
            direction = (player.transform.position - transform.position).normalized;
        }
        
        return direction;
    }

    void TurnEnemy(Vector3 direction)
    {
        if (direction.x < 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    IEnumerator Spawn()
    {
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            if((player.transform.position - transform.position).magnitude <= distance)
            {
                var inst = Instantiate(fire);
                inst.transform.position = transform.position;
                inst.transform.LookAt(player.transform);
            }
            yield return new WaitForSeconds(cooldown);
        }
    }
}
