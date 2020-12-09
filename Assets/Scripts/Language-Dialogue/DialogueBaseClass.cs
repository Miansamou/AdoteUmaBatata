using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBaseClass : MonoBehaviour
{
    protected IEnumerator WriteText(string input, Text textHolder, Color textColor, Font textFont, float delay, string appearSound)
    {
        TouchSystem.instance.Enable();

        float time = 0;

        textHolder.color = textColor;
        textHolder.font = textFont;

        AudioManager.instance.Play(appearSound);

        for (int i = 0; i < input.Length; i++)
        {
            if (TouchSystem.instance.TapScreen() && time > 0.5)
            {
                i = input.Length;

                yield return null;
            }


            textHolder.text += input[i];

            time += Time.deltaTime;

            yield return new WaitForSecondsRealtime(delay);
        }
    }
}
