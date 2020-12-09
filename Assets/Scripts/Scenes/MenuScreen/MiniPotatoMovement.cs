using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniPotatoMovement : MonoBehaviour
{
    private Vector3 rotationSpeed;
    private GameObject target;
    private CurrentStock stock;
    private Vector3 savedPosition;

    public string Tag;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        stock = GetComponent<CurrentStock>();
        target = GameObject.FindGameObjectWithTag(Tag);
    }

    private void OnEnable()
    {
        rotationSpeed = new Vector3(0, 0, Random.Range(1, 10));
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(rotationSpeed, Space.Self);
        
        savedPosition = transform.position;
        
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, distance);

        if (this.transform.position == target.transform.position || transform.position == savedPosition)
        {
            stock.Return();
        }
    }
}
