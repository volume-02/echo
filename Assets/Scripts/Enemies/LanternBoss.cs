using Ghostery.Damage;
using Ghostery.Locomotion;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Ghostery.Enemies
{
    public class LanternBoss : MonoBehaviour
    {
        Damagable damagable;
        TargetLocomotion locomotion;
        public GameObject player;
        public GameObject fire;
        public float fireDistance = 50;
        public float cooldownTime = 5;
        void Start()
        {
            damagable = GetComponent<Damagable>();
            locomotion = GetComponent<TargetLocomotion>();
            StartCoroutine(Spawn());
        }
        public UnityEvent onDeath;

        void FixedUpdate ()
        {

            if (damagable.health <= 0)
            {
                onDeath.Invoke();
                Destroy(gameObject);
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
