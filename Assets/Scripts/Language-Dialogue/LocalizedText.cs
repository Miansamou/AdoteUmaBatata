using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizedText : MonoBehaviour
{
    Text text;
    public string key;
    private string currentLanguage;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        UpdateText();
    }
    
    // When language is changed and this object is activated, this will update the text to the new language
    private void OnEnable()
    {
        if(currentLanguage != PlayerPrefs.GetString("Language") && !string.IsNullOrEmpty(currentLanguage))
        {
            UpdateText();
        }
    }
    
    public void UpdateText()
    {
        text.text = LocalizationManager.instance.GetLocalizedValue(key);
        currentLanguage = PlayerPrefs.GetString("Language");
    }
}
