using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    public GameObject lastImage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lastImage.SetActive(true);
        AudioManager.instance.StopMusic();
        AudioManager.instance.Play("EndGameMusic");

        StartCoroutine(LoadGame());
    }

    private IEnumerator LoadGame()
    {

        yield return new WaitForSeconds(3);

        AudioManager.instance.StopMusic();
        GameScenes.instance.LoadLevel(1);
    }
}
