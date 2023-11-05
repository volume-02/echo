using UnityEngine;

namespace Ghostery.Locomotion
{
    [RequireComponent(typeof(TargetLocomotion))]
    public class GuardLocomotion : MonoBehaviour
    {
        public Transform leftBound;
        public Transform rightBound;
        public Transform target;
        public Transform startPosition;

        public TargetLocomotion targetLocomotion { get; set; }
        public bool isToTarget
        {
            get
            {
                return target == targetLocomotion.target;
            }
        }

        void Start()
        {
            targetLocomotion = GetComponent<TargetLocomotion>();
        }

        void FixedUpdate()
        {
            if (target.position.x > leftBound.position.x && target.position.x < rightBound.position.x)
            {
                targetLocomotion.target = target.transform;
            }
            else
            {
                targetLocomotion.target = startPosition.transform;
            }
            if (targetLocomotion.isReached)
            {
                targetLocomotion.isMoving = false;
            }
            else
            {
                targetLocomotion.isMoving = true;
            }
        }
    }
}
