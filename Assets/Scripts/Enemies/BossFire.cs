using Ghostery.Damage;
using Ghostery.Locomotion;
using UnityEngine;

namespace Ghostery.Enemies
{
    [RequireComponent(typeof(Damagable))]
    public class BossFire : MonoBehaviour
    {
        Damagable damagable;
        TrajectoryLocomotion trajectoryLocomotion;
        TargetLocomotion targetLocomotion;
        new Collider collider;
        bool active = true;
        public GameObject target;
        BossController controller;
        void Start()
        {
            damagable = GetComponent<Damagable>();
            trajectoryLocomotion = GetComponent<TrajectoryLocomotion>();
            targetLocomotion = GetComponent<TargetLocomotion>();
            collider = GetComponent<Collider>();
            controller = GetComponentInParent<BossController>();
        }

        void FixedUpdate()
        {
            if (active)
            {
                if (damagable?.health <= 0)
                {
                    Disactivate();
                }
            }
            else
            {
                if (targetLocomotion.isReached)
                {
                    Release();
                }
            }
        }

        void Disactivate()
        {
            active = false;
            targetLocomotion.target = target.transform;
            trajectoryLocomotion.enabled = false;
            collider.enabled = false;
        }

        void Release()
        {
            controller.fires.Add(gameObject);
            Destroy(this);
        }
    }
}
