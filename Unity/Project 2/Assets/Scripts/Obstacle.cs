using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float radius = 1f;
    public int currentObstacle = 0;

    public Vector3 Position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(Position, radius);
    }
}
