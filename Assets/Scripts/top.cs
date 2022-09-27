using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class top : MonoBehaviour
{
    [SerializeField] GameManager gamemanager;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("topgirdi"))
        {
            
            gameObject.SetActive(false);
            gamemanager.devam_et(transform.position);
        }
        else if (collision.gameObject.CompareTag("gameover"))
        {
            gamemanager.oyun_bitti();
            gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
