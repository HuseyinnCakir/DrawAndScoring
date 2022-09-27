using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top_firlat : MonoBehaviour
{
    [SerializeField] private GameObject[] toplar;
    [SerializeField] private GameObject[] kova_noktalari;
    [SerializeField] private GameObject top_atma_merkezi;
    [SerializeField] private GameObject kova;
    int aktif_top_index;
    int random_kova_noktasi_index;
    bool kilit;
    public static int atilan_top_Sayisi;
    public static int top_atis_Sayisi;
    private void Start()
    {
        top_atis_Sayisi = 0;
        atilan_top_Sayisi = 0;
    }
    public void oyunBaslasin()
    {
        StartCoroutine(top_Atis_sistemi());
    }
    IEnumerator top_Atis_sistemi()
    {
        while (true)
        {
            if (!kilit)
            {
                yield return new WaitForSeconds(.5f);
              
                
                if(top_atis_Sayisi != 0 && top_atis_Sayisi % 5 == 0)
                {
                    for (int i = 0; i <2; i++)
                    {
                        toplar[aktif_top_index].transform.position = top_atma_merkezi.transform.position;
                        toplar[aktif_top_index].SetActive(true);

                        toplar[aktif_top_index].GetComponent<Rigidbody2D>().AddForce(poz_Ver(aci_Ver(70f, 110f)) * 750);

                        if (aktif_top_index != toplar.Length - 1)
                        {
                            aktif_top_index++;
                        }
                        else
                        {
                            aktif_top_index = 0;
                        }
                    }
                   
                    atilan_top_Sayisi = 2;
                    top_atis_Sayisi++;
                }
                else
                {
                    toplar[aktif_top_index].transform.position = top_atma_merkezi.transform.position;
                    toplar[aktif_top_index].SetActive(true);

                    toplar[aktif_top_index].GetComponent<Rigidbody2D>().AddForce(poz_Ver(aci_Ver(70f, 110f)) * 750);
                    if (aktif_top_index != toplar.Length - 1)
                    {
                        aktif_top_index++;
                    }
                    else
                    {
                        aktif_top_index = 0;
                    }
                    atilan_top_Sayisi = 1;
                    top_atis_Sayisi++;
                }

                yield return new WaitForSeconds(0.6f);

                random_kova_noktasi_index = Random.Range(0, kova_noktalari.Length - 1);
                kova.transform.position = kova_noktalari[random_kova_noktasi_index].transform.position;
                kova.SetActive(true);
                kilit = true;
                Invoke("top_kontrol_Et", 5f);
            }
            else
            {
                yield return null;
            }
        }
    }
   float aci_Ver(float aci,float aci2)
    {
        return  Random.Range(aci, aci2);
    }
    Vector3 poz_Ver(float gelen_aci)
    {
        return Quaternion.AngleAxis(gelen_aci, Vector3.forward) * Vector3.right;
    }
    void top_kontrol_Et()
    {
        if (kilit)
        {
            GetComponent<GameManager>().oyun_bitti();
        }
    }
public void devam_et()
    {
        if (atilan_top_Sayisi == 1)
        {
            kilit = false;
            kova.SetActive(false);
            CancelInvoke();
            atilan_top_Sayisi--;
        }
        else
            atilan_top_Sayisi--;
       
    }
    public void top_atma_durdur()
    {
        StopAllCoroutines();
    }
 
}
