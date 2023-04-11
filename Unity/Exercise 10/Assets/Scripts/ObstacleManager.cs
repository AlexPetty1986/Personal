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
            Obstacles.Add(Spawn(obstaclePrefab));
        }
    }

    private Obstacle Spawn(Obstacle prefabSpawn)
    {
        float xPos = Random.Range(minPosition.x, maxPosition.x);
        float yPos = Random.Range(minPosition.y, maxPosition.y);

        return Instantiate(prefabSpawn, new Vector3(xPos, yPos), Quaternion.identity);
    }
}
