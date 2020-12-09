using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsModalMenu : MonoBehaviour
{
    public Button BackBtnMenu;
    public Button ContinueBtn;
    public Button BackToMenuBtn;

    private Image img;

    private void Awake()
    {
        img = GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Menu")
        {
            img.enabled = false;
            BackBtnMenu.gameObject.SetActive(true);
            ContinueBtn.gameObject.SetActive(false);
            BackToMenuBtn.gameObject.SetActive(false);
        }
        else
        {
            img.enabled = true;
            BackBtnMenu.gameObject.SetActive(false);
            ContinueBtn.gameObject.SetActive(true);
            BackToMenuBtn.gameObject.SetActive(true);
        }
    }
}
