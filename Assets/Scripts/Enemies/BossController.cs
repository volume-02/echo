using System.Collections.Generic;
using UnityEngine;

namespace Ghostery.Enemies
{
    public class BossController : MonoBehaviour
    {
        public List<GameObject> fires { get; set; } = new List<GameObject>();
        public GameObject body;

        void Update()
        {
            if (fires.Count == 4)
            {
                foreach (var fire in fires)
                {
                    Destroy(fire);
                }
                body.SetActive(true);
            }
        }
    }
}
