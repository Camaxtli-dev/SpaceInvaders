using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelMaster : Singleton<LevelMaster> {
    public GameObject player;
    public Transform playerRespawn;
    public List<GameObject> mobs;
    public Transform respawnRoot;

    private LevelMaster() { }

    void Start() {
        CreatePlayer();
        PoolManager.Instance.CreatePool(mobs[0], 10);
        foreach(Transform t in respawnRoot) {
            PoolManager.Instance.GetReuseObject(mobs[0], t.position, t.rotation);
        }
    }

    public void CreatePlayer() {
        PoolManager.Instance.CreatePool(player, 1);
        GameObject go = PoolManager.Instance.GetReuseObject(player, playerRespawn.position, playerRespawn.rotation);
        var user = go.GetComponent<PlayerSpaceship>();
        user.percentDamage = Global.Instance._percentDamage;
        user.percentDefence = Global.Instance._percentDefence;
        user.speed += Global.Instance._speed;
        user.maxEnergyShield += Global.Instance._maxEnergyShield;
        user.maxStructure += Global.Instance._maxStructure;
        user.regenerationEnergyShield += Global.Instance._regenerationEnergyShield;
        user.UpdateStat();
    }
}
