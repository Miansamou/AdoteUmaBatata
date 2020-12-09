using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapTitleScreen : MonoBehaviour
{

    public Animator Menu;
    public GameObject Panel;
    public Animator Title, Text;

    // Start is called before the first frame update
    void Start()
    {
        TouchSystem.instance.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad > 0.5)
        {
            if (TouchSystem.instance.TapScreen() || Input.GetMouseButtonDown(0))
            {
                StartCoroutine(EndTitleScreen());
            }
        }   
    }

    IEnumerator EndTitleScreen()
    {
        Title.SetTrigger("EndTitleScreen");
        Text.SetTrigger("EndTitleScreen");

        yield return new WaitForSeconds(0.5f);

        Panel.SetActive(false);
        Menu.Play("MenuEnter");
        this.gameObject.SetActive(false);
    }
}
