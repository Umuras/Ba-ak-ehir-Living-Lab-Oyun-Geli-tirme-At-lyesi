using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KlonOlusturma : MonoBehaviour
{

    public GameObject Altin, Kutuk, Tas, Miknatis, Araba;
    public Oyuncu OyuncuYol1;
    public float OlusmaMesafesi = 50f;

    float SilinmeZamani = 20f;

    float SagTaraf = 69f;
    float SolTaraf = 50f;
    float OrtaTaraf = 60f;

    void NesneKlonla()
    {

        int RastSayi = Random.Range(0, 100);

        if (RastSayi < 50)
            Klonla(Altin, 1.5f);
        else if (RastSayi < 70)
            Klonla(Kutuk, 0.2f);
        else if (RastSayi < 90)
            Klonla(Araba, 1f);
        else if (RastSayi < 100)
            Klonla(Miknatis, 1.5f);
    }

    void Klonla(GameObject Nesne, float Yukseklik)
    {
        GameObject YeniNesne = Instantiate(Nesne);

        int RastSayi = Random.Range(0, 100);

        if(RastSayi < 33)
        {
            YeniNesne.transform.position = new Vector3(SagTaraf, Yukseklik, OyuncuYol1.transform.position.z + OlusmaMesafesi);
        }
        else if(RastSayi < 66)
        {
            YeniNesne.transform.position = new Vector3(OrtaTaraf, Yukseklik, OyuncuYol1.transform.position.z + OlusmaMesafesi);
        }
        else if (RastSayi < 100)
        {
            YeniNesne.transform.position = new Vector3(SolTaraf, Yukseklik, OyuncuYol1.transform.position.z + OlusmaMesafesi);
        }

        Destroy(YeniNesne, SilinmeZamani);

    }


    void Start()
    {

        InvokeRepeating("NesneKlonla", 0, 0.5f);


    }

    
    void Update()
    {
        
    }
}
