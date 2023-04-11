using UnityEngine;

public class RotateHand : MonoBehaviour
{
    float turnAmount = 360f / 60f;

    [SerializeField]
    bool useDeltaTime = false;

    // Update is called once per frame
    void Update()
    {
        if(!useDeltaTime)
        {
            transform.Rotate(0, 0, -turnAmount);
        }

        else
        {
            transform.Rotate(0, 0, -turnAmount * Time.deltaTime);
        }
    }
}
