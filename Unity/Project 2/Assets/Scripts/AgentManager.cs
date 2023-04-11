using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AgentManager : MonoBehaviour
{
    public static AgentManager Instance;

    [HideInInspector]
    public List<TagPlayer> tagPlayers = new List<TagPlayer>();

    [SerializeField]
    public List<TagPlayer> currentItPlayers = new List<TagPlayer>();

    [SerializeField]
    public Vector2 maxPosition = Vector2.one;
    public Vector2 minPosition = -Vector2.one;

    public float edgePadding = 1f;

    public TagPlayer tagPlayerPrefab;
    public int numTagPlayers = 10;

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

        for (int i = 0; i < numTagPlayers; i++)
        {
            tagPlayers.Add(Spawn(tagPlayerPrefab));
            tagPlayers[i].currentTagPlayer = i;
        }

        int firstTagger = Random.Range(0, numTagPlayers - 1);
        int firstHealer = Random.Range(0, numTagPlayers - 1);
        
        while(firstTagger == firstHealer)
        {
            firstHealer = Random.Range(0, numTagPlayers - 1);
        }

        tagPlayers[firstTagger].Tag(tagPlayers[firstTagger]);
        tagPlayers[firstHealer].StateTransition(TagStates.Healer);
    }

    private T Spawn<T>(T prefabSpawn) where T : Agent
    {
        float xPos = Random.Range(minPosition.x, maxPosition.x);
        float yPos = Random.Range(minPosition.y, maxPosition.y - (0.5f + 0.68f));

        return Instantiate(prefabSpawn, new Vector3(xPos, yPos), Quaternion.identity);
    }

    public void buttonRunner()
    {
        tagPlayers.Add(Spawn(tagPlayerPrefab));
        tagPlayers[numTagPlayers].currentTagPlayer = numTagPlayers;
        numTagPlayers++;
    }

    public void buttonChaser()
    {
        tagPlayers.Add(Spawn(tagPlayerPrefab));
        tagPlayers[numTagPlayers].currentTagPlayer = numTagPlayers;
        tagPlayers[numTagPlayers].StateTransition(TagStates.Chaser);
        currentItPlayers.Add(tagPlayers[numTagPlayers]);
        numTagPlayers++;
    }

    public void buttonHealer()
    {
        tagPlayers.Add(Spawn(tagPlayerPrefab));
        tagPlayers[numTagPlayers].currentTagPlayer = numTagPlayers;
        tagPlayers[numTagPlayers].StateTransition(TagStates.Healer);
        numTagPlayers++;
    }

    public void buttonWraith()
    {
        tagPlayers.Add(Spawn(tagPlayerPrefab));
        tagPlayers[numTagPlayers].currentTagPlayer = numTagPlayers;
        tagPlayers[numTagPlayers].StateTransition(TagStates.Wraith);
        currentItPlayers.Add(tagPlayers[numTagPlayers]);
        numTagPlayers++;
    }

    public void buttonCounter()
    {
        tagPlayers.Add(Spawn(tagPlayerPrefab));
        tagPlayers[numTagPlayers].currentTagPlayer = numTagPlayers;
        tagPlayers[numTagPlayers].StateTransition(TagStates.Morpher);
        numTagPlayers++;
    }

    public void buttonRandom()
    {
        tagPlayers.Add(Spawn(tagPlayerPrefab));
        tagPlayers[numTagPlayers].currentTagPlayer = numTagPlayers;
        float randChoice = Random.Range(0.0f, 1.0f);
        if(randChoice <= 0.2)
        {
            tagPlayers[numTagPlayers].StateTransition(TagStates.Runner);
        }
        else if (randChoice > 0.2f && randChoice <= 0.4f)
        {
            tagPlayers[numTagPlayers].StateTransition(TagStates.Healer);
        }
        else if (randChoice > 0.4f && randChoice <= 0.6f)
        {
            tagPlayers[numTagPlayers].StateTransition(TagStates.Morpher);
        }
        else if (randChoice > 0.6f && randChoice <= 0.8f)
        {
            tagPlayers[numTagPlayers].StateTransition(TagStates.Chaser);
        }
        else if (randChoice > 0.8f && randChoice <= 1.0f)
        {
            tagPlayers[numTagPlayers].StateTransition(TagStates.Wraith);
        }
        numTagPlayers++;
    }

    public void buttonRemoveAgents()
    {
        for(int i = tagPlayers.Count - 1; i > -1; i--)
        {
            if(currentItPlayers.Contains(tagPlayers[i]))
            {
                currentItPlayers.RemoveAll(target => target.currentTagPlayer == tagPlayers[i].currentTagPlayer);
            }

            Destroy(tagPlayers[i].gameObject);
            tagPlayers.Remove(tagPlayers[i]);
            numTagPlayers--;
        }
    }

    public TagPlayer GetClosestTagPlayer(TagPlayer sourcePlayer)
    {
        float minDistance = float.MaxValue;
        TagPlayer closestPlayer = null;

        foreach (TagPlayer other in tagPlayers)
        {
            float sqrDistance = Vector3.SqrMagnitude(sourcePlayer.physicsObject.Position - other.physicsObject.Position);

            if (sqrDistance < float.Epsilon)
            {
                continue;
            }

            if (sqrDistance < minDistance && (other.CurrentState == TagStates.Runner || other.CurrentState == TagStates.Healer))
            {
                closestPlayer = other;
                minDistance = sqrDistance;
            }
        }

        return closestPlayer;
    }

    public TagPlayer FindCounter(TagPlayer sourcePlayer)
    {
        TagPlayer currentCounter = null;

        foreach (TagPlayer other in tagPlayers)
        {
            if(other.CurrentState == TagStates.Morpher)
            {
                currentCounter = other;
            }
        }

        return currentCounter;
    }
}
