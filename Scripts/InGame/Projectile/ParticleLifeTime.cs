using UnityEngine;
using System.Collections;

public class ParticleLifeTime : PoolObject {
    public float lifeTime;

    public override void OnObjectReuse() {
        StartCoroutine(Explode(lifeTime));
    }

    private IEnumerator Explode(float t) {
        yield return new WaitForSeconds(t);
        Destroy();
    }
}
