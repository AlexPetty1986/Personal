using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionManager : MonoBehaviour
{
    public List<CollisionDetection> collidableObjects = new List<CollisionDetection>();

    public float radius = 1f;

    public float score = 0;
    public float playerHealth = 100;

    [SerializeField]
    Text scoreLabel;

    [SerializeField]
    Slider healthBar;

    [SerializeField]
    Text gameResults;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoreLabel.text = "SCORE: " + score;

        healthBar.value = playerHealth;

        for (int j = 0; j < FindObjectsOfType<GameObject>().Length; j++)
        {
            if(FindObjectsOfType<GameObject>()[j].activeInHierarchy && !collidableObjects.Contains(FindObjectsOfType<GameObject>()[j].GetComponent<CollisionDetection>()))
            {
                collidableObjects.Add(FindObjectsOfType<GameObject>()[j].GetComponent<CollisionDetection>());
            }
        }

        for (int z = collidableObjects.Count - 1; z >= 0; z--)
        {
            if(collidableObjects[z] == null)
            {
                collidableObjects.RemoveAt(z);
            }
        }

        foreach (CollisionDetection objectCollision in collidableObjects)
        {
            objectCollision.ResetCollision();
        }

        for (int i = 0; i < collidableObjects.Count; i++)
        {
            for (int j = i + 1; j < collidableObjects.Count; j++)
            {
                if (CircleCollision(collidableObjects[i], collidableObjects[j]))
                {
                    if(collidableObjects[i].name == "Player" && collidableObjects[j].tag != "Bullet")
                    {
                        collidableObjects[i].CollisionRegister(collidableObjects[j]);
                        collidableObjects[j].collisionDetected = true;
                        Destroy(collidableObjects[j].gameObject);
                        playerHealth -= 33;
                    }

                    if(collidableObjects[i].tag == "Bullet" && collidableObjects[j].tag == "EnemyShip")
                    {
                        collidableObjects[i].CollisionRegister(collidableObjects[j]);
                        collidableObjects[j].collisionDetected = true;
                        Destroy(collidableObjects[i].gameObject);
                        Destroy(collidableObjects[j].gameObject);
                        score++;
                    }

                    else if(collidableObjects[i].tag == "EnemyShip" && collidableObjects[j].tag == "Bullet")
                    {
                        collidableObjects[i].CollisionRegister(collidableObjects[j]);
                        collidableObjects[j].collisionDetected = true;
                        Destroy(collidableObjects[i].gameObject);
                        Destroy(collidableObjects[j].gameObject);
                        score++;
                    }
                }
            }
        }

        if(collidableObjects.Count <= 1 && playerHealth != 0)
        {
            gameResults.text = "YOU WIN!!";
        }

        if(playerHealth <= 0)
        {
            gameResults.text = "YOU LOSE!!";
        }
    }

    private bool CircleCollision(CollisionDetection ship, CollisionDetection enemy)
    {
        float angle = 90f - (360 / 12);

        float x = Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
        float y = Mathf.Sin(angle * Mathf.Deg2Rad) * radius;

        if ((float)Mathf.Sqrt(Mathf.Pow(ship.transform.position.x - enemy.transform.position.x, 2)
            + Mathf.Pow(ship.transform.position.y - enemy.transform.position.y, 2))
            < (ship.radius + enemy.radius))
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}
