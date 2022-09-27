using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class draw : MonoBehaviour
{
    public GameObject LinePrefab;
    public GameObject Line;
    public LineRenderer lineRenderer;
    public EdgeCollider2D edgecollider;
    public List<Vector2> parmakPozisyonListesi;
    public List<GameObject> cizgiler;
    bool ciz;
    int cizme_hakki;
    [SerializeField] TextMeshProUGUI cizme_hakki_Text;
    private void Start()
    {
        ciz = false;
        cizme_hakki = 3;
        cizme_hakki_Text.text = cizme_hakki.ToString();
    }
    void Update()
    {
        if (ciz && cizme_hakki !=0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                cizgi_olustur();
            }
            if (Input.GetMouseButton(0))
            {
                Vector2 parmakpoz = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (Vector2.Distance(parmakpoz, parmakPozisyonListesi[^1]) > .1f)
                {
                    cizgiyi_guncelle(parmakpoz);
                }

            }
        }
        if(cizgiler.Count !=0 && cizme_hakki != 0)
        {
            if (Input.GetMouseButtonUp(0))
            {
                cizme_hakki--;
                cizme_hakki_Text.text = cizme_hakki.ToString();
            }
        }
    
    }
    public void cizme_durdur()
    {
        ciz = false;
    }
    public void cizme_basla()
    {
        ciz = true;
        cizme_hakki = 3;
    }
    void cizgi_olustur()
    {
        Line = Instantiate(LinePrefab, Vector2.zero, Quaternion.identity);
        cizgiler.Add(Line);
        lineRenderer = Line.GetComponent<LineRenderer>();
        edgecollider= Line.GetComponent<EdgeCollider2D>();
        parmakPozisyonListesi.Clear();
        parmakPozisyonListesi.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        parmakPozisyonListesi.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        lineRenderer.SetPosition(0, parmakPozisyonListesi[0]);
        lineRenderer.SetPosition(1, parmakPozisyonListesi[1]);
        edgecollider.points = parmakPozisyonListesi.ToArray();
    }
    void cizgiyi_guncelle(Vector2 gelenParmakPoz)
    {
        parmakPozisyonListesi.Add(gelenParmakPoz);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, gelenParmakPoz);
        edgecollider.points = parmakPozisyonListesi.ToArray();
    }



    public void devam_et()
    {
        if (Top_firlat.atilan_top_Sayisi == 0)
        {
            foreach (var item in cizgiler)
            {
                Destroy(item.gameObject);
            }
            cizgiler.Clear();
            cizme_hakki = 3;
            cizme_hakki_Text.text = cizme_hakki.ToString();

        }

     
    }
}
