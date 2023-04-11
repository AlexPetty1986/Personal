using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Vehicle : MonoBehaviour
{

    [SerializeField]
    float speed = 8f;

    Vector3 vehiclePosition = Vector3.zero;

    Vector3 direction = Vector3.zero;

    Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        //vehiclePosition = transform.position;
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

        Wrapping();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();

        transform.rotation = Quaternion.LookRotation(Vector3.back, direction);
    }

    void Wrapping()
    {
        Camera cameraObject = Camera.main;

        float totalCamHeight = cameraObject.orthographicSize * 2f;
        float totalCamWidth = totalCamHeight * cameraObject.aspect;

        if(vehiclePosition.x < -totalCamWidth)
        {
            vehiclePosition.x = totalCamWidth / 2;
        }

        else if (vehiclePosition.x > totalCamWidth)
        {
            vehiclePosition.x = -totalCamWidth / 2;
        }

        if (vehiclePosition.y < -totalCamHeight)
        {
            vehiclePosition.y = totalCamHeight;
        }
        else if (vehiclePosition.y > totalCamHeight)
        {
            vehiclePosition.y = -totalCamHeight;
        }

    }
}
