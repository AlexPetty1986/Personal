using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhysicsObject))]

public abstract class Agent : MonoBehaviour
{
    [SerializeField]
    public PhysicsObject physicsObject;

    [SerializeField]
    public float maxSpeed = 2f;

    [SerializeField]
    public float maxForce = 2f;

    protected Vector3 totalSteeringForce = Vector3.zero;

    private float wanderAngle = 0f;

    public float maxWanderAngle = 45f;

    public float maxWanderChangePerSecond = 10f;

    public float personalSpace = 1f;

    public float visionRange = 4f;

    // Start is called before the first frame update
    void Awake()
    {
        if (physicsObject == null)
        {
            physicsObject = GetComponent<PhysicsObject>();
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        CalcSteeringForces();

        //Limit total force
        totalSteeringForce = Vector3.ClampMagnitude(totalSteeringForce, maxForce);

        physicsObject.ApplyForces(totalSteeringForce);

        totalSteeringForce = Vector3.zero;
    }

    protected abstract void CalcSteeringForces();

    protected void Seek(Vector3 targetPosition, float weight = 1f)
    {
        Vector3 desiredVelocity = targetPosition - physicsObject.Position;

        desiredVelocity = desiredVelocity.normalized * maxSpeed;

        Vector3 seekForce = desiredVelocity - physicsObject.Velocity;

        totalSteeringForce += seekForce * weight;
    }

    public void Flee(Vector3 targetPosition, float weight = 1f)
    {
        Vector3 desiredVelocity = transform.position - targetPosition;

        desiredVelocity = desiredVelocity.normalized * maxSpeed;

        Vector3 fleeForce = desiredVelocity - physicsObject.Velocity;

        totalSteeringForce += fleeForce * weight;
    }


    protected void Wander(float weight = 1f)
    {
        float maxWanderChange = maxWanderChangePerSecond * Time.deltaTime;
        wanderAngle += Random.Range(-maxWanderChange, maxWanderChange);

        wanderAngle = Mathf.Clamp(wanderAngle, -maxWanderAngle, maxWanderAngle);

        Vector3 wanderTarget = Quaternion.Euler(0, 0, wanderAngle) * physicsObject.Direction.normalized + physicsObject.Position;

        Seek(wanderTarget, weight);
    }

    protected void Separate<T>(List<T> agents) where T : Agent
    {
        float sqrPersonalSpace = Mathf.Pow(personalSpace, 2);

        //loop through agents
        foreach(T other in agents)
        {
            //find square distance
            float sqrDistance = Vector3.SqrMagnitude(other.physicsObject.Position - physicsObject.Position);

            if(sqrDistance < float.Epsilon)
            {
                continue;
            }

            if(sqrDistance < sqrPersonalSpace)
            {
                float weight = sqrPersonalSpace / (sqrDistance + 0.01f);
                Flee(other.physicsObject.Position, weight);
            }
        }
    }

    protected void AvoidObstacle(Obstacle obstacle)
    {
        Vector3 desiredVelocity;

        //Get a vector from agent to obstacle
        Vector3 toObstacle = obstacle.Position - physicsObject.Position;

        //Check if obstacle is behind agent
        float fwdToObstacleDot = Vector3.Dot(physicsObject.Direction, toObstacle);

        if(fwdToObstacleDot < 0)
        {
            return;
        }

        //Check if obstacle is too far left or right from agent
        float rightToObstacleDot = Vector3.Dot(physicsObject.Right, toObstacle);

        if (Mathf.Abs(rightToObstacleDot) > physicsObject.radius + (obstacle.radius + 0.1))
        {
            return;
        }

        //Check is obstacle is within vision range
        if(fwdToObstacleDot > visionRange)
        {
            return;
        }

        //Passed all check, avoid obstacle
        if(rightToObstacleDot > 0)
        {
            //If on right, steer left
            desiredVelocity = physicsObject.Right * -maxSpeed;
        }
        else
        {
            //If on left, steer right
            desiredVelocity = physicsObject.Right * maxSpeed;
        }

        //Create a weight based on how close to obstacle agent is
        float weight = visionRange / (fwdToObstacleDot + 0.1f);

        //Apply steering force to total steering force
        totalSteeringForce += (desiredVelocity - physicsObject.Velocity) * weight;
    }

    protected void AvoidAllObstacles()
    {
        foreach(Obstacle obstacle in ObstacleManager.Instance.Obstacles)
        {
            AvoidObstacle(obstacle);
        }
    }

    protected void StayInBound(float weight = 1f)
    {
        Vector3 futurePosition = GetFuturePosition();

        if (futurePosition.x > AgentManager.Instance.maxPosition.x - 0.5 || 
            futurePosition.x < AgentManager.Instance.minPosition.x + 0.5 || 
            futurePosition.y > AgentManager.Instance.maxPosition.y - 0.5 || 
            futurePosition.y < AgentManager.Instance.minPosition.y + 0.5)
        {
            Seek(Vector3.zero, weight);
        }
    }

    public Vector3 GetFuturePosition(float timeToLookAhead = 1f)
    {
        return physicsObject.Position + physicsObject.Velocity * timeToLookAhead;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, physicsObject.radius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, personalSpace);
    }
}