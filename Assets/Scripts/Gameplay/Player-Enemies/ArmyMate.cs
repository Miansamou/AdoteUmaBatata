using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyMate : Mate
{

    private DetectPlayer vision;
    private bool running;

    // Start is called before the first frame update
    void Start()
    {
        DetectedSpriteSide();
        vision = GetComponent<DetectPlayer>();
        ground = GetComponentInChildren<Grounded>();
        direction = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!running)
        {
            ChangeDirection();
            if (vision.SawPlayer())
            {
                StartChasePlayer();
            }
        }

        Move(direction);
    }

    private void StartChasePlayer()
    {
        Speed = 0;
        running = true;

        StartCoroutine(Chase(0.5f, 5, true));

        StartCoroutine(Chase(1.2f, 1, false));
    }

    IEnumerator Chase(float seconds, float speed, bool running)
    {
        yield return new WaitForSeconds(seconds);

        this.Speed = speed;
        this.running = running;
    }
}
