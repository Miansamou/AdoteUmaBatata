using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mamona : MonoBehaviour
{
    private RaycastHit2D[] hit;
    private bool atacking;
    private ParticleSystem particle;

    public float Radius;

    // Start is called before the first frame update
    void Start()
    {
        atacking = false;
        particle = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!atacking)
        {
            DetectPlayer();
        }
    }

    private void DetectPlayer()
    {
        hit = Physics2D.CircleCastAll(transform.position, Radius, Vector2.zero);

        if (hit != null)
        {
            for (int i = 0; i < hit.Length; i++)
            {
                if (hit[i].collider.CompareTag("Player"))
                {
                    Invoke("Assassinate", 1f);
                }
            }
        }
    }

    private void Assassinate()
    {
        particle.Play();
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, Radius);
    }
}
