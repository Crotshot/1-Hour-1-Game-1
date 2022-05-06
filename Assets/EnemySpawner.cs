using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] float spawnTime, spawnVariance, oLow, oMid, oHigh;
    [SerializeField] GameObject low, mid, high;
    [SerializeField] Transform spawnPoint;
    float sT;

    private void Start() {
        sT = spawnTime;
    }

    private void Update() {
        sT -= Time.deltaTime;

        if(sT <= 0) {
            sT += spawnTime + Random.Range(-spawnVariance,spawnVariance);

            float num = Random.Range(0, oLow + oMid + oHigh);

            if(num < oLow) {
                Instantiate(low, spawnPoint.position, Quaternion.identity);
            }
            else if (num < oLow + oMid) {
                Instantiate(mid, spawnPoint.position, Quaternion.identity);
            }
            else {
                Instantiate(high, spawnPoint.position, Quaternion.identity);
            }
        }
    }

    public void OnButtonPress() {
        sT *= spawnTime/3f;
    }
}
