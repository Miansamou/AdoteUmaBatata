using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [Header("Physics options")]
    public float Speed;
    public float JumpForce;

    [Header("Sprite option")]
    public bool rightSprite;

    protected float horizontal;
    protected Rigidbody2D rig;
    protected float direction;

    private float rigth, left;
    private bool jumped;

    protected void DetectedSpriteSide()
    {
        if (rightSprite)
        {
            rigth = 0f;
            left = 180f;
        }
        else
        {
            rigth = 180f;
            left = 0f;
        }
    }

    protected void Move(float h)
    {
        horizontal = h;

        Vector3 movement = new Vector3(horizontal, 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;

        //Change front of the sprite
        if (horizontal > 0)
        {
            transform.eulerAngles = new Vector2(0f, rigth);
        }

        if (horizontal < 0)
        {
            transform.eulerAngles = new Vector2(0f, left);
        }
    }

    protected void Jump(bool wantJump, bool onGround)
    {
        if (wantJump && onGround)
        {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            jumped = true;
        }

        if (!onGround && jumped)
        {
            if (rig.velocity.y > JumpForce)
            {
                rig.velocity = new Vector2(rig.velocity.x, JumpForce / 2);
            }
            else if (rig.velocity.y < 0)
            {
                jumped = false;
            }
        }
    }

    protected void fallFromPlatform(bool wantFall, LayerMask layer)
    {
        if (wantFall)
        {
            StartCoroutine(ChangeLayer(layer));
        }
    }

    IEnumerator ChangeLayer(LayerMask layer)
    {
        this.gameObject.layer = 11;

        yield return new WaitForSeconds(0.5f);

        if(layer != 11)
        {
            this.gameObject.layer = layer.value;
        }
    }

    public float getDirection()
    {
        return direction;
    }
}