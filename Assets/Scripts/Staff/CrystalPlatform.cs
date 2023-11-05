using Ghostery.Locomotion;
using System.Collections.Generic;
using UnityEngine;

namespace Ghostery.Staff
{
    public class CrystalPlatform : MonoBehaviour
    {
        TargetLocomotion locomotion;
        public List<Renderer> crystals;
        public float maxIntensivity = 1;

        void Start()
        {
            locomotion = GetComponent<TargetLocomotion>();
        }

        void Update()
        {
            foreach (var crystal in crystals)
            {
                crystal.material.SetColor("_EmissionColor", crystal.material.GetColor("_Color") * (locomotion?.intensivity ?? 0 * maxIntensivity));
            }
        }
    }
}
