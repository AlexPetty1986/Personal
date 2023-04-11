using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Seeker : Agent
{
    public Fleer fleer;
    Vector3 fleeForce;

    protected override void CalcSteeringForces()
    {

        fleeForce = Seek(fleer.transform.position);

        totalSteeringForce += fleeForce * 0.1f;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
