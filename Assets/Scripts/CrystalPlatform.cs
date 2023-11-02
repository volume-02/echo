using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalPlatform : MonoBehaviour
{
    ObjectMoverScript platformMove;
    public List<Renderer> crystals;
    public float maxIntensivity = 1;
    // Start is called before the first frame update
    void Start()
    {
        platformMove = GetComponent<ObjectMoverScript>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var crystal in crystals)
        {
            crystal.material.SetColor("_EmissionColor", crystal.material.GetColor("_Color") * (platformMove.intensivity * maxIntensivity));
        }
    }
}
