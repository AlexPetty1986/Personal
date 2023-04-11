using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (PhysicsObject))]

public abstract class Agent : MonoBehaviour
{
    [SerializeField]
    protected PhysicsObject physicsObject;

    [SerializeField]
    PhysicsObject seekThem;

    [SerializeField]
    PhysicsObject fleeThem;

    [SerializeField]
    float maxSpeed = 2f;

    [SerializeField]
    float maxForce = 2f;

    [SerializeField]
    bool useVelocity = true;

    protected Vector3 totalSteeringForce;
    public float radius = 1f;

    // Start is called before the first frame update
    void Start()
    {
        physicsObject = GetComponent<PhysicsObject>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        totalSteeringForce = Vector3.zero;

        CalcSteeringForces();

        //Limit total force
        totalSteeringForce = Vector3.ClampMagnitude(totalSteeringForce, maxForce);

        physicsObject.ApplyForces(totalSteeringForce);

        if(CircleCollision(seekThem, fleeThem))
        {
            fleeThem.position.x = Random.Range(-10, 10);
            fleeThem.position.x = Random.Range(-5, 5);
        }
    }

    protected abstract void CalcSteeringForces();

    public Vector3 Seek(Vector3 targetPosition)
    {
        Vector3 desiredVelocity = targetPosition - transform.position;

        desiredVelocity = desiredVelocity.normalized * maxSpeed;

        Vector3 seekForce = desiredVelocity - physicsObject.Velocity;

        if(useVelocity)
        {
            return seekForce;
        }

        else
        {
            return desiredVelocity;
        }
    }

    public Vector3 Flee(Vector3 targetPosition)
    {
        Vector3 desiredVelocity = transform.position - targetPosition;

        desiredVelocity = desiredVelocity.normalized * maxSpeed;

        Vector3 fleeForce = desiredVelocity - physicsObject.Velocity;

        if(useVelocity)
        {
            return fleeForce;
        }

        else
        {
            return desiredVelocity;
        }
    }

    public bool CircleCollision(PhysicsObject seekMan, PhysicsObject fleeMan)
    {
        float angle = 90f - (360 / 12);

        float x = Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
        float y = Mathf.Sin(angle * Mathf.Deg2Rad) * radius;

        if ((float)Mathf.Sqrt(Mathf.Pow(seekMan.transform.position.x - fleeMan.transform.position.x, 2)
            + Mathf.Pow(seekMan.transform.position.y - fleeMan.transform.position.y, 2))
            < (seekMan.radius + fleeMan.radius))
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}
