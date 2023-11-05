using System.Collections.Generic;
using UnityEngine;

namespace Ghostery.Locomotion
{
    [RequireComponent(typeof(TargetLocomotion))]
    public class TrajectoryLocomotion : MonoBehaviour
    {
        public TargetLocomotion targetLocomotion { get; set; }
        public List<Transform> trajcetoryPoints;
        public float pauseTime = 1;

        int currentIndex = 0;
        public Transform currentPoint
        {
            get
            {
                if (trajcetoryPoints.Count == 0)
                {
                    return null;
                }
                if (currentIndex >= trajcetoryPoints.Count)
                {
                    currentIndex = 0;
                }
                return trajcetoryPoints[currentIndex];
            }
        }


        void Start()
        {
            targetLocomotion = GetComponent<TargetLocomotion>();
            targetLocomotion.target = currentPoint;
        }


        public void Next()
        {
            currentIndex++;
            targetLocomotion.target = currentPoint;
        }


        public void Pause()
        {
            if (pauseTime > 0)
            {
                targetLocomotion.isMoving = false;
                Invoke("ContinueMoving", pauseTime);
            }
        }

        void ContinueMoving()
        {
            targetLocomotion.isMoving = true;
        }
        void FixedUpdate()
        {
            if (targetLocomotion.isReached)
            {
                Next();
                Pause();
            }
        }
    }
}
