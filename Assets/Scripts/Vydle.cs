using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vydle : Zbran
{
    [SerializeField] GameObject vydlePreFab;

    [SerializeField] float rychlostVydli;

    public int Damage => this.damage;
    public double CritChanc => this.critChance;

    public static Vydle vydler;

    void Start(){
        vydler = this;
    }

    protected override void Strilej()
    {
        if(!Shop.instance.Vydle){
            return;
        }
        base.Strilej();
        GameObject vydle = Instantiate(vydlePreFab, bodStrelby.position, transform.rotation);
        vydle.GetComponent<Rigidbody>().AddForce(transform.forward * rychlostVydli, ForceMode.Impulse);
        Destroy(vydle, 20f);
    }
}
