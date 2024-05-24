using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField]
    public int hp = 100;
    [SerializeField]
    public GameObject enemyTarget;
    [SerializeField]
    private GameObject endScreen;
    private Renderer barrierRenderer;

    [SerializeField]
    GameObject barieraFull;
    [SerializeField]
    GameObject barieraMid;
    [SerializeField]
    GameObject barieraLow;

    public void Start() {
        barrierRenderer = GetComponent<Renderer>();
        barieraMid.SetActive(false);
        barieraLow.SetActive(false);
    }

    private void Update() {
        if (hp <= 0) {
            Destroy(gameObject);
            Time.timeScale = 0;
            endScreen.active = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            RotaceKamery.muzeOtocit = false;
        }

        UpdateBarrierColor();
    }

    public void TakeDamage(int damage) {
        hp -= damage;
    }

    private void UpdateBarrierColor() {
        float hpRatio = (float)hp / 100f;
        if(hp <= 70 && hp > 30){
            barieraFull.SetActive(false);
            barieraMid.SetActive(true);
        }
        if(hp <= 30){
            barieraMid.SetActive(false);
            barieraLow.SetActive(true);
        }
    }
}
