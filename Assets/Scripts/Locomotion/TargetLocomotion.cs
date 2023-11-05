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
        public bool X = true;
        public bool Y = true;
        public bool Z = true;

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
                return isReached ? 0 : minSpeed + (speed - minSpeed) * aspect;
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
                transform.Translate(new Vector3(X ? vectorToTarget.x : 0, Y ? vectorToTarget.y : 0, Z ? vectorToTarget.z : 0).normalized * currentSpeed * Time.deltaTime);
            }
        }
    }
}
