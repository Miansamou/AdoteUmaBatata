using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSound : MonoBehaviour
{
    public string PrefName;

    private Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        toggle = GetComponent<Toggle>();

        if (PlayerPrefs.HasKey(PrefName))
        {
            toggle.isOn = Convert.ToBoolean(PlayerPrefs.GetInt(PrefName));
        }
        else
        {
            toggle.isOn = false;
        }
    }

    public void changeMusic()
    {
        change();

        try
        {
            AudioManager.instance.setMusic();
        }
        catch
        {
            Debug.Log("Audio don't found");
        }
    }

    public void changeSound()
    {
        change();
        try
        {
            AudioManager.instance.setSound();
        }
        catch
        {
            Debug.Log("Audio don't found");
        }
    }

    public void changeVoice()
    {
        change();
        try
        {
            AudioManager.instance.setVoice();
        }
        catch
        {
            Debug.Log("Audio don't found");
        }
    }

    private void change()
    {
        PlayerPrefs.SetInt(PrefName, Convert.ToInt32(toggle.isOn));
    }
}
