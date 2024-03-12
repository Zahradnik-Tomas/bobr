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

    private bool canBeAttacked = true;
    private float attackCooldown = 1f;
    private Renderer barrierRenderer;

    public void Start() {
        barrierRenderer = GetComponent<Renderer>();

        StartCoroutine(EnemyAttackRoutine());
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

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            Attack();
        }
    }

    private IEnumerator ResetAttackCooldown() {
        yield return new WaitForSeconds(attackCooldown);
        canBeAttacked = true;
    }

    private IEnumerator EnemyAttackRoutine() {
        while (true) {
            yield return new WaitForSeconds(3f);
            Attack();
        }
    }

    private void Attack() {
        if (canBeAttacked) {
            Debug.Log("Barrier hit");
            canBeAttacked = false;
            StartCoroutine(ResetAttackCooldown());
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage) {
        hp -= damage;
    }

    private void UpdateBarrierColor() {
        float hpRatio = (float)hp / 100f;

        barrierRenderer.material.color = new Color(1f - hpRatio, hpRatio, 0f);
    }
}