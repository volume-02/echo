using Ghostery.Locomotion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    public GameObject enemyMesh;
    public Renderer bodyRenderer;
    Animator animator;

    public Material headMaterial;
    public Material heartMaterial;
    public Material angryMaterial;
    public Light lantern;
    public Color lanternColor;
    public Color lanternAngryColor;
    public TargetLocomotion targetLocomotion;
    public GuardLocomotion guardLocomotion;

    List<Material> materials;
    void Start()
    {
        animator = enemyMesh.GetComponent<Animator>();
        targetLocomotion = GetComponent<TargetLocomotion>();
        guardLocomotion = GetComponent<GuardLocomotion>();
        materials = new List<Material>(bodyRenderer.materials);
    }

    // Update is called once per frame
    void Update()
    {
        TurnEnemy(); 
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
