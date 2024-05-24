using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zbran : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    protected double cooldownStrelby = 1.0;
    protected double cooldownZbyvajici = 0.0;
    protected bool prebiji = false;
    
    [SerializeField]
    protected Transform bodStrelby;

    [SerializeField] protected int damage;
    [SerializeField] protected double critChance;
    void Start()
    {
        
    }

    // Update is called once per frame
    protected void Update()
    {
        AktualizujCooldown();
        Strelba();
    }

    protected void AktualizujCooldown()
    {
        if(prebiji)
        {
            cooldownZbyvajici -= Time.deltaTime;
            if (cooldownZbyvajici <= 0)
            {
                prebiji = false;
            }
        }
    }
    protected void Strelba()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!prebiji)
            {
                Strilej();
            }
        }
    }

    protected virtual void Strilej()
    {
        cooldownZbyvajici = cooldownStrelby;
        prebiji = true;
    }
    
}
