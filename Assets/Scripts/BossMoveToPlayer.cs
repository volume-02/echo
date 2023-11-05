using Ghostery.Locomotion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMoveToPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject fire;
    public TargetLocomotion locomotion;
    //Animator animator;

    float cooldown = 5;
    public float distance = 5;
    // Start is called before the first frame update


    void Start()
    {
        player = GameObject.FindWithTag("Player");
        locomotion = GetComponent<TargetLocomotion>();
        //animator = enemyMesh.GetComponent<Animator>();
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        TurnEnemy();
    }

    void TurnEnemy()
    {
        if (locomotion.vectorToTarget.x < 0)
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
