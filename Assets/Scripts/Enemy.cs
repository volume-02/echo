using Ghostery.Locomotion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int hitPoints;
    public int damage = 1;
    public bool destroyable = true;
    Collider collider;
    TrajectoryLocomotion mover;
    public Boss target;
    bool fighting = true;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
        mover = GetComponent<TrajectoryLocomotion>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fighting)
        {
            if (hitPoints <= 0)
            {
                collider.enabled = false;
                fighting = false;
                if (destroyable)
                {
                    Destroy(gameObject);
                }
                else
                {
                    mover.trajcetoryPoints = new List<Transform>(new[] { target.transform });
                }
            }
        }
        else
        {
            var vectorToNextPoint = target.transform.position - transform.position;
            if (vectorToNextPoint.magnitude < 0.1f)
            {
                mover.enabled = false;
                target.fires.Add(gameObject);
                Destroy(this);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            hitPoints--;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerScript>().TakeDamage(damage);
        }
    }
}
