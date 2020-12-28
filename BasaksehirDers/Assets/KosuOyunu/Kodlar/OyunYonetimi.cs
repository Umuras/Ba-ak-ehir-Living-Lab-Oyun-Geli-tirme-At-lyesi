using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunYonetimi : MonoBehaviour
{
    public float GecenSure = 0f;

    public float KarakterHiz = 10f;
    public float ArabaHizi = 7f;
    public float KameraHizi = 1f;


    PanelKontrol panelKontrol;
    void Start()
    {
        panelKontrol = GameObject.Find("OyunYonetim").GetComponent<PanelKontrol>();
    }

    float SonArttirilanZaman;
    void Update()
    {
        GecenSure += Time.deltaTime;
        panelKontrol.GecenSureText.text = "Geçen Süre : " + GecenSure.ToString("0");

       if((int)GecenSure % 2 == 0 && SonArttirilanZaman != (int)GecenSure)
        {
            KarakterHiz += 2;
            ArabaHizi++;
            KameraHizi += 0.2f;
            SonArttirilanZaman = (int)GecenSure;
        }
    }
}
