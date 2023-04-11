using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleManager : MonoBehaviour
{
    public static ObstacleManager Instance;

    public List<Obstacle> Obstacles = new List<Obstacle>();
    public Obstacle obstaclePrefab;
    public int numObstacles = 5;
    float maxSize = 1.5f;
    float radius = 0.55f;

    [HideInInspector]
    public Vector2 maxPosition = Vector2.one;
    public Vector2 minPosition = -Vector2.one;

    public float edgePadding = 1f;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        Camera cam = Camera.main;

        if (cam != null)
        {
            Vector3 camPosition = cam.transform.position;
            float halfHeight = cam.orthographicSize;
            float halfWidth = halfHeight * cam.aspect;

            maxPosition.x = camPosition.x + halfWidth - edgePadding;
            maxPosition.y = camPosition.y + halfHeight - edgePadding;
            minPosition.x = camPosition.x - halfWidth + edgePadding;
            minPosition.y = camPosition.y - halfHeight + edgePadding;
        }

        for (int i = 0; i < numObstacles; i++)
        {
            float randSize = Random.Range(0.1f, maxSize) + 0.5f;
            Obstacles.Add(Spawn(obstaclePrefab));
            Obstacles[i].currentObstacle = i;
            Obstacles[i].transform.localScale = Vector3.one * randSize;
            Obstacles[i].radius = Obstacles[i].radius * randSize;
        }
    }

    private void Update()
    {
        for (int j = 0; j < Obstacles.Count; j++)
        {
            for (int z = 0; z < Obstacles.Count; z++)
            {
                if (Obstacles[j].currentObstacle != Obstacles[z].currentObstacle)
                {
                    if (CircleCollision(Obstacles[j], Obstacles[z]))
                    {
                        Obstacles[z].Position = new Vector3(Random.Range(minPosition.x, maxPosition.x), Random.Range(minPosition.y, maxPosition.y - 0.68f));
                        Obstacles[Obstacles[z].currentObstacle] = Obstacles[z];
                    }
                }
            }
        }
    }

    public void moveObstacles()
    {
        for (int z = 0; z < Obstacles.Count; z++)
        {
            Obstacles[z].radius = 0.55f;
            float randSize = Random.Range(0.5f, maxSize) + 0.5f;
            Obstacles[z].Position = new Vector3(Random.Range(minPosition.x, maxPosition.x), Random.Range(minPosition.y, maxPosition.y - 0.68f));
            Obstacles[Obstacles[z].currentObstacle] = Obstacles[z];
            Obstacles[z].transform.localScale = Vector3.one * randSize;
            Obstacles[z].radius = Obstacles[z].radius * randSize;
        }
    }

    private Obstacle Spawn(Obstacle prefabSpawn)
    {
        float xPos = Random.Range(minPosition.x, maxPosition.x);
        float yPos = Random.Range(minPosition.y, maxPosition.y - 0.68f);

        return Instantiate(prefabSpawn, new Vector3(xPos, yPos), Quaternion.identity);
    }

    private bool CircleCollision(Obstacle obOne, Obstacle obTwo)
    {
        float angle = 90f - (360 / 12);

        float x = Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
        float y = Mathf.Sin(angle * Mathf.Deg2Rad) * radius;

        if ((float)Mathf.Sqrt(Mathf.Pow(obOne.Position.x - obTwo.Position.x, 2)
            + Mathf.Pow(obOne.Position.y - obTwo.Position.y, 2))
            < (obOne.radius + obTwo.radius))
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}
