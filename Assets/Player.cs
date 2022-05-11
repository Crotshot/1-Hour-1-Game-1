using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    [SerializeField] float speed;
    float h, v;

    void FixedUpdate() {
        if (Time.timeScale == 0)
            return;

        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(h * speed * Time.deltaTime,v * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        FindObjectOfType<UI_Man>().Score();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
