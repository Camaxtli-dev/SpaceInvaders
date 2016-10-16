using UnityEngine;
using System.Collections;

public class ProjectilePendulum : Projectile {

    private Vector2 startPosition;
    private Vector2 move;
    
    void Awake () {
        move = new Vector2(1, 0);
    }
	
	protected override void Update () {
        base.Update();
        if(transform.position.x > startPosition.x + 2.5) {
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.y);
        } else if(transform.position.x < startPosition.x - 2.5) {
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.y);
        }
    }

    public override void OnObjectReuse() {
        startPosition = transform.position;
    }
}
