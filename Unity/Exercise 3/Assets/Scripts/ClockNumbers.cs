using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockNumbers : MonoBehaviour
{
    [SerializeField]
    float radius = 1f;

    [SerializeField]
    GameObject numberPrefab;

    // Start is called before the first frame update
    void Start()
    {
		//for each number on the clock
        for (int i = 1; i <= 12; ++i)
        {
            GameObject clockNumber = Instantiate(numberPrefab, transform);

            //	Set Position
            float angle = 90f - (360 / 12) * i;

            float x = Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
            float y = Mathf.Sin(angle * Mathf.Deg2Rad) * radius;

            clockNumber.transform.Translate(x, y, 0);

            //	Set Text
            clockNumber.GetComponent<TextMesh>().text = string.Format("{0}", i);
        }
    }
}