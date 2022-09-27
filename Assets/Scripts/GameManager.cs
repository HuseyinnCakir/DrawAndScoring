using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Top_firlat topfirlat;
    [SerializeField] draw cizgiciz;

    [SerializeField] ParticleSystem sayi;
    [SerializeField] ParticleSystem best_score_Gecilirse;
    [SerializeField] AudioSource[] sesler;
    [SerializeField] TextMeshProUGUI[] scoretexler;
    [SerializeField] GameObject[] paneller;
     int giren_top_sayisi;
    void Start()
    {
        giren_top_sayisi = 0;
        if (PlayerPrefs.HasKey("bestscore"))
        {
            scoretexler[0].text = PlayerPrefs.GetInt("bestscore").ToString();
            scoretexler[1].text = PlayerPrefs.GetInt("bestscore").ToString();
        }
        else
        {
            PlayerPrefs.SetInt("bestscore", 0);
            scoretexler[0].text = "0";
            scoretexler[1].text = "0";
        }
    }
    public void devam_et(Vector2 pozisyon)
    {
        sayi.transform.position = pozisyon;
        sayi.gameObject.SetActive(true);
        sayi.Play();
        giren_top_sayisi++;
        topfirlat.devam_et();
        cizgiciz.devam_et();
    }
    public void oyun_Basla()
    {
        paneller[0].SetActive(false);
        paneller[1].SetActive(false);
        paneller[3].SetActive(true);
        topfirlat.oyunBaslasin();
        cizgiciz.cizme_basla();
    }
    public void tekrar_oyna()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void oyun_bitti()
    {

        paneller[2].SetActive(true);
        paneller[3].SetActive(false);
        scoretexler[1].text = PlayerPrefs.GetInt("bestscore").ToString();
        scoretexler[2].text = giren_top_sayisi.ToString();
       
        if (giren_top_sayisi>PlayerPrefs.GetInt("bestscore"))
        {
            PlayerPrefs.SetInt("bestscore", giren_top_sayisi);
            best_score_Gecilirse.gameObject.SetActive(true);
            best_score_Gecilirse.Play();
        }
        cizgiciz.cizme_durdur();
        topfirlat.top_atma_durdur();
    }
}
