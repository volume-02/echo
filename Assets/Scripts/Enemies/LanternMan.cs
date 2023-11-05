using Ghostery.Damage;
using Ghostery.Locomotion;
using System.Collections.Generic;
using UnityEngine;

namespace Ghostery.Enemies
{
    [RequireComponent(typeof(Damagable))]
    public class LanternMan : MonoBehaviour
    {
        public GameObject enemyMesh;
        Renderer bodyRenderer;
        public Animator animator;
        Damagable damagable;
        GuardLocomotion guardLocomotion;
        TargetLocomotion targetLocomotion;

        List<Material> materials;

        public Material headMaterial;
        public Material heartMaterial;
        public Material angryMaterial;
        public Light lantern;
        public Color lanternColor;
        public Color lanternAngryColor;

        void Start()
        {
            guardLocomotion = GetComponent<GuardLocomotion>();
            targetLocomotion = GetComponent<TargetLocomotion>();
            damagable = GetComponent<Damagable>();
            bodyRenderer = enemyMesh.GetComponent<Renderer>();
            materials = new List<Material>(bodyRenderer.materials);
        }

        void FixedUpdate()
        {
            if (damagable?.health <= 0)
            {
                Destroy(gameObject);
            }
            TurnEnemy();
        }
        void Update()
        {
            if (guardLocomotion.isToTarget)
            {
                materials[0] = angryMaterial;
                materials[2] = angryMaterial;
                lantern.color = lanternAngryColor;
            }
            else
            {
                materials[0] = headMaterial;
                materials[2] = heartMaterial;
                lantern.color = lanternColor;
            }
            bodyRenderer.SetMaterials(materials);
            animator.SetBool("isMoving", targetLocomotion.isMoving);
        }

        void TurnEnemy()
        {
            if (targetLocomotion.vectorToTarget.x < 0)
            {
                enemyMesh.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                enemyMesh.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
}
