using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActive : MonoBehaviour
{
    private Button Btn;
    private AnimationUI Transition;
    public Animator NextMenu;
    public Animator ThisMenu;
    public string firstAnimation;
    public string secondAnimation;

    // Start is called before the first frame update
    void Start()
    {
        Transition = FindObjectOfType<AnimationUI>();
        Btn = GetComponent<Button>();
        Btn.onClick.AddListener(() => Transition.AnimationTransition(ThisMenu, NextMenu, firstAnimation, secondAnimation));
    }
}
