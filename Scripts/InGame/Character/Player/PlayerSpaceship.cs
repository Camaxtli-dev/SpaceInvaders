using UnityEngine;
using System.Collections;

public class PlayerSpaceship : Spaceship {
    private Skills skills;
    public int selectedThrones;
    public GameObject energyShieldParticleSysytem;
    protected GameObject gunTwo;

    protected override void Start() {
        base.Start();
        skills = GetComponent<Skills>();
        skills.selectedActiveSkillThrones = selectedThrones;

        if(guns.Count > 1) {
            gunTwo = (GameObject)Instantiate(guns[1], gunPosition.position, gunPosition.rotation);
            gunTwo.transform.parent = gunPosition;
        }

        PoolManager.Instance.CreatePool(energyShieldParticleSysytem, 1);
    }

    public override void Fire(int numberGun) {
        base.Fire(numberGun);

        if(numberGun == 1) {
            gunTwo.GetComponent<Gun>().Fire(percentDamage);
        }
    }

    public void SkillOne() {
        skills.ActivateFirstSkill();
    }

    public void SkillTwo() {
        skills.ActivateSecondSkill();
    }

    public override void IncomingDamage(float damage) {
        base.IncomingDamage(damage);

        if(energyShield > 0)
            PoolManager.Instance.GetReuseObject(energyShieldParticleSysytem, myTransform.position, myTransform.rotation).transform.parent = myTransform;

        InGameUI.Instance.HealthCount(health);
        InGameUI.Instance.EnergyShieldCount(energyShield);
    }

    protected override void RegenerationEnergyShield() {
        base.RegenerationEnergyShield();
        InGameUI.Instance.EnergyShieldCount(energyShield);
    }

    public void UpdateStat() {
        energyShield = maxEnergyShield;
        structure = maxStructure;
    }
}
