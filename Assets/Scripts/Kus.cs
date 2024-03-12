using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kus : Zbran
{
    // Start is called before the first frame update
    protected override void Strilej()
    {
    base.Strilej();
    RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1000))
        {
            if(hit.transform.tag == "enemy"){
                Destroy(hit.transform.gameObject);
            }
        } //https://docs.unity3d.com/ScriptReference/Physics.RaycastAll.html
    } //https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
}
