using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScenes : MonoBehaviour
{
    public static GameScenes instance;

    private int nextScene;

    private void Awake()
    {
        if (instance == null)
        {
            nextScene = 1;
            instance = this;
        }
        else if(SceneManager.GetActiveScene().name != "LoadScreen")
        {
            Destroy(instance.gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void LoadLevel(int scene)
    {
        nextScene = scene;
        SceneManager.LoadScene(0);
    }

    public int getNextScene()
    {
        return nextScene;
    }
}
