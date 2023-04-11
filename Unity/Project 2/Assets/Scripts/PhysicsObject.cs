using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    Vector3 direction = Vector3.zero;
    Vector3 velocity = Vector3.zero;
    Vector3 acceleration = Vector3.one;
    Vector3 position = Vector3.negativeInfinity;
    public float radius = 1f;

    public Vector3 Direction
    {
        get { return direction; }
    }

    public Vector3 Velocity
    {
        get { return velocity; }
    }

    public Vector3 Acceleration
    {
        get { return acceleration; }
    }

    public Vector3 Position
    {
        get { return transform.position; }
    }

    public Vector3 Right
    {
        get { return transform.right; }
    }

    [SerializeField]
    float mass = 1f;

    [SerializeField]
    bool useGravity = true;
    [SerializeField]
    Vector3 gravity = Vector3.down;
    [SerializeField]
    public bool useFriction = true;
    [SerializeField]
    float coefficientOfFriction = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        if (position != Vector3.negativeInfinity)
        {
            position = transform.position;
        }

        direction = Random.insideUnitCircle.normalized;
    }

    // Update is called once per frame
    void Update()
    {

        if(useGravity)
        {
            ApplyGravity();
        }
        if(useFriction)
        {
            ApplyFriction();
        }

        velocity += acceleration * Time.deltaTime;

        position += velocity * Time.deltaTime;
        position.z = 0;

        direction = velocity.normalized;

        transform.rotation = Quaternion.LookRotation(Vector3.back, direction);

        transform.position = position;

        acceleration = Vector3.zero;
    }

    public void ApplyForces(Vector3 force)
    {
        acceleration += force / mass;
    }

    void ApplyGravity()
    {
        acceleration += gravity;
    }

    void ApplyFriction()
    {
        Vector3 friction = velocity * -1;
        friction.Normalize();
        friction = friction * coefficientOfFriction;
        ApplyForces(friction);
    }
}