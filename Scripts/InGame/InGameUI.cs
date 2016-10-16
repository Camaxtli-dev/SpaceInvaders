using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class InGameUI : Singleton<InGameUI> {

    public Text scoreCount;
    public Text healthCount;
    public Text energyShieldCount;

    private InGameUI() { }

    public void ScoreCount(int count) {
        scoreCount.text = (Int32.Parse(scoreCount.text) + count).ToString();
    }

    public void HealthCount(float count) {
        healthCount.text = Math.Round(count,2).ToString();
    }

    public void EnergyShieldCount(float count) {
        energyShieldCount.text = Math.Round(count,2).ToString();
    }

}
