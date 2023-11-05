using Ghostery.Locomotion;
using System.Collections;
using UnityEngine;

namespace Ghostery.Enemies
{
    public class LanternBoss : MonoBehaviour
    {
        TargetLocomotion locomotion;
        public GameObject player;
        public GameObject fire;
        public float fireDistance = 5;
        public float cooldownTime = 5;
        void Start()
        {
            locomotion = GetComponent<TargetLocomotion>();
            StartCoroutine(Spawn());
        }
        void FixedUpdate()
        {
            TurnEnemy();
        }

        void TurnEnemy()
        {
            if (locomotion.vectorToTarget.x < 0)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }

        IEnumerator Spawn()
        {
            while (true)
            {
                if ((player.transform.position - transform.position).magnitude <= fireDistance)
                {
                    var inst = Instantiate(fire);
                    inst.transform.position = transform.position;
                    inst.transform.LookAt(player.transform);
                }
                yield return new WaitForSeconds(cooldownTime);
            }
        }
    }
}
