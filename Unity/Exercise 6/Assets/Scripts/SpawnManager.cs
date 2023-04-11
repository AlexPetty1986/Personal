using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> prefabs = new List<GameObject>();

    public Vector2 minSpawnRange, maxSpawnRange;

    List<SpriteRenderer> spawnedCreatures = new List<SpriteRenderer>();

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        Cleanup();

        int randAnimals = Random.Range(20, 200);
        
        for(int i = 0; i < randAnimals; i++)
        {
            spawnedCreatures.Add(SpawnCreature());
        }
    }

    void Cleanup()
    {
        //destroy all creatures
        foreach(SpriteRenderer creature in spawnedCreatures)
        {
            Destroy(creature.gameObject);
        }

        //empty spawned creature list
        spawnedCreatures.Clear();
    }

    SpriteRenderer SpawnCreature()
    {
        SpriteRenderer spawnCreature;

        Vector3 spawnPosition = Vector3.zero;
        spawnPosition.x = Gaussian(0, (maxSpawnRange.x - 0) / 3);
        spawnPosition.y = Gaussian(0, (maxSpawnRange.y - 0) / 3);

        spawnCreature = Instantiate(PickRandomCreature(), spawnPosition, Quaternion.identity,transform).GetComponent<SpriteRenderer>();

        spawnCreature.color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);

        return spawnCreature;

    }

    private float Gaussian(float mean, float stdDev)
    {
        float val1 = Random.Range(0f, 1f);
        float val2 = Random.Range(0f, 1f);

        float gaussValue =
        Mathf.Sqrt(-2.0f * Mathf.Log(val1)) *
        Mathf.Sin(2.0f * Mathf.PI * val2);

        return mean + stdDev * gaussValue;
    }


    GameObject PickRandomCreature()
    {
        GameObject pickedCreature;

        //pick a random value
        float randValue = Random.Range(0f, 1f);

        //check against props
        //elephant 25%
        if(randValue < .25f)
        {
            pickedCreature = prefabs[0];
        }
        //kangaroo 30%
        else if(randValue < .3f)
        {
            pickedCreature = prefabs[1];
        }
        //octopus 10%
        else if(randValue < .1f)
        {
            pickedCreature = prefabs[2];
        }
        //snail 15%
        else if(randValue < .15f)
        {
            pickedCreature = prefabs[3];
        }
        //turtle 20%
        else
        {
            pickedCreature = prefabs[4];
        }

        return pickedCreature;
    }
}
