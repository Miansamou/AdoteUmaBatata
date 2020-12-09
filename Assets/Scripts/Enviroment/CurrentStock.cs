using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentStock : MonoBehaviour
{
    private StockElements stock;

    public void setStock(StockElements stockSelected)
    {
        stock = stockSelected;
    }

    public void Return()
    {
        stock.ReturnElementToList(this.gameObject);
    }
}
