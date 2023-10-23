using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int hitPoints;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hitPoints <= 0)
        {

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            Debug.Log("Accept some damage");
            hitPoints--;
        }

        Debug.Log("Tag: " + other.gameObject.tag);
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player trigger in enemy");
            other.gameObject.GetComponent<PlayerScript>().TakeDamage();
        }
    }
}
