using UnityEngine;
using System.Collections.Generic;

public class Gun : MonoBehaviour {

    public GameObject projectile;
    public List<Transform> positionOfShot;
    public float lastTimeShot;
    public Vector2 cooldown;
    public string[] tagsUnitsToAttack;

    void Awake() {
        lastTimeShot = Random.Range(cooldown.x, cooldown.y);
    }

    void Start () {
        PoolManager.Instance.CreatePool(projectile, 3);
	}
	
    public void Fire(float addPercentDamage) {
        if(lastTimeShot < Time.time) {
            lastTimeShot = Time.time + Random.Range(cooldown.x,cooldown.y);
            for(int i = 0; i < positionOfShot.Count; i++) {
                GameObject go = PoolManager.Instance.GetReuseObject(projectile, positionOfShot[i].position, positionOfShot[i].rotation);
                Debug.Log(go);
                Debug.Log(go.GetComponent<Projectile>());
                go.GetComponent<Projectile>().AddDamage(addPercentDamage);
                if(tagsUnitsToAttack.Length > 0) 
                    go.GetComponent<Projectile>().tagsUnitsToAttack = tagsUnitsToAttack;
            }
        }
    }
}
