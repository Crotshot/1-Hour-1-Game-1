using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour {


    [SerializeField] [Min(1)]float force, maxSpeed, spinSpeed;
    Rigidbody2D rb2D;
    Camera main;
    Vector3 target;

    private void Start() {
        rb2D = GetComponent<Rigidbody2D>();
        main = FindObjectOfType<Camera>();
    }


    private void Update() {
        if(Time.timeScale != 0) {
            target = main.ScreenToWorldPoint(Input.mousePosition);
            rb2D.AddForce((target - transform.position) * Time.deltaTime * force);
            rb2D.velocity = ClampV3(rb2D.velocity, maxSpeed);
            transform.localEulerAngles += Vector3.forward * Time.deltaTime * spinSpeed;
        }
    }



    private Vector3 ClampV3(Vector3 v3, float max) {
        return new Vector3(Mathf.Clamp(v3.x, -max, max),
            Mathf.Clamp(v3.y, -max, max),
            Mathf.Clamp(v3.z, -max, max));

    }
}
