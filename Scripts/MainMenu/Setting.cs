using System;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour {

    public Dropdown language;

    void Start() {
        language.onValueChanged.AddListener(delegate { selectLanguage(language); });
    }

    private void selectLanguage(Dropdown language) {
        MainMenu.Instance.Language(language.captionText.text);
    }
}
