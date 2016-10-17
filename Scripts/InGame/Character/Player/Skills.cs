using UnityEngine;
using System.Collections;

public class Skills : MonoBehaviour {
    public int selectedActiveSkillThrones;
    private float position;

    void Start() {
        position = transform.position.x;
    }

    public void Teleport(float pos) {
        transform.position = new Vector2(pos, transform.position.y);
    }

    public void ActivateFirstSkill() {
        switch(selectedActiveSkillThrones) {
            case 1:
                Teleport(transform.position.x - 1);
                break;
            case 2:
                position = transform.position.x;
                break;
            default:
                break;
        }
    }

    public void ActivateSecondSkill() {
        switch(selectedActiveSkillThrones) {
            case 1:
                Teleport(transform.position.x + 1);
                break;
            case 2:
                Teleport(position);
                break;
            default:
                break;
        }
    }
}
