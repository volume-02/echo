using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int hitPoints;
    public int damage = 1;
    public bool destroyable = true;
    Collider collider;
    ObjectMoverScript mover;
    public Boss target;
    bool fighting = true;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
        mover = GetComponent<ObjectMoverScript>();
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
                    mover.travelPoints = new List<Transform>(new[] { target.transform });
                    mover.currIndex = 0;
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
