using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    [SerializeField]
    private int hp = 100;
    public GameObject[] targets;
    private GameObject closestTarget;

    [SerializeField]
    private float speed = 2.25f;

    [SerializeField]
    private float attackCooldown = 1f;
    [SerializeField]
    private int damage = 10;
    private bool canAttack = false;
    System.Random rnd = new System.Random();

    Barrier bar;

    void Start() {
        targets = GameObject.FindGameObjectsWithTag("Barrier");
    }

    void Update() {
        if (transform.position.y <= -50){
            Umri();
        }
        if (targets.Length > 0) {
            closestTarget = GetClosestTarget();

            if (closestTarget != null) {
                if (Vector3.Distance(transform.position, closestTarget.transform.position) > 1.1f) {
                    Vector3 direction = closestTarget.transform.position - transform.position;

                    direction.Normalize();

                    transform.Translate(direction * speed * Time.deltaTime);
                }
                else {
                    speed = 0;
                }
            }
        }
    }
    private IEnumerator EnemyAttackRoutine() {
        while (canAttack) {
            yield return new WaitForSeconds(3f);
            bar.TakeDamage(damage);
        }
    }

    private GameObject GetClosestTarget() {
        GameObject closest = null;
        float closestDistance = Mathf.Infinity;

        if (targets != null) {
            foreach (GameObject target in targets) {
                if (target != null) {
                    float distance = Vector3.Distance(transform.position, target.transform.position);

                    if (distance < closestDistance) {
                        closest = target;
                        closestDistance = distance;
                    }
                }
            }
        }

        return closest;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            bar = collision.gameObject.GetComponent<Barrier>();
            canAttack = true;
            StartCoroutine(EnemyAttackRoutine());
        }
        else if (collision.gameObject.CompareTag("Vydle"))
        {
            if(rnd.NextDouble() < Vydle.vydler.CritChanc){
                DostanDmg(Vydle.vydler.Damage*2);
            }
            else{
                DostanDmg(Vydle.vydler.Damage);
            }
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionExit(Collision collision){
        if (collision.gameObject.CompareTag("Barrier"))
        {
            canAttack = false;
        }
    }
    public void DostanDmg(int dmg){
        hp -= dmg;
        if(hp <= 0){
            Umri();
        }
    }
    private void Umri()
    {
        CoinCounter.instance.penize += 1;
        this.canAttack = false;
        Destroy(gameObject);
    }
}
