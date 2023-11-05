using UnityEngine;

namespace Ghostery.Locomotion
{
    public class TargetLocomotion : MonoBehaviour
    {
        public float minSpeed = 3;
        public float speed = 10;
        public bool isMoving = true;
        public float slowDownDistance = 1;
        public Transform target;

        public Vector3 vectorToTarget
        {
            get
            {
                return target.position - transform.position;
            }
        }
        public bool isSlowDown
        {
            get
            {
                return slowDownDistance > 0 && slowDownDistance >= vectorToTarget.magnitude;
            }
        }
        public bool isReached
        {
            get
            {
                return vectorToTarget.magnitude <= 0.1;
            }
        }
        public float aspect
        {
            get
            {
                return (slowDownDistance > 0 && isSlowDown) ? vectorToTarget.magnitude / slowDownDistance : 1;
            }
        }
        public float currentSpeed
        {
            get
            {
                return minSpeed + (speed - minSpeed) * aspect;
            }
        }
        public float intensivity
        {
            get
            {
                return currentSpeed / speed;
            }
        }

        public void FixedUpdate()
        {
            if (isMoving && target != null)
            {
                transform.Translate(vectorToTarget.normalized * currentSpeed * Time.deltaTime);
            }
        }
    }
}
