using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] float min, var, dec;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject enemy;
    float timer;


    private void Start() {
        timer = 0;    
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0) {
            timer += Random.Range(min, var);
            if(var > min) {
                var -= dec;
            }

            Instantiate(enemy, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        }
    }
}
