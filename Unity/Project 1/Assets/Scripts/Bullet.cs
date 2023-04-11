using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 bulletPosition;

    public Vector3 direction = Vector3.zero;

    float speed = 2f;

    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed * Time.deltaTime;
            
        bulletPosition += velocity;

        transform.position = bulletPosition;
    }

    public void bulletMovement()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.back, direction);
    }
}