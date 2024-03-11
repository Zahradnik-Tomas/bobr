using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    private int hp = 100;
    public GameObject[] targets;
    private GameObject closestTarget;

    [SerializeField]
    private float speed = 5f;

    void Start() {
        targets = GameObject.FindGameObjectsWithTag("Barrier");
    }

    void Update() {
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
        if (collision.gameObject.CompareTag("Vydle"))
        {
            if (hp > 0)
            {
                hp -= 20;
                Destroy(collision.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.CompareTag("Kus"))
        {
            if (hp > 0)
            {
                hp -= 40;
                Destroy(collision.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.CompareTag("Musketa"))
        {
            if (hp > 0)
            {
                hp -= 50;
                Destroy(collision.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.CompareTag("Brokovnice"))
        {
            if (hp > 0)
            {
                hp -= 100;
                Destroy(collision.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}