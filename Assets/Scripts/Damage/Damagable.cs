using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Events;

namespace Ghostery.Damage
{
    public class Damagable : MonoBehaviour
    {
        public int health = 3;
        public string damagerTag = "Damage";
        [SerializeField] new Renderer renderer;
        [SerializeField] Material whiteMaterial;
        List<Color> colorList = new List<Color>();

        Material[] materials;

        public UnityEvent onDamage;


        private void Start()
        {
            materials = renderer.materials;

            foreach (var material in materials)
            {
                material.EnableKeyword("_EMISSION");
                colorList.Add(material.GetColor("_EmissionColor"));
            }
        }
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
            foreach (var material in materials)
            {
                material.EnableKeyword("_EMISSION");
                material.SetColor("_EmissionColor", Color.white);
            }

            StartCoroutine(ReturnColors());

            health -= damage;
            if (health < 0)
            {
                health = 0;
            }
            onDamage?.Invoke();
        }
        IEnumerator ReturnColors()
        {
            yield return new WaitForSeconds(0.3f);
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i].EnableKeyword("_EMISSION");

                materials[i].SetColor("_EmissionColor", colorList[i]);
            }
        }
    }
}
