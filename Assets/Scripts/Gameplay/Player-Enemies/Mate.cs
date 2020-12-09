using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mate : Character
{
    protected Grounded ground;

    // Start is called before the first frame update
    void Start()
    {
        DetectedSpriteSide();
        ground = GetComponentInChildren<Grounded>();
        direction = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ChangeDirection();
        Move(direction);
    }

    protected void ChangeDirection()
    {
        if (!ground.getOnGround())
        {
            direction *= -1;
        }
    }
}
