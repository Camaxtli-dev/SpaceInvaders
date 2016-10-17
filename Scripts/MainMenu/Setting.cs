using System;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour {

    public Dropdown language;

    void Start() {
        selectedLanguage(language);
        language.onValueChanged.AddListener(delegate { selectedLanguage(language); });
    }

    private void selectedLanguage(Dropdown language) {
        MainMenu.Instance.Language(language.captionText.text);
    }
}
