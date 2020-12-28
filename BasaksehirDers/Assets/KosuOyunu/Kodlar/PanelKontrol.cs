using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelKontrol : MonoBehaviour
{
    public Text PuanText;
    int PuanDurumu = 0;

    public Text KalanMiknatisSüre;
    public GameObject BittiPanel;

    public Text GecenSureText;

    public void ResetButton()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("KosuOyunu");
    }

    public void CikisButton()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    public void PuanHesapla()
    {
        PuanDurumu += 5;
        PuanText.text = "Puan : " + PuanDurumu;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
