using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToHUD : MonoBehaviour
{
    private bool go;
    public Transform hud;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (go)
        {
            transform.position = Vector2.MoveTowards(transform.position, Camera.main.ScreenToWorldPoint(hud.position), 10 * Time.deltaTime);

            if ((Vector2)transform.position == (Vector2)Camera.main.ScreenToWorldPoint(hud.position))
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            go = true;
        }
    }
}
