using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nana : Character
{
    public GameObject Toothpick;
    public float throwForce;
    public bool throwing;
    public Transform inicialPosition;

    // Start is called before the first frame update
    void Start()
    {
        throwing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!throwing)
        {
            StartCoroutine(ThrowToothpick());
        }
    }

    IEnumerator ThrowToothpick()
    {
        throwing = true;
        Rigidbody2D rb2d = Toothpick.GetComponent<Rigidbody2D>();

        rb2d.bodyType = RigidbodyType2D.Dynamic;
        rb2d.AddForce(new Vector2(throwForce, 0), ForceMode2D.Impulse);

        yield return new WaitForSeconds(2f);

        rb2d.velocity = Vector2.zero;
        rb2d.bodyType = RigidbodyType2D.Kinematic;
        Toothpick.transform.position = inicialPosition.position;

        throwing = false;
    }
}
