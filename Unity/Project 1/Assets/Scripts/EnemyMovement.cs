using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    int moveType = 0;

    [SerializeField]
    float speed = 4f;

    [SerializeField]
    Vehicle target;

    public Vector2 minSpawnRange, maxSpawnRange;

    Vector3 enemyPosition = Vector3.zero;

    Vector3 direction = Vector3.one;

    Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        enemyPosition.x = Random.Range(minSpawnRange.x / 2 , maxSpawnRange.x / 2);
        enemyPosition.y = Random.Range(minSpawnRange.y / 2, maxSpawnRange.y / 2);
    }

    // Update is called once per frame
    void Update()
    {
        //Velocity
        velocity = direction * speed * Time.deltaTime;

        //Add velocity to position
        enemyPosition += velocity;

        //“Draw” this vehicle at that position
        transform.position = enemyPosition;

        MovementType();
    }

    public void MovementType()
    {
        Camera cameraObject = Camera.main;

        float totalCamHeight = cameraObject.orthographicSize * 2f;
        float totalCamWidth = totalCamHeight * cameraObject.aspect;

        //Rotate enemy ships in direction they are facing
        transform.rotation = Quaternion.LookRotation(Vector3.back, direction);

        //bouncer
        if (moveType == 0)
        {
            if (enemyPosition.x < -totalCamWidth / 2)
            {
                direction.x += 1;
            }

            else if (enemyPosition.x > totalCamWidth / 2)
            {
                direction.x -= 1;
            }

            if (enemyPosition.y < -totalCamHeight / 2)
            {
                direction.y += 1;
            }
            else if (enemyPosition.y > totalCamHeight / 2)
            {
                direction.y -= 1;
            }
        }

        //verticalWrapper
        else if (moveType == 1)
        {
            if (enemyPosition.x < -totalCamWidth / 2)
            {
                enemyPosition.x = totalCamWidth / 2;
            }

            else if (enemyPosition.x > totalCamWidth / 2)
            {
                enemyPosition.x = -totalCamWidth / 2;
            }

            else if (enemyPosition.y < -totalCamHeight / 2)
            {
                direction.y += 1;
            }
            else if (enemyPosition.y > totalCamHeight / 2)
            {
                direction.y -= 1;
            }
        }

        //horizontal wrapper
        else if (moveType == 2)
        {
            if (enemyPosition.x < -totalCamWidth / 2)
            {
                direction.x += 1;
            }
            else if (enemyPosition.x > totalCamWidth / 2)
            {
                direction.x -= 1;
            }

            else if (enemyPosition.y < -totalCamHeight / 2)
            {
                enemyPosition.y = totalCamHeight / 2;
            }

            else if (enemyPosition.y > totalCamHeight / 2)
            {
                enemyPosition.y = -totalCamHeight / 2;
            }
        }

        //chaser
        else if(moveType == 3)
        {
            direction = target.direction;
            transform.rotation = Quaternion.LookRotation(Vector3.back, direction);
            enemyPosition = Vector2.MoveTowards(transform.position, target.vehiclePosition, speed * Time.deltaTime);
        }
    }
}
