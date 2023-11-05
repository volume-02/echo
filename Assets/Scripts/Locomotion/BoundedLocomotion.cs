using UnityEngine;

namespace Ghostery.Locomotion
{
    [RequireComponent(typeof(TargetLocomotion))]
    public class BoundedLocomotion : MonoBehaviour
    {
        public Transform leftBound;
        public Transform rightBound;

        public TargetLocomotion targetLocomotion { get; set; }

        void Start()
        {
            targetLocomotion = GetComponent<TargetLocomotion>();
        }

        void FixedUpdate()
        {
            if((targetLocomotion.vectorToTarget.x < 0 && transform.position.x >= leftBound.position.x) || (targetLocomotion.vectorToTarget.x > 0 && transform.position.x <= rightBound.position.x))
            {
                targetLocomotion.isMoving = true;
            }
            else
            {
                targetLocomotion.isMoving = false;
            }
        }
    }
}
