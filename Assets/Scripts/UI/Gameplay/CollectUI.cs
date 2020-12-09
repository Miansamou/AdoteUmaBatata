using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectUI : MonoBehaviour
{
    public Text text;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void UpdateText(string newParam)
    {
        text.text = newParam;
        anim.SetTrigger("ShowUI");
    }
}
