using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

    [SerializeField] [Range(-1,1)]int team;
    [SerializeField] int health;
    [SerializeField] float speed, hitcd = 0.25f;
    float hittimer;

    private void Start() {
        transform.localScale = Vector3.one * (health * 0.75f);
        transform.position += (health - 1) * Vector3.up * 0.08f;
    }

    private void Update() {
        if(hittimer > 0 && team == 1) {
            hittimer -= Time.deltaTime;
        }
        else {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right * team, transform.localScale.x * 0.12f);
            Debug.DrawRay(transform.position, Vector3.right * team * transform.localScale.x * 0.12f);
            if (hit.collider != null) {
                if (hit.collider.TryGetComponent(out Unit unit)) {
                    if (unit.GetTeam() != team) {
                        unit.Damage();
                        Damage();
                        hittimer += hitcd;
                    }
                }
            }
        }

        //if(transform.position.x > 10 * team) {
        //    Destroy(gameObject);
        //}
        transform.position += new Vector3(speed * Time.deltaTime * team,0,0);
    }

    public void Damage() {
        health -= 1;
        if(health <= 0) {
            Destroy(gameObject);
        }
    }


    public int GetTeam() {
        return team;
    }
}
