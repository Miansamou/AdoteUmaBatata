using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour
{
    public CollectUI lifeUi;
    public CollectUI coinUi;

    private int lifeCount = 3;
    private int coinCount;

    public static PlayersManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void CollectLife()
    {
        lifeCount++;
        lifeUi.UpdateText(lifeCount.ToString());
    }

    public void CollectCoin()
    {
        coinCount++;
        coinUi.UpdateText(coinCount.ToString());
    }
}
