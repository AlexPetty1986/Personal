using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise2 : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;

    [SerializeField]
    List<Vector3> myPositions;

    // Start is called before the first frame update
    void Start()
    {
        GameObject tempCopy;

        foreach(Vector3 position in myPositions)
        {
            //create a copy
            tempCopy = Instantiate(prefab);

            //set position
            tempCopy.transform.localPosition = position;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
