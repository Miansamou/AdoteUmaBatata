using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScreen : MonoBehaviour
{

    public Slider slider;

    private void Start()
    {
        StartCoroutine(LoadAsynchronously(GameScenes.instance.getNextScene()));
    }

    IEnumerator LoadAsynchronously(int scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync((int)scene);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;

            yield return null;
        }
    }
}