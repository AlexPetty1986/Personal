using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Vehicle : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    float speed = 4f;

    public Vector3 vehiclePosition;

    public Vector3 direction = Vector3.zero;

    Bullet newBullet;

    Vector3 velocity = Vector3.zero;

    bool shotFired;

    [SerializeField]
    float timer = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Velocity
        velocity = direction * speed * Time.deltaTime;

        //Add velocity to position
        vehiclePosition += velocity;

        // “Draw” this vehicle at that position
        transform.position = vehiclePosition;

        if(timer >= 0)
        {
            timer -= Time.deltaTime;
        }

        Wrapping();
    }

    public void OnMove(InputAction.CallbackContext context)
    {

        direction = context.ReadValue<Vector2>();

        if (direction == Vector3.zero)
        {
            return;
        }

        transform.rotation = Quaternion.LookRotation(Vector3.back, direction);
    }

    public void FireBullet()
    {
        if(direction != Vector3.zero)
        {
            if(!shotFired)
            {
                newBullet = Instantiate(bulletPrefab, vehiclePosition, Quaternion.LookRotation(Vector3.back, direction)).GetComponent<Bullet>();
                newBullet.direction = direction;
                newBullet.bulletPosition += vehiclePosition;
                shotFired = true;
                return;
            }
        }

        if(timer <= 0)
        {
            shotFired = false;
            timer = 1;
        }
    }

    void Wrapping()
    {
        Camera cameraObject = Camera.main;

        float totalCamHeight = cameraObject.orthographicSize * 2f;
        float totalCamWidth = totalCamHeight * cameraObject.aspect;

        if(vehiclePosition.x < -totalCamWidth / 2)
        {
            vehiclePosition.x = totalCamWidth / 2;
        }

        else if (vehiclePosition.x > totalCamWidth / 2)
        {
            vehiclePosition.x = -totalCamWidth / 2;
        }

        if (vehiclePosition.y < -totalCamHeight / 2)
        {
            vehiclePosition.y = totalCamHeight / 2;
        }
        else if (vehiclePosition.y > totalCamHeight / 2)
        {
            vehiclePosition.y = -totalCamHeight / 2;
        }

    }
}
