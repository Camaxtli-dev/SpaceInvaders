using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Spaceship : Stats {
    public float maxHealth;
    public float maxEnergyShield;
    public float regenerationEnergyShield;
    public float maxStructure; // пока не задействована
    public float baseDefence; // пока не задействована
    public float speed;
    public float percentDamage=0;
    public float percentDefence=0;

    public Rigidbody2D rb;
    protected Transform myTransform;

    public List<GameObject> guns;
    protected GameObject gunOne;
    public Transform gunPosition;

    protected float lastTimeIncomingDamage;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        myTransform = GetComponent<Transform>();
    }

    protected virtual void Start() {
        if(guns.Count > 0) {
            gunOne = (GameObject)Instantiate(guns[0], gunPosition.position, gunPosition.rotation);
            gunOne.transform.parent = gunPosition;
        }
    }

    void Update() {
        if(lastTimeIncomingDamage < Time.time) {
            RegenerationEnergyShield();
        }
    }

    public void Move(Vector2 posX) {
        rb.MovePosition(rb.position + posX * Time.fixedDeltaTime * speed);
    }

    public virtual void Fire(int numberGun) {
        if(numberGun == 0 && gunOne.GetComponent<Gun>() != null) {
            gunOne.GetComponent<Gun>().Fire(percentDamage);
        }
    }

    public virtual void IncomingDamage(float damage) {
        lastTimeIncomingDamage = Time.time + 1;
        energyShield -= damage;
        if(energyShield < 0) {
            health -= Math.Abs(energyShield);
            energyShield = 0;
        }

        if(health <= 0) {
            Explode();
        }
    }

    protected virtual void RegenerationEnergyShield() {
        if(energyShield < maxEnergyShield) {
            energyShield += regenerationEnergyShield * Time.deltaTime;
        }
        if (energyShield > maxEnergyShield) {
            energyShield = maxEnergyShield;
        }
    }

    public override void OnObjectReuse() {
        base.OnObjectReuse();
        health = maxHealth;
        energyShield = maxEnergyShield;
        defence = baseDefence;
    }

    protected virtual void Explode() {
        // Анимация взрыва/разрушения
        Destroy();
    }
}
