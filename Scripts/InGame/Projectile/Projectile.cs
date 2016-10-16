using UnityEngine;
using System.Collections;

public class Projectile : PoolObject {

    private float baseDamage;
    public float damage;
    public float speed;
    public string[] tagsUnitsToAttack;
    public Transform myTransform;

    protected virtual void Awake() {
        myTransform = GetComponent<Transform>();
        baseDamage = damage;
    }

    protected virtual void Update () {
        myTransform.Translate(Vector2.up * Time.deltaTime * speed);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<Spaceship>() && tagsUnitsToAttack.Length > 0) {
            for(int i = 0; i < tagsUnitsToAttack.Length; i++) {
                if(tagsUnitsToAttack[i] == other.gameObject.tag) {
                    other.GetComponent<Spaceship>().IncomingDamage(damage);
                    Explode();
                }
            }
        }
    }

    public virtual void AddDamage(float addPercentDamage) {
        damage = baseDamage + baseDamage / 100 * addPercentDamage;
    }

    protected virtual void Explode() {
    }
}
