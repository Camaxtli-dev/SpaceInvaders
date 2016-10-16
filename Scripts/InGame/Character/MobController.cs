using UnityEngine;

public class MobController : MonoBehaviour {
    private MobSpaceship spaceship;
    Vector2 move;
    // Use this for initialization
    void Start() {
        spaceship = GetComponent<MobSpaceship>();
        move = new Vector2(transform.position.x, transform.position.y - 10);
    }

    // Update is called once per frame
    void Update() {
        if(spaceship.guns[0] != null)
            spaceship.Fire(0);
    }

    void FixedUpdate() {
        spaceship.Move(transform.up);
    }
}
