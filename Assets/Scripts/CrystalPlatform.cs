using Ghostery.Locomotion;
using System.Collections.Generic;
using UnityEngine;

public class CrystalPlatform : MonoBehaviour
{
    TargetLocomotion platformMove;
    public List<Renderer> crystals;
    public float maxIntensivity = 1;
    // Start is called before the first frame update
    void Start()
    {
        platformMove = GetComponent<TargetLocomotion>();
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
