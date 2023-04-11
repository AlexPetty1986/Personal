using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SceneManager : MonoBehaviour
{
    [SerializeField]
    List<PhysicsObject> physicObject = new List<PhysicsObject>();

    [SerializeField]
    Vector3 mousePos;

    // Update is called once per frame
    void Update()
    {
        mousePos = Mouse.current.position.ReadValue();
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;

        foreach(PhysicsObject obj in physicObject)
        {
            obj.ApplyForces(mousePos - obj.position);
        }
    }
}
