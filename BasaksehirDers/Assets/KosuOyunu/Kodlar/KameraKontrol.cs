using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class KameraKontrol : MonoBehaviour
{
    OyunYonetimi oyunYonetim;
    public GameObject TakipedilecekObje;
    public Vector3 Mesafe = new Vector3(0, 0, -1);
    public float takipHizi = 1f;
    void Start()
    {
        oyunYonetim = GameObject.Find("OyunYonetim").GetComponent<OyunYonetimi>();
    }

    
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, TakipedilecekObje.transform.position + Mesafe, Time.deltaTime * oyunYonetim.KameraHizi);
    }
}
