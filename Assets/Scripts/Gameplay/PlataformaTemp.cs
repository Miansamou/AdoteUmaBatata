using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaTemp : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 inicialPosition;

    private void Start()
    {
        inicialPosition = this.transform.localPosition;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("Bira"))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.mass = 50f;
            rb.gravityScale = 0.5f;
        }

        StartCoroutine(ResetKnife());
    }

    private IEnumerator ResetKnife()
    {
        yield return new WaitForSeconds(3f);
        
        rb.bodyType = RigidbodyType2D.Kinematic;
        this.transform.position = new Vector2(inicialPosition.x, inicialPosition.y);
        this.transform.rotation = new Quaternion(0, 0, 0, 0);
    }
}