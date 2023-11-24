using System.Data;
using UnityEngine;
using UnityEngine.Events;

namespace Ghostery.Damage
{
    public class Damagable : MonoBehaviour
    {
        public int health = 3;
        public string damagerTag = "Damage";

        public UnityEvent onDamage;

        private void OnTriggerEnter(Collider other)
        {
            var damager = other.gameObject.GetComponent<Damager>();
            if (damager != null && damager.tag == damagerTag)
            {
                health -= damager.damage;
                if (health < 0)
                {
                    health = 0;
                }
                onDamage?.Invoke();
            }

        }

        public void GetRangedDamage(int damage)
        {
            health -= damage;
            if (health < 0)
            {
                health = 0;
            }
            onDamage?.Invoke();
        }
    }
}
