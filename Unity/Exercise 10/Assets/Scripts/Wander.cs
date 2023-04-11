using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : Agent
{
    protected override void CalcSteeringForces()
    {
        Wander();
        Separate(AgentManager.Instance.agentPlayers);
        StayInBound(4f);
        AvoidAllObstacles();
    }
}
