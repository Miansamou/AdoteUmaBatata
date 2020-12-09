using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Potato : Character
{
    protected Grounded grounded;
    protected Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        TouchSystem.instance.Enable();
        rig = GetComponent<Rigidbody2D>();
        grounded = GetComponentInChildren<Grounded>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PotatoMove();
        PotatoJump();
    }

    protected void PotatoMove()
    {
        Move(TouchSystem.instance.HorizontalPress());

        animator.SetFloat("Moving", Mathf.Abs(horizontal));
    }

    protected void PotatoJump()
    {
        Jump(TouchSystem.instance.UpSwipe(), grounded.getOnGround());

        animator.SetBool("Jumping", !grounded.getOnGround());
    }

    protected void PotatoFall()
    {
        fallFromPlatform(TouchSystem.instance.DownSwipe(), this.gameObject.layer);
    }
}
