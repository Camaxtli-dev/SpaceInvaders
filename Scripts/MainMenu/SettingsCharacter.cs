using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsCharacter : MonoBehaviour {

    public string thronesSelect;
    public Toggle Pontiff;
    public Toggle Logos;
    public Toggle Testament;
    public Toggle Messiah;
    public Toggle Cornerstone;
    
    public Text dominanceCount;
    public Text prideCount;
    public Text ardorCount;
    public Text defianceCount;
    public Text poiseCount;
    public Text acumenCount;
    public Text transcendenceCount;
    public Text splendorCount;
    public Text pointsVirtuesCount;

    private float percentDamage;
    private float percentDefence;
    private float speed;
    private float maxEnergyShield;
    private float maxStructure;
    private float regenerationEnergyShield;

    public int _dominance; // Каждая единица дает - 4% урона и 7 ед энергии щита
    public int _pride; // Каждая единица дает - 4% урона и 7 структуры
    public int _ardor; // Каждая единица дает - 4% урона и 0.125 скорости
    public int _defiance; // Каждая единица дает - 4% урона и 1% защиты
    public int _poise; // Каждая единица дает - 0.5 регенерации энергии щита в секунду и 0.125 скорости
    public int _acumen; // Каждая единица дает - 0.5 регенерации энергии щита в секунду и 1% защиты
    public int _transcendence; // Каждая единица дает - по 7 ед энергии щита и структуры
    public int _splendor; // Каждая единица дает - 10% бонуса к заработаным очкам веры за уровень
    public int pointsVirtues; // Очки прокачки статов

    void Start() {
        UpdateUI();
    }

    public void ToggleThrones(string selectToogle) {
        thronesSelect = selectToogle;
    }

    public void AddPointVirtues(string nameVirtues) {
        switch(nameVirtues) {
            case "Dominance":
                if(pointsVirtues > 0) {
                    _dominance++;
                    pointsVirtues--;
                }
                break;
            case "Pride":
                if(pointsVirtues > 0) {
                    _pride++;
                    pointsVirtues--;
                }
                break;
            case "Ardor":
                if(pointsVirtues > 0) {
                    _ardor++;
                    pointsVirtues--;
                }
                break;
            case "Defiance":
                if(pointsVirtues > 0) {
                    _defiance++;
                    pointsVirtues--;
                }
                break;
            case "Poise":
                if(pointsVirtues > 0) {
                    _poise++;
                    pointsVirtues--;
                }
                break;
            case "Acumen":
                if(pointsVirtues > 0) {
                    _acumen++;
                    pointsVirtues--;
                }
                break;
            case "Transcendence":
                if(pointsVirtues > 0) {
                    _transcendence++;
                    pointsVirtues--;
                }
                break;
            case "Splendor":
                if(pointsVirtues > 0) {
                    _splendor++;
                    pointsVirtues--;
                }
                break;
            default:
                break;
        }
        UpdateUI();
    }

    public void RemovePointVirtues(string nameVirtues) {
        switch(nameVirtues) {
            case "Dominance":
                if(_dominance > 1) {
                    _dominance--;
                    pointsVirtues++;
                }
                break;
            case "Pride":
                if(_pride > 1) {
                    _pride--;
                    pointsVirtues++;
                }
                break;
            case "Ardor":
                if(_ardor > 1) {
                    _ardor--;
                    pointsVirtues++;
                }
                break;
            case "Defiance":
                if(_defiance > 1) {
                    _defiance--;
                    pointsVirtues++;
                }
                break;
            case "Poise":
                if(_poise > 1) {
                    _poise--;
                    pointsVirtues++;
                }
                break;
            case "Acumen":
                if(_acumen > 1) {
                    _acumen--;
                    pointsVirtues++;
                }
                break;
            case "Transcendence":
                if(_transcendence > 1) {
                    _transcendence--;
                    pointsVirtues++;
                }
                break;
            case "Splendor":
                if(_splendor > 1) {
                    _splendor--;
                    pointsVirtues++;
                }
                break;
            default:
                break;
        }
        UpdateUI();
    }
    
    public void SendStatsInGlobalObj(string t) {
        int selectedThrones = 0;
        switch(t) {
            case "Pontiff": // Эффект душ длится втрое
                speed += 10;
                break;
            case "Logos": // + 50 энергии и структуры
                speed += 13;
                _splendor += 10;
                maxEnergyShield += 50;
                maxStructure += 50;
                break;
            case "Testament": // При передвижении скорость увеличивается до 20. При прекращении движения постепенно баф слетает до стартового значения. +15% защиты
                speed += 5;
                percentDefence += 15;
                break;
            case "Messiah": // W/S телепортирует на короткое расстояние
                speed += 3;
                selectedThrones = 1;
                break;
            case "Cornerstone": // W запоминает точку, S телепортирует в запомненую точку
                speed += 6;
                regenerationEnergyShield += 3;
                _splendor += 10;
                selectedThrones = 2;
                break;
            default:
                break;
        }

        CalculateStats();

        Global.Instance.PlayerStats(percentDamage, percentDefence, speed, maxEnergyShield, regenerationEnergyShield, maxStructure, selectedThrones);
    }

    private void CalculateStats() {
        percentDamage += (_dominance + _pride + _ardor + _defiance) * 4;
        percentDefence += _defiance + _acumen;
        speed += (_ardor + _poise) * 0.125f;
        maxEnergyShield += (_transcendence + _dominance) * 7;
        maxStructure += (_pride + _transcendence) * 7;
        regenerationEnergyShield += (_poise + _acumen) * 0.5f;
    }

    public void Play() {
        SendStatsInGlobalObj(thronesSelect);
        Application.LoadLevel(1);
    }

    private void UpdateUI() {
        dominanceCount.text = _dominance.ToString();
        prideCount.text = _pride.ToString();
        ardorCount.text = _ardor.ToString();
        defianceCount.text = _defiance.ToString();
        poiseCount.text = _poise.ToString();
        acumenCount.text = _acumen.ToString();
        transcendenceCount.text = _transcendence.ToString();
        splendorCount.text = _splendor.ToString();
        pointsVirtuesCount.text = pointsVirtues.ToString();
    }
}
