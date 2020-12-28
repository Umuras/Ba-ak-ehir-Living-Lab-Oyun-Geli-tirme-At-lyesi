using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Araba : MonoBehaviour
{
    OyunYonetimi oyunYonetim;
    void Start()
    {
        oyunYonetim = GameObject.Find("OyunYonetim").GetComponent<OyunYonetimi>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, -oyunYonetim.ArabaHizi * Time.deltaTime);
    }
}
