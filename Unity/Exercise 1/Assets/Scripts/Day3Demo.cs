using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day3Demo : MonoBehaviour
{
    [SerializeField]
    public int myInt = 5;

    [SerializeField]
    Light worldLight;

    Rigidbody playerRB;

    // Start is called before the first frame update
    void Start()
    {
        worldLight.GetComponent<Light>().color = Color.red;

        GameObject.Find("Body");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(myInt);
    }
}
