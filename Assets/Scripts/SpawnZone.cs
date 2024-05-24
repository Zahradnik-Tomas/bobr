using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private int enemiesCount;
    [SerializeField]
    private TMP_Text start;
    [SerializeField]
    private TMP_Text waveCount;
    [SerializeField]
    private GameObject shop;
    [SerializeField]
    private GameObject endScreen;

    private int wave = 0;
    private bool spawningStarted = false;

    private void Start() {
        RotaceKamery.muzeOtocit = true;
        Time.timeScale = 1;
        waveCount.enabled = false;
        shop.active = false;
        endScreen.active = false;
    }

    void Update() {
        if (spawningStarted) {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0) {
                for (int i = 0; i < enemiesCount; i++) {
                    SpawnEnemy();
                }

                wave++;
                waveCount.text = "Wave " + wave;
                enemiesCount += 1 + enemiesCount / 3;
            }
        }
        else {
            if (Input.GetKeyDown(KeyCode.Space)) {
                waveCount.enabled = true;
                spawningStarted = true;
                start.enabled = false;
                shop.active = true;
            }
        }
    }

    void SpawnEnemy() {
        float spawnX = Random.Range(transform.position.x - 20f, transform.position.x);
        float spawnZ = Random.Range(transform.position.z - 8f, transform.position.z + 8f);
        Vector3 spawnPosition = new Vector3(spawnX, 1f, spawnZ);
        Instantiate(enemy, spawnPosition, Quaternion.identity);
    }
}
