using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (PhysicsObject))]

public abstract class Agent : MonoBehaviour
{
    [SerializeField]
    protected PhysicsObject physicsObject;

    [SerializeField]
    float maxSpeed = 2f;

    [SerializeField]
    float maxForce = 2f;

    protected Vector3 totalSteeringForce = Vector3.zero;

    public float radius = 1f;

    private float wanderAngle = 0f;

    public float maxWanderAngle = 45f;

    public float maxWanderChangePerSecond = 10f;

    [Min(1f)]
    public float stayInBoundsWeight;

    // Start is called before the first frame update
    void Awake()
    {
        if(physicsObject == null)
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

    protected void Wander(float weight = 1f)
    {
        float maxWanderChange = maxWanderChangePerSecond * Time.deltaTime;
        wanderAngle += Random.Range(-maxWanderChange, maxWanderChange);

        wanderAngle = Mathf.Clamp(wanderAngle, -maxWanderAngle, maxWanderAngle);

        Vector3 wanderTarget = Quaternion.Euler(0, 0, wanderAngle) * physicsObject.Direction.normalized + physicsObject.Position;

        Seek(wanderTarget, weight);
    }

    protected void StayInBound(float weight = 1f)
    {
        stayInBoundsWeight = weight;

        Vector3 futurePosition = GetFuturePosition();

        if(futurePosition.x > physicsObject.CameraSize.x - 0.5 || futurePosition.x < -physicsObject.CameraSize.x + 0.5 || futurePosition.y > physicsObject.CameraSize.y - 0.5 || futurePosition.y < -physicsObject.CameraSize.y + 0.5)
        {
            Seek(Vector3.zero, stayInBoundsWeight);
        }
    }

    public Vector3 GetFuturePosition(float timeToLookAhead = 1f)
    {
        return physicsObject.Position + physicsObject.Velocity * timeToLookAhead;
    }
}
