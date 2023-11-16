using UnityEngine;

namespace Ghostery.Staff
{
    public class Checkpoint : MonoBehaviour
    {
        Light point;
        AudioSource audioSource;
        void Start()
        {
            point = GetComponentInChildren<Light>();
            audioSource = GetComponentInChildren<AudioSource>();
        }
        public void Check()
        {
            if (!point.enabled)
            {
                point.enabled = true;
                audioSource.Play();
            }
        }
    }
}
