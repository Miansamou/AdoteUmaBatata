using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSounds : MonoBehaviour
{
    public void PlaySound(string s)
    {
        AudioManager.instance.Play(s);
    }
}