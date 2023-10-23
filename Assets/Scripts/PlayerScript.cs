using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    Rigidbody playerRb;
    public float jumpForce = 10f;
    public float playerSpeed = 10f;
    public GameObject weapon;
    bool isOnGround = true;
    int hitPoints = 3;

    bool isRotating = false;

    GameManagerScript gameManager;

    public TextMeshProUGUI hpText;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        hpText.text = $"HP: {hitPoints}";
        gameManager = FindObjectOfType<GameManagerScript>().GetComponent<GameManagerScript>();
    }

    private void Update()
    {
        Attack();
    }
    void FixedUpdate()
    {
        if (!gameManager.isGameOver) { transform.Translate(Vector3.right * playerSpeed * Time.deltaTime * movement.x); }

    }

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (isOnGround && !gameManager.isGameOver)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            gameObject.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;
            gameObject.transform.parent = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy trigger" + gameObject.tag);
            hitPoints -= 1;
            hpText.text = $"HP: {hitPoints}";
            if (hitPoints <= 0)
            {
                gameManager.GameOver();
            }
        }
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(SwingWeapon());
        }
    }

    //Extremely suspicious, but working, so ok...
    private IEnumerator SwingWeapon()
    {
        if (isRotating) yield break;
        isRotating = true;

        var counter = 0;
        var total = 90;

        var degreesByStep = 90 / (total / 2);

        while (counter < total)
        {
            if (counter < total / 2)
            {
                weapon.transform.RotateAround(transform.position, new Vector3(0, 0, 1), -degreesByStep);
            }
            else
            {
                weapon.transform.RotateAround(transform.position, new Vector3(0, 0, 1), degreesByStep);
            }
            counter++;

            yield return new WaitForSeconds(0.001f);
        }


        isRotating = false;
    }
}
