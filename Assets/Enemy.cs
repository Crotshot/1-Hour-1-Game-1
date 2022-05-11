using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float force, maxSpeed;
    Transform player;
    Rigidbody2D rb2D;

    void Start()
    {
        player= FindObjectOfType<Player>().transform;
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Time.timeScale == 0)
            return;

        rb2D.AddForce((player.position - transform.position) * Time.deltaTime * force);
        rb2D.velocity = ClampV3(rb2D.velocity, maxSpeed);
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.transform.tag == "shuriken") {
            Destroy(gameObject);
        }
    }

    private Vector3 ClampV3(Vector3 v3, float max) {
        return new Vector3(Mathf.Clamp(v3.x, -max, max),
            Mathf.Clamp(v3.y, -max, max),
            Mathf.Clamp(v3.z, -max, max));

    }
}
