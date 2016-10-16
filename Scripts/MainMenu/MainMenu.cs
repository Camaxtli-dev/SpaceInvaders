using UnityEngine;
using UnityEngine.UI;

public class MainMenu : Singleton<MainMenu> {
    public Text newGame;
    public Text loadLevel;
    public Text tuttorial;
    public Text credits;
    public Text setting;
    public Text exit;

    public GameObject mainMenuPanel;
    public GameObject settingPanel;
    public GameObject settingCharacterPanel;

    private MainMenu() { }

    void Start() {
        ShowMainMenuPanel();
    }

    void Update() {
    }

    public void Disconnect() {
        Application.Quit();
    }

    public void Language(string s) { // Все описания переместить в xml файл, это тестовый вариант
        if(s == "Русский") {
            newGame.text = "Новая игра";
            loadLevel.text = "Загрузить игру";
            tuttorial.text = "Обучение";
            credits.text = "Создатели";
            setting.text = "Настройки";
            exit.text = "Выход";
        }else if(s == "English") {
            newGame.text = "New game";
            loadLevel.text = "Load game";
            tuttorial.text = "Tuttorial";
            credits.text = "Credits";
            setting.text = "Setting";
            exit.text = "Exit";
        }
    }

    public void ShowMainMenuPanel() {
        mainMenuPanel.SetActive(true);
        settingPanel.SetActive(false);
        settingCharacterPanel.SetActive(false);
    }

    public void ShowSettingPanel() {
        settingPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
        settingCharacterPanel.SetActive(false);
    }

    public void ShowSettingCharacterPanel() {
        settingCharacterPanel.SetActive(true);
        settingPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
    }
}
