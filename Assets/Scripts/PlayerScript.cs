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
    int score = 0;
    int jumpCount = 0;
    bool isRotating = false;
    public Vector3 savePos;
    public Animator playerAnimator;
    public Animator coatAnimator;

    Vector3 direction = Vector3.right;

    GameManagerScript gameManager;

    public TextMeshProUGUI hpText;
    public TextMeshProUGUI scoreText;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        hpText.text = $"HP: {hitPoints}";
        scoreText.text = $"Score: {score}";
        gameManager = FindObjectOfType<GameManagerScript>().GetComponent<GameManagerScript>();
    }

    private void Update()
    {

    }
    void FixedUpdate()
    {
        if (!gameManager.isGameOver) { transform.Translate(Vector3.right * playerSpeed * Time.deltaTime * movement.x, Space.World); }

    }

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();



        if (movement.x != 0)
        {
            direction = new Vector3(movement.x, 0, 0);
            playerAnimator.SetBool("isRunning", true);
            coatAnimator.SetBool("isRunning", true);
        }
        else
        {
            playerAnimator.SetBool("isRunning", false);
            coatAnimator.SetBool("isRunning", false);
        }

        if (direction == Vector3.right)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if ((isOnGround || jumpCount < 2) && !gameManager.isGameOver)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

                playerAnimator.SetTrigger("jump");
                coatAnimator.SetTrigger("jump");
                jumpCount++;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            jumpCount = 0;
            gameObject.transform.parent = collision.transform;
            playerAnimator.SetBool("isFalling", false);
            coatAnimator.SetBool("isFalling", false);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;
            gameObject.transform.parent = null;
            playerAnimator.SetBool("isFalling", true);
            coatAnimator.SetBool("isFalling", true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            score++;
            scoreText.text = $"Score: {score}";
            Destroy(other.gameObject);
        }


        if (other.gameObject.CompareTag("Save"))
        {
            savePos = other.transform.position;
        }
    }
    public void Heal()
    {
        hitPoints = 3;
        hpText.text = $"HP: {hitPoints}";
        playerRb.isKinematic = false;
    }

    public void TakeDamage(int damage)
    {
        hitPoints -= damage;
        hpText.text = $"HP: {hitPoints}";
        if (hitPoints <= 0)
        {
            AcceptDeath();
        }
    }

    void AcceptDeath()
    {
        gameManager.GameOver();
        playerRb.isKinematic = true;
    }

    public void Attack()
    {
        StartCoroutine(SwingWeapon());
        playerAnimator.SetTrigger("attack");
        coatAnimator.SetTrigger("attack");
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
                weapon.transform.RotateAround(transform.position, new Vector3(0, 0, 1), -degreesByStep * direction.x);
            }
            else
            {
                weapon.transform.RotateAround(transform.position, new Vector3(0, 0, 1), degreesByStep * direction.x);
            }
            counter++;

            yield return new WaitForSeconds(0.001f);
        }


        isRotating = false;
    }
}
