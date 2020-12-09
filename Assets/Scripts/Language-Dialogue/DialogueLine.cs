using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueLine : DialogueBaseClass
{
    [Header("Text Options")]
    public string[] key;
    public Color TextColor;
    public Font TextFont;
    private int index;
    private bool dialogueEnded;

    [Header("Time")]
    public float Delay;

    [Header("Sound/Voice")]
    public string PlayableSound;

    private Text textHolder;
    private string input;

    private void Start()
    {
        dialogueEnded = false;
        index = 0;
    }

    public void Play()
    {
        textHolder = GetComponent<Text>();

        textHolder.text = "";

        if (index < key.Length)
        {
            input = LocalizationManager.instance.GetLocalizedValue(key[index]);
        }
        else
            dialogueEnded = true;

        index++;

        StartCoroutine(WriteText(input, textHolder, TextColor, TextFont, Delay, PlayableSound));
    }

    public bool getDialogueEnded()
    {
        return dialogueEnded;
    }
}
