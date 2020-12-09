using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockElements : MonoBehaviour
{
    public GameObject Prefab;
    public int ElementsQuantity;

    private Stack<GameObject> stock;

    // Start is called before the first frame update
    void Start()
    {
        stock = new Stack<GameObject>();
        CreateElements();
    }

    private void CreateElements()
    {
        for (int i = 0; i < ElementsQuantity; i++)
        {
            var element = Instantiate(Prefab, this.transform);
            element.SetActive(false);
            var selectThisStock = element.GetComponent<CurrentStock>();
            selectThisStock.setStock(this);
            stock.Push(element); 
        }
    }

    public GameObject getElement()
    {
        var element = stock.Pop();
        element.SetActive(true);

        return element;
    }

    public void ReturnElementToList(GameObject element)
    {
        element.SetActive(false);
        stock.Push(element);
    } 

    public bool ListNotEmpty()
    {
        return stock.Count > 0;
    }
}
