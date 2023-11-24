using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightLocomotion : MonoBehaviour
{
    [SerializeField] GameObject player;
    Vector3 offset = new Vector3(0, 4, -6.5f);
    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
