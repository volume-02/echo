using UnityEngine;
using UnityEngine.InputSystem;
using Ghostery.Damage;
using Ghostery.Staff;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine.Events;

namespace Ghostery
{
    public class PlayerScript : MonoBehaviour
    {
        Damagable damagable;
        Vector3 shootDirection = Vector3.right;

        public int health
        {
            set {
                damagable.health = value; }
            get
            {
                return damagable.health;
            }
        }

        public float jumpForce = 10f;
        public float playerSpeed = 10f;

        Rigidbody playerRb;
        public Animator playerAnimator;
        public AudioSource audioSource;
        public AudioClip coinCollectSound;




        public bool isOnGround
        {
            get
            {
                return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
            }
        }
        int jumpCount = 0;
        Vector3 direction = Vector3.zero;

        GameManager gameManager;
        Collider collider;
        float distToGround = 0;
        void Start()
        {
            damagable = GetComponent<Damagable>();
            playerRb = GetComponent<Rigidbody>();
            gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
            collider = GetComponent<Collider>();
            distToGround = collider.bounds.extents.y;
        }

        void FixedUpdate()
        {

        }

        private void Update()
        {
            playerAnimator.SetFloat("verticalSpeed", playerRb.velocity.y);
            playerAnimator.SetBool("isRunning", Mathf.Abs(direction.x) > 0);
            playerAnimator.SetBool("isFalling", !isOnGround);

            transform.Translate(Vector3.right * playerSpeed * Time.deltaTime * direction.x, Space.World);
            if (health <= 0)
            {
                gameManager.GameOver();
            }
        }

        public void Move(InputAction.CallbackContext context)
        {
            var movement = context.ReadValue<Vector2>();
            direction = new Vector3(movement.x, 0, 0);

            if (context.action.phase == InputActionPhase.Started)
            {
                Turn();
            }
        }

        public void Turn()
        {
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
                if ((isOnGround || jumpCount < 1))
                {
                    playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

                    playerAnimator.SetTrigger("jump");
                }

                if (!isOnGround)
                {
                    jumpCount++;
                }
            }
        }


        private void ProjectileAttack()
        {
            RaycastHit hit;
            LayerMask mask = LayerMask.GetMask("Enemy");
            float sphereRadius = 2;
            float maxDistance = 8;

            var hasHit = Physics.SphereCast(transform.position, sphereRadius, transform.right, out hit, maxDistance, mask, QueryTriggerInteraction.UseGlobal);

            if (hasHit)
            {
                hit.transform.gameObject.GetComponent<Damagable>().GetRangedDamage(1);
            }
        }

        public void Attack(InputAction.CallbackContext context)
        {
            if (context.action.phase == InputActionPhase.Started)
            {
                var m_CurrentClipInfo = playerAnimator.GetCurrentAnimatorClipInfo(0);
                if (m_CurrentClipInfo[0].clip.name != "Attack")
                {
                    ProjectileAttack();
                    playerAnimator.SetTrigger("attack");
                }
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                jumpCount = 0;
                gameObject.transform.parent = collision.transform;
            }
        }

        void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                gameObject.transform.parent = null;
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Coin"))
            {
                Heal();
                Destroy(other.gameObject);
                audioSource.PlayOneShot(coinCollectSound, 1);
            }
            else if (other.gameObject.CompareTag("Save"))
            {
                other.GetComponent<Checkpoint>().Check();
                gameManager.StorePoint(transform.position);
            }
        }
        public void Heal(int hp = 1)
        {
            health += hp;
        }
    }
}
