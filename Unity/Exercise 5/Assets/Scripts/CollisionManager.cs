using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public List<CollisionDetection> collidableObjects = new List<CollisionDetection>();

    public bool circleCollision = false;

    public float radius = 1f;

    public TextMesh currentCollision;

    // Start is called before the first frame update
    void Start()
    {
        SwitchAABB();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (CollisionDetection objectCollision in collidableObjects)
        {
            objectCollision.ResetCollision();
        }

        for(int i = 0; i < collidableObjects.Count; i++)
        {

            for (int j = i + 1; j < collidableObjects.Count; j++)
            {

                if (circleCollision)
                {
                    if (CircleCollision(collidableObjects[i], collidableObjects[j]))
                    {
                        collidableObjects[i].CollisionRegister(collidableObjects[j]);
                        collidableObjects[j].collisionDetected = true;
                    }
                }

                else
                {
                    if (AABBCollision(collidableObjects[i], collidableObjects[j]))
                    {
                        collidableObjects[i].CollisionRegister(collidableObjects[j]);
                        collidableObjects[j].collisionDetected = true;
                    }
                }
            }
        }
    }

    private bool AABBCollision(CollisionDetection ship, CollisionDetection planet)
    {
        if(planet.changeColor.bounds.min.x < ship.changeColor.bounds.max.x &&
            planet.changeColor.bounds.max.x > ship.changeColor.bounds.min.x &&
            planet.changeColor.bounds.min.y < ship.changeColor.bounds.max.y &&
            planet.changeColor.bounds.max.y > ship.changeColor.bounds.min.y)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    private bool CircleCollision(CollisionDetection ship, CollisionDetection planet)
    {
        float angle = 90f - (360 / 12);

        float x = Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
        float y = Mathf.Sin(angle * Mathf.Deg2Rad) * radius;

        if ((float)Mathf.Sqrt(Mathf.Pow(ship.transform.position.x - planet.transform.position.x, 2)
            + Mathf.Pow(ship.transform.position.y - planet.transform.position.y, 2))
            < (ship.radius + planet.radius))
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    public void SwitchCircle()
    {
        circleCollision = true;
        currentCollision.text = "Press X to Switch to AABB Collision\nCurrent Collision: Circle";
    }

    public void SwitchAABB()
    {
        circleCollision = false;
        currentCollision.text = "Press C to Switch to Circle Collision\nCurrent Collision: AABB";
    }
}
