using UnityEngine;
using System.Collections;

public class MobSpaceship : Spaceship {

    public int score;

    protected override void Explode() {
        InGameUI.Instance.ScoreCount(score);
        base.Explode();
    }
}
