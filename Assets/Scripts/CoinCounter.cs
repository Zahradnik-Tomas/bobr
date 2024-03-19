using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro.EditorUtilities;
using TMPro;


public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;

    public int penize = 0;
   [SerializeField]
   private TMP_Text coinCount;
   private CoinCounter(){}

    void Start(){
        CoinCounter.instance = this;
    }
   void Update(){
       coinCount.text = "" + penize;
   }
}
