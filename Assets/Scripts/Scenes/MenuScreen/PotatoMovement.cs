using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoMovement : MonoBehaviour
{
    public Vector3 rotationSpeed;
    public float positionSpeed;

    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad < 4)
        {
            this.transform.position += positionSpeed * (Time.deltaTime * new Vector3(1, 0, 0));

            this.transform.Rotate(rotationSpeed, Space.Self);
        }
    }
}
