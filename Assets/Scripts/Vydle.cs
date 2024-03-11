using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vydle : Zbran
{
    // Start is called before the first frame update
    [SerializeField] GameObject vydlePreFab;

    [SerializeField] float rychlostVydli;
    protected override void Strilej()
    {
        base.Strilej();
        GameObject vydle = Instantiate(vydlePreFab, bodStrelby.position, Quaternion.identity);
        vydle.GetComponent<Rigidbody>().AddForce(transform.forward * rychlostVydli, ForceMode.Impulse);
    }
}
