using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateElements : MonoBehaviour
{
    public float StartTime;
    public float TimeRate;
    public Rect Area;
    public StockElements Stock;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Generate", StartTime, TimeRate);
    }

    private void Generate()
    {
        if (Stock.ListNotEmpty())
        {
            setElementPosition(Stock.getElement());
        }
    }

    private void setElementPosition(GameObject element)
    {
        var position = new Vector2(Random.Range(Area.x, - Area.width), Random.Range(Area.y, Area.height));
        element.transform.position = (Vector2)this.transform.position + position;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(100, 0, 100);
        Gizmos.DrawWireCube((Vector2)transform.position + new Vector2(- Area.width / 2, Area.height / 2), Area.size);
    }
}
