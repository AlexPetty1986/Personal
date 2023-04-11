using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public bool collisionDetected = false;

    public Vector2 boundingBox = Vector2.one;

    public float radius = 1f;

    [SerializeField]
    public SpriteRenderer changeColor;

    [HideInInspector]
    public List<CollisionDetection> collide = new List<CollisionDetection>();

    // Start is called before the first frame update
    void Start()
    {
        changeColor = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(collisionDetected)
        {
            changeColor.color = Color.red;
        }

        else
        {
            changeColor.color = Color.white;
        }
    }

    public void CollisionRegister(CollisionDetection other)
    {
        collisionDetected = true;
        collide.Add(other);
    }

    public void ResetCollision()
    {
        collisionDetected = false;
        collide.Clear();
    }

    private void OnDrawGizmosSelected()
    {
        if(collisionDetected)
        {
            Gizmos.color = Color.magenta;
        }

        else
        {
            Gizmos.color = Color.green;
        }
            
        Gizmos.DrawWireSphere(transform.position, radius);
        //Gizmos.DrawWireCube(transform.position, boundingBox);
    }
}
