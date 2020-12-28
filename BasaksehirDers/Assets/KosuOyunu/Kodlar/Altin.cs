using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altin : MonoBehaviour
{
    public Oyuncu Fare;
    void Start()
    {
        Fare = GameObject.Find("BüyükFare").GetComponent<Oyuncu>();
    }

    float mesefa;
    void Update()
    {
        
        if(Fare.MiknatisAktifMi)
        {
            mesefa = Vector3.Distance(transform.position, Fare.gameObject.transform.position);

            if(mesefa < 20f)
            {
                transform.position = Vector3.MoveTowards(transform.position, Fare.gameObject.transform.position, Time.deltaTime * 20f);
            }

        }
    }
}
