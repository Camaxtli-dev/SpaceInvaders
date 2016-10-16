using UnityEngine;
using System.Collections;

public class LaserProjectile : Projectile {
    public float timeDestroy;
    private Collider2D[] colliders;
    protected override void OnTriggerEnter2D(Collider2D other) { }

    public override void OnObjectReuse() {
        colliders = Physics2D.OverlapAreaAll(new Vector2(myTransform.position.x - 0.15f, myTransform.position.y), new Vector2(myTransform.position.x + 0.15f, myTransform.position.y + 10));
        AttackUnits();
    }

    private void AttackUnits() {
        foreach(Collider2D hit in colliders) {
            for(int i = 0; i < tagsUnitsToAttack.Length; i++) {
                if(tagsUnitsToAttack[i] == hit.tag) {
                    hit.GetComponent<Spaceship>().IncomingDamage(damage);
                }
            }
        }
        Explode();
    }

    protected override void Explode() {
        StartCoroutine(DestroyAfterEndTime(timeDestroy));
    }

    private IEnumerator DestroyAfterEndTime(float t) {
        yield return new WaitForSeconds(t);
        Destroy();
    }
}
