using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PohybHrace : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    [SerializeField] private float rychlost;
    private Vector2 otoc;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        otoc.x += Input.GetAxis("Mouse X");
        
        transform.localRotation = Quaternion.Euler(0, otoc.x, 0);
        float horMove = Input.GetAxisRaw("Horizontal");
        float verMove = Input.GetAxisRaw("Vertical");
        Vector3 move = (new Vector3(horMove, 0 , verMove)).normalized * rychlost * Time.deltaTime;
        Vector3 globalMove = transform.TransformDirection(move);
        rb.velocity = new Vector3(globalMove.x, rb.velocity.y, globalMove.z);
    }
}
