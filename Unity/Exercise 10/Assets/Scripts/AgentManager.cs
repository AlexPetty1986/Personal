using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AgentManager : MonoBehaviour
{
    public static AgentManager Instance;

    [HideInInspector]
    public List<Agent> agentPlayers = new List<Agent>();

    [HideInInspector]
    public Vector2 maxPosition = Vector2.one;
    public Vector2 minPosition = -Vector2.one;

    public float edgePadding = 1f;

    public Agent agentPrefab;
    public int numAgents = 10;

    public int countdownTime = 5;

    private void Awake()
    {
        if (Instance == null)
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

        for (int i = 0; i < numAgents; i++)
        {
            agentPlayers.Add(Spawn(agentPrefab));
        }
    }

    private T Spawn<T>(T prefabSpawn) where T : Agent
    {
        float xPos = Random.Range(minPosition.x, maxPosition.x);
        float yPos = Random.Range(minPosition.y, maxPosition.y);

        return Instantiate(prefabSpawn, new Vector3(xPos, yPos), Quaternion.identity);
    }
}
