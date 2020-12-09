using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopToothpickMovement : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
