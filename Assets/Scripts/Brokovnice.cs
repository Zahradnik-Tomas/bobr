using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Brokovnice : Zbran
{
    // Start is called before the first frame update
    [SerializeField] int pocetBrok = 5;
    [SerializeField] float maxSpread = 0.25f;
    System.Random rnd = new System.Random();
    float delitel;
    int demege;
    [SerializeField]
    VisualEffect nevim;
    protected override void Strilej()
    {
        if(!Shop.instance.Brokovnice){
            return;
        }

        delitel = 1.0f/maxSpread;
        base.Strilej();
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        nevim.Play();
        for(int i = 0; i < pocetBrok; i++)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward + new Vector3((((float)rnd.NextDouble() * 2.0f) - 1.0f)/delitel,(((float)rnd.NextDouble() * 2.0f) - 1.0f)/delitel, 0)), out hit, 1000))
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
}
