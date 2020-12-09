using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1 : MonoBehaviour
{
    private void Start()
    {
    }

    public void Intro()
    {
        AudioManager.instance.Play("Lamento Sertanejo Version One");
    }

    public void Cordel1()
    {
        AudioManager.instance.Play("Cordel1");
    }

    public void Cordel2()
    {
        AudioManager.instance.Play("Cordel2");
    }

    public void Cordel3()
    {
        AudioManager.instance.Play("Cordel3");
    }

    public void CharactersIn()
    {
        AudioManager.instance.Play("CharactersIn");
    }

    public void Bira1()
    {
        AudioManager.instance.Play("Bira1");
    }

    public void Bira2()
    {
        AudioManager.instance.Play("Bira2");
    }

    public void PTSFries()
    {
        AudioManager.instance.Play("PTSFries");
    }

    public void PTS1()
    {
        AudioManager.instance.Play("PTS1");
    }

    public void BigPotatoHead1()
    {
        AudioManager.instance.Play("BigPotatoHead1");
    }

    public void Kauai1()
    {
        AudioManager.instance.Play("Kauai1");
    }

    public void Chips1()
    {
        AudioManager.instance.Play("Chips1");
    }

    public void BigPotatoHead2()
    {
        AudioManager.instance.Play("BigPotatoHead2");
    }

    public void Kauai2()
    {
        AudioManager.instance.Play("Kauai2");
    }

    public void BigPotatoHead3()
    {
        AudioManager.instance.Play("BigPotatoHead3");
    }

    public void Kauai3()
    {
        AudioManager.instance.Play("Kauai3");
    }

    public void Bira3()
    {
        AudioManager.instance.Play("Bira3");
    }

    public void PTS2()
    {
        AudioManager.instance.Play("PTS2");
    }
    public void Farmer1()
    {
        AudioManager.instance.Play("Farmer1");
    }

    public void Farmer2()
    {
        AudioManager.instance.Play("Farmer2");
    }

    public void PTS3()
    {
        AudioManager.instance.Play("PTS3");
    }

    public void LoadGame()
    {
        AudioManager.instance.StopMusic();
        GameScenes.instance.LoadLevel(3);
    }
}
