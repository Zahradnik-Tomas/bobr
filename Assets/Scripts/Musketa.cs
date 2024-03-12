using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musketa : Zbran
{
    // Start is called before the first frame update
    protected override void Strilej()
    {
    base.Strilej();
    RaycastHit[] hits;
    hits = Physics.RaycastAll(transform.position, transform.TransformDirection(Vector3.forward), 1000);
    for (int i = 0;i < hits.Length && i < 2 ; i++) {
        if(hits[i].transform.tag == "enemy"){
            Destroy(hits[i].transform.gameObject);
        }
    }
    } //https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
}
