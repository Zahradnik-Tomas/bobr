using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kus : Zbran
{
    // Start is called before the first frame update
    System.Random rnd = new System.Random();
    int demege;
    [SerializeField] GameObject arrowPreFab;
    [SerializeField] float rychlostArrow;
    protected override void Strilej()
    {
        if(!Shop.instance.Kus){
            return;
        }

        base.Strilej();
        RaycastHit hit;
        GameObject arrow = Instantiate(arrowPreFab, bodStrelby.position, transform.rotation);
        arrow.GetComponent<Rigidbody>().AddForce(transform.forward * rychlostArrow, ForceMode.Impulse);
        Destroy(arrow, 10f);
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1000))
        {
            if(hit.transform.tag == "Enemy"){
                demege = damage;
                if(rnd.NextDouble() < critChance)
                    demege *= 2;
                hit.transform.gameObject.GetComponent<MoveToTarget>().DostanDmg(demege);
            }
        } //https://docs.unity3d.com/ScriptReference/Physics.RaycastAll.html
    } //https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
}
