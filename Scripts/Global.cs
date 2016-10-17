using UnityEngine;
using System.Collections;

public class Global : Singleton<Global> {

    public float _percentDamage;
    public float _percentDefence;
    public float _speed;
    public float _maxEnergyShield;
    public float _maxStructure;
    public float _regenerationEnergyShield;
    public int _thrones;

    private Global() { }

    protected override void Awake() {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    public void PlayerStats(float percentDamage, float percentDefence, float speed, float maxEnergyShield, float regenerationEnergyShield, float maxStructure, int thrones) {
        _percentDamage = percentDamage;
        _percentDefence = percentDefence;
        _speed = speed;
        _maxEnergyShield = maxEnergyShield;
        _maxStructure = maxStructure;
        _regenerationEnergyShield = regenerationEnergyShield;
        _thrones = thrones;
    }
}
