using UnityEngine;
using System;

public class PlayerController : MonoBehaviour {
    private PlayerSpaceship spaceship;
    private Vector2 move;
    // Use this for initialization
    void Start() {
        spaceship = GetComponent<PlayerSpaceship>();
        move = new Vector2(1, 1);
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetButton("Fire1")) {
            spaceship.Fire(0);
        }
        if(Input.GetButton("Fire2")) {
            spaceship.Fire(1);
        }
    }

    void FixedUpdate() {
        Camera cam = Camera.main;
        if(Math.Round(cam.ScreenToWorldPoint(Input.mousePosition).x, 1) < Math.Round(spaceship.rb.position.x - .4f, 1)) {
            spaceship.Move(move * -1);
        } else if(Math.Round(cam.ScreenToWorldPoint(Input.mousePosition).x, 1) > Math.Round(spaceship.rb.position.x + .4f, 1)) {
            spaceship.Move(move * 1);
        }
    }
}
