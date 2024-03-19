using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    // Start is called before the first frame update
    public static Shop instance;

    [SerializeField]
    private GameObject vydle;
    [SerializeField]
    private GameObject kus;
    [SerializeField]
    private GameObject musketa;
    [SerializeField]
    private GameObject brokovnice;

    public bool Vydle = true;
    public bool Kus = false;
    public bool Musketa = false;
    public bool Brokovnice = false;


    bool shopper = true;
    int kes = 50;
    int mes = 200;
    int bres = 400;


    void Start()
    {
        Shop.instance = this;
        ZpracujObjekty();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(shopper){
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                shopper = !shopper;
            }
            else{
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                shopper = !shopper;
            }
        }
    }

    void ZpracujObjekty(){
        vydle.SetActive(Vydle);
        kus.SetActive(Kus);
        musketa.SetActive(Musketa);
        brokovnice.SetActive(Brokovnice);
    }
    void SetniVseFalse(){
        Vydle = false;
        Kus = false;
        Musketa = false;
        Brokovnice = false;
    }

    public void KupKus(){
        if (CoinCounter.instance.penize < kes)
            return;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        shopper = !shopper;
        CoinCounter.instance.penize -= kes;
        SetniVseFalse();
        Kus = true;
        ZpracujObjekty();
    }

    public void KupMusketu(){
        if (CoinCounter.instance.penize < mes)
            return;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        shopper = !shopper;
        CoinCounter.instance.penize -= mes;
        SetniVseFalse();
        Musketa = true;
        ZpracujObjekty();
    }
    public void KupBrokovnici(){
        if (CoinCounter.instance.penize < bres)
            return;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        shopper = !shopper;
        CoinCounter.instance.penize -= bres;
        SetniVseFalse();
        Brokovnice = true;
        ZpracujObjekty();
    }
    private Shop(){}
}
