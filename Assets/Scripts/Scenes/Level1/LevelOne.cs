using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelOne : MonoBehaviour
{
    public Image DialogueImage;
    public DialogueLine IntroDialogue;

    private float timeDialogue;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.Play("baiao de dois");
        TouchSystem.instance.OpenDialogue();
        DialogueImage.gameObject.SetActive(true);

        timeDialogue = 0;
        IntroDialogue.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IntroDialogue.getDialogueEnded())
        {
            if (TouchSystem.instance.TapScreen() && timeDialogue > 0.5)
            {
                timeDialogue = 0;
                IntroDialogue.Play();
            }
        }
        else
        {
            DialogueImage.gameObject.SetActive(false);
            TouchSystem.instance.CloseDialogue();
        }

        if(timeDialogue <= 0.5)
        {
            timeDialogue += Time.deltaTime;
        }
    }
}
