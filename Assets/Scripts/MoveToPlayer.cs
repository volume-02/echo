using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    public Transform leftBound;
    public Transform rightBound;

    public GameObject player;
    public GameObject enemyMesh;
    public Renderer bodyRenderer;
    Animator animator;

    Vector3 startPosition;
    bool isMoving = false;
    public bool isStalking = false;

    float speed = 5;
    // Start is called before the first frame update

    public Material headMaterial;
    public Material heartMaterial;
    public Material angryMaterial;
    public Light lantern;
    public Color lanternColor;
    public Color lanternAngryColor;

    List<Material> materials;
    void Start()
    {
        startPosition = transform.position;
        player = GameObject.FindWithTag("Player");
        animator = enemyMesh.GetComponent<Animator>();
        materials = new List<Material>(bodyRenderer.materials);
    }

    // Update is called once per frame
    void Update()
    {
        var d = GetDirection();
        TurnEnemy(d);
        MoveEnemy(d);
        if (isStalking)
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
    }

    void MoveEnemy(Vector3 direction)
    {
        transform.Translate(new Vector3(direction.x, 0, 0) * speed * Time.deltaTime, Space.World);
        animator.SetBool("isMoving", isMoving);
    }

    Vector3 GetDirection()
    {
        Vector3 direction = Vector3.zero;
        isStalking = false;
        isMoving = Mathf.Abs((startPosition - transform.position).x) > 0.1;
        var playerPos = player.transform.position;

        if (playerPos.x > leftBound.position.x && playerPos.x < rightBound.position.x)
        {
            isStalking = true;
            direction = (playerPos - transform.position).normalized;
        }
        else if (isMoving)
        {
            direction = (startPosition - transform.position).normalized;
        }
        
        return direction;
    }

    void TurnEnemy(Vector3 direction)
    {
        if (direction.x < 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
