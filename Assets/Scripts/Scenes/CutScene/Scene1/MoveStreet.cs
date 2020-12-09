using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStreet : MonoBehaviour
{
    public MoveStreet nextStreet;
    public float speed;
    private float currentPosition;
    private bool reseted;

    private void Start()
    {
        reseted = false;
        currentPosition = this.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition += speed;
        this.transform.position = new Vector2 (currentPosition, this.transform.position.y);

        if (this.transform.position.x < -10.69)
        {
            reseted = false;
            nextStreet.ResetCurrentPosition();
        }
    }

    public void ResetCurrentPosition()
    {
        if (!reseted)
        {
            reseted = true;
            currentPosition = 16.5f;
        }
    }
}
