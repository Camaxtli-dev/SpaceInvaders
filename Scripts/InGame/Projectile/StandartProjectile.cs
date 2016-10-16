using UnityEngine;
using System.Collections;

public class StandartProjectile : Projectile {
    public GameObject explosionEffect;
    
    protected override void Awake() {
        base.Awake();
        PoolManager.Instance.CreatePool(explosionEffect, 3);
    }

    protected override void Explode() {
        PoolManager.Instance.GetReuseObject(explosionEffect, myTransform.position, myTransform.rotation);
        Destroy();
    }
}
