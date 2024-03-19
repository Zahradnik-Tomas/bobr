using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Musketa : Zbran
{
    // Start is called before the first frame update
    System.Random rnd = new System.Random();
    int demege;
    [SerializeField]
    VisualEffect nevim;
    protected override void Strilej()
    {
    if(!Shop.instance.Musketa){
       return;
    }
    base.Strilej();
    RaycastHit[] hits;
    nevim.Play();
    hits = Physics.RaycastAll(transform.position, transform.TransformDirection(Vector3.forward), 1000);
    for (int i = 0;i < hits.Length && i < 2 ; i++) {
        if(hits[i].transform.tag == "Enemy"){
            demege = damage;
            if(rnd.NextDouble() < critChance)
                demege *= 2;
            hits[i].transform.gameObject.GetComponent<MoveToTarget>().DostanDmg(demege);
        }
    }
    } //https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
}
