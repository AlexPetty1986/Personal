using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fleer : Agent
{
    public PhysicsObject seeker;
    Vector3 chaseForce;

    protected override void CalcSteeringForces()
    {

        chaseForce = Flee(seeker.transform.position);

        totalSteeringForce += chaseForce * 0.1f;
    }

    protected override void Update()
    {
        base.Update();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
