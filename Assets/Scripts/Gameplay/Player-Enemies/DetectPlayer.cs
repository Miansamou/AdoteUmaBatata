using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    public int Range;
    public Transform RayPoint;

    private RaycastHit2D hit;
    private Character character;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponentInParent<Character>();
    }

    public bool SawPlayer()
    {
        hit = Physics2D.Raycast(RayPoint.position, Vector2.right * character.getDirection(), Range);
        Debug.DrawRay(RayPoint.position, Vector2.right * character.getDirection() * Range, Color.red);
        
        // If it hits something...
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }
}
