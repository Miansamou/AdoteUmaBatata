using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bira : Potato
{
    // Start is called before the first frame update
    void Start()
    {
        TouchSystem.instance.Enable();
        rig = GetComponent<Rigidbody2D>();
        grounded = GetComponentInChildren<Grounded>();
        animator = GetComponent<Animator>();
        DetectedSpriteSide();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!TouchSystem.instance.getDialogue())
        {
            PotatoMove();
            PotatoJump();
            PotatoFall();
        }
    }
}
