using System.Data;
using UnityEngine;

namespace Ghostery.Damage
{
    public class Damagable : MonoBehaviour
    {
        public int health = 3;
        public string damagerTag = "Damage";

        private void OnTriggerEnter(Collider other)
        {
            var damager = other.gameObject.GetComponent<Damager>();
            if (damager != null && damager.tag == damagerTag)
            {
                health -= damager.damage;
            }

        }
    }
}
