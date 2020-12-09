using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("Sounds Library")]
    public Sound[] musics;
    public Sound[] sounds;
    public Sound[] voices;

    public static AudioManager instance;
    public static string currentScene;

    private bool muteSound;
    private bool muteVoice;
    private Sound currentMusic;

    // Start is called before the first frame update
    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else if (SceneManager.GetActiveScene().name != currentScene)
        {
            Destroy(instance.gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);

        foreach (Sound m in musics)
        {
            m.source = gameObject.AddComponent<AudioSource>();
            m.source.clip = m.clip;

            m.source.volume = m.volume;
            m.source.pitch = m.pitch;
            m.source.loop = m.loop;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        foreach (Sound v in voices)
        {
            v.source = gameObject.AddComponent<AudioSource>();
            v.source.clip = v.clip;

            v.source.volume = v.volume;
            v.source.pitch = v.pitch;
            v.source.loop = v.loop;
        }

        for (int i = 0; i < 3; i++)
        {
            if (!PlayerPrefs.HasKey("Sounds" + i))
            {
                PlayerPrefs.SetInt("Sounds" + i, Convert.ToInt32(true));
            }
        }
    }

    private void Start()
    {
        try
        {
            setSound();
            setVoice();
        }
        catch
        {
            Debug.Log("Music variable don't exist");
        }
    }

    public void Play(string name, Vector2 position = default(Vector2))
    {
        if (!muteSound)
        {
            try
            {
                Sound s = Array.Find(sounds, sound => sound.name == name);

                s.source.Play();

                return;
            }
            catch
            {
                Debug.Log(name + " not found in sounds");
            }
        }

        if (!muteVoice)
        {
            try
            {
                Sound s = Array.Find(voices, sound => sound.name == name);

                s.source.Play();

                return;
            }
            catch
            {
                Debug.Log(name + " not found in voices");
            }
        }

        try
        {

            Sound nextMusic = Array.Find(musics, sound => sound.name == name);

            Debug.Log(nextMusic.name);

            currentMusic = nextMusic;

            currentMusic.source.Play();

            currentMusic.source.mute = Convert.ToBoolean(PlayerPrefs.GetInt("Sounds0"));

            return;
        }
        catch
        {
            Debug.Log(name + " not found in musics");
        }
    }

    public void StopMusic()
    {
        if (currentMusic.source.isPlaying)
        {
            currentMusic.source.Stop();
        }
    }

    public void setMusic()
    {
        currentMusic.source.mute = Convert.ToBoolean(PlayerPrefs.GetInt("Sounds0"));
    }

    public void setSound()
    {
        muteSound = Convert.ToBoolean(PlayerPrefs.GetInt("Sounds1"));
    }

    public void setVoice()
    {
        muteVoice = Convert.ToBoolean(PlayerPrefs.GetInt("Sounds2"));
    }
}

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    public bool loop;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;
}
