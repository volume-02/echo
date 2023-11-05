using UnityEngine;

namespace Ghostery.Staff
{
    public class Checkpoint : MonoBehaviour
    {
        Light point;
        void Start()
        {
            point = GetComponentInChildren<Light>();
        }
        public void Check()
        {
            point.enabled = true;
        }
    }
}
