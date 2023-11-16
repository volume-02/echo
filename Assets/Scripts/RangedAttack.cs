using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public ParticleSystem swooshParticles;

    public void Swoosh()
    {
        var emitParams = new ParticleSystem.EmitParams();
        swooshParticles.Emit(emitParams, 1000);
    }
}
