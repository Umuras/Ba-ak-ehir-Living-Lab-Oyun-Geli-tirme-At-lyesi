using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oyuncu : MonoBehaviour
{
    public int hiz = 1;

    public GameObject Yol1;
    public GameObject Yol2;

    Rigidbody rigidbody2;
    Animator animator;

    public PanelKontrol panelKontrol;
    public OyunYonetimi oyunYonetim;

    bool YerdeMi;

    public bool MiknatisAktifMi = false;
    public float MiknatisSuresi = 10f;
    public float MiknatisKalanSure = 0f;

    public AudioClip AltinSesi; // Bu değişkene sesi ekliyoruz.
    AudioSource audioSource; // Bu oluşturduğumuz değişken sayesinde de sesimizi çalacağız.
    private void OnCollisionEnter(Collision collision)
    {
        YerdeMi = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name + "Objenin içinden geçtin");

        if (other.gameObject.name == "Nokta1")
        {
            Yol2.transform.position = new Vector3(Yol1.transform.position.x, Yol1.transform.position.y, Yol1.transform.position.z + Yol1.gameObject.GetComponent<Terrain>().terrainData.size.z);

            Debug.Log("Objenin adı Nokta1 imiş");
        }

        else if (other.gameObject.name == "Nokta2")
        {
            Yol1.transform.position = new Vector3(Yol2.transform.position.x, Yol2.transform.position.y, Yol2.transform.position.z + Yol2.gameObject.GetComponent<Terrain>().terrainData.size.z);

            Debug.Log("Objenin adı Nokta2 imiş");
        }
        else if (other.gameObject.tag == "PuanAlinabilir")
        {
            audioSource.PlayOneShot(AltinSesi); // Altın alındığı zaman bir kere bu sesi çalıştır demek bu kod.
            panelKontrol.PuanHesapla();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Miknatis")
        {
            MiknatisAktifMi = true;
            MiknatisKalanSure += MiknatisSuresi;
            panelKontrol.KalanMiknatisSüre.enabled = true;

            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "Engel")
        {
            panelKontrol.BittiPanel.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>(); // audioSource değişkenine AudioSource compenentini atamış oluyoruz. Yani artık değişkenimizle AudioSource Compenentine erişim sağlıyoruz.

        oyunYonetim = GameObject.Find("OyunYonetim").GetComponent<OyunYonetimi>();
    }

    ////private void Awake()
    ////{
    ////    if (Application.platform.ToString() == "Android") // Oyun androidde mi açılmış diye bakar.
    ////    {
    ////        oyunHareket = AndroidHareketKontrol; // Bu şekilde yazarak AndroidHareketKontrol Methodumuzu oyunHareket delagetine atmış oluyoruz.
    ////    }
    ////    else if (Application.platform.ToString() == "PC") // Oyun PC de açılmış mı diye bakar.
    ////    {
    ////        oyunHareket += PCHareketKontrol; //Bu şekilde yazarak tek bir delagete objesinde iki tane fonksiyonu çalıştırabiliyoruz.
    ////        oyunHareket += PCHareketExtra; // Önce PCHareketKontrol çalışıyor, ardından PCHareketExtra kodları.
    ////    }
    ////    // Bu kodları Update kısmından Awake atarak şu kazancı elde ediyoruz: Update kısmında sürekli olarak PC mi android mi diye kontrol yapacağı için
    ////    // Performans sorunu oluşacağından Awake alıyoruz. Ayrıca Awake de bir kere çalışacağından hareket kodları da awake de çalışmayacağından
    ////    // hareket kodlarını delegate atıp onları update fonksiyonuna yazıyoruz.
    ////}

    
    void Update()
    {

        if(MiknatisAktifMi)
        {
            MiknatisKalanSure -= Time.deltaTime;
            panelKontrol.KalanMiknatisSüre.text = "Miknatis Suresi : " + MiknatisKalanSure.ToString("0");
        }

        if(MiknatisKalanSure < 0)
        {
            MiknatisAktifMi = false;
            panelKontrol.KalanMiknatisSüre.enabled = false;
            MiknatisKalanSure = 0;
        }


        Hareket();


       // oyunHareket();
    }


    //delegate void OyunHareket(); //Delegate metodlarımızı temsil eder.
    //OyunHareket oyunHareket; // Bu şekilde değişken oluşturarak bu delegatei kullanabilir hale getirdik. 
    // Bu değişkene void olan ve parametre almayan bütün methodları atayabiliriz.

    //public void AndroidHareketKontrol()
    //{

    //}

    //public void PCHareketKontrol()
    //{

    //}

    //public void PCHareketExtra()
    //{

    //}




    int yon;
    void Hareket()
    {
        transform.Translate(0, 0, oyunYonetim.KarakterHiz * Time.deltaTime);

        if(SimpleInput.GetKeyDown(KeyCode.UpArrow) && YerdeMi)
        {
            YerdeMi = false;
            animator.SetBool("Zipla", true);
            //rigidbody2.velocity = Vector3.up * 300f * Time.deltaTime;
            transform.Translate(0, 2f * Time.deltaTime, 0);

            Invoke("ZiplaIptal", 0.5f);
        }

        if(SimpleInput.GetKeyDown(KeyCode.RightArrow))
        {
            yon = 1;
        }

        if (SimpleInput.GetKeyDown(KeyCode.LeftArrow))
        {
            yon = 2;
        }

        if(SimpleInput.GetKeyDown(KeyCode.DownArrow))
        {
            yon = 3;
        }

        if(yon == 1)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(69f, transform.position.y, transform.position.z), Time.deltaTime * 2f);
        }
        else if (yon == 2)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(50f, transform.position.y, transform.position.z), Time.deltaTime * 2f);
        }
        else if (yon == 3)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(60f, transform.position.y, transform.position.z), Time.deltaTime * 2f);
        }

    }

    void ZiplaIptal()
    {
        animator.SetBool("Zipla", false);
    }
}
