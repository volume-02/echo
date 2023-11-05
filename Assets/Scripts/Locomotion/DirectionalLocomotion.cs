using UnityEngine;

namespace Ghostery.Locomotion
{
    public class DirectionalLocomotion : MonoBehaviour
    {
        public float speed = 5;
        public bool isMoving = true;

        void FixedUpdate()
        {
            if (isMoving)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }
    }
}