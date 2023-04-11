using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : Agent
{
    public float wandWeigh = 2f;

    [Min(1f)]
    public float stayInWeight = 3f;

    protected override void CalcSteeringForces()
    {
        Wander(wandWeigh);
        StayInBound(stayInWeight);
    }
}
