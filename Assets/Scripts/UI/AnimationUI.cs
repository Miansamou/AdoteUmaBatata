using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationUI : MonoBehaviour
{
    public float WaitTime;

    public void AnimationTransition(Animator animation, Animator nextObject, string firstAnimation, string secondAnimation)
    {
        animation.Play(firstAnimation);

        StartCoroutine(DesactiveObject(nextObject, secondAnimation));
    }

    private IEnumerator DesactiveObject(Animator nextObject, string animationName)
    {
        yield return new WaitForSecondsRealtime(WaitTime);

        nextObject.Play(animationName);
    }
}
