using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brokovnice : Zbran
{
    // Start is called before the first frame update
    [SerializeField] int pocetBrok;
    protected override void Strilej()
    {
        base.Strilej();
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        for(int i = 0; i < pocetBrok; i++)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1000))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit");
            } //https://docs.unity3d.com/ScriptReference/Physics.RaycastAll.html
        } //https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
    }
}
