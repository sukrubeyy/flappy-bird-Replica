using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class kontrol : MonoBehaviour
{
    public Sprite[] kusSprite;
    SpriteRenderer spriteRenderer;
    bool ileriGeriKontrol = true;
    int kusSayac = 0;
    float kusAnimasyon = 0;
    Rigidbody2D fizik;
    int puan = 0;
    public Text scoreTEXT;
    bool engelkusKontrol = true;
    oyunKontrol oyunKontrol;
    AudioSource []sesler;
    int enYuksekSkor = 0;
    float oyunBaslamaSayac = 0;

    void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        fizik = GetComponent<Rigidbody2D>();
        oyunKontrol = GameObject.FindGameObjectWithTag("oyunkontrol").GetComponent<oyunKontrol>();
        sesler = GetComponents<AudioSource>();
        enYuksekSkor = PlayerPrefs.GetInt("enYuksekPuanKayit");
        Debug.Log("en yuksek skor="+enYuksekSkor);
        fizik.gravityScale = 3;

    }

  
    void Update()
    {
            
            if (Input.GetKeyDown("space") || Input.GetButtonDown("Fire1") && engelkusKontrol)
            {
                fizik.velocity = new Vector2(0, 0);             //hızı 0 yaptık daha sonra aşşağıda kuvvet uyguladık.
                fizik.AddForce(new Vector2(0, 225));
                sesler[0].Play();

            }
            if (fizik.velocity.y > 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 45);
            }
            if (fizik.velocity.y < 0)
            {
                transform.eulerAngles = new Vector3(0, 0, -45);
            }
            Animasyon();
        
        
        
        
            
    }
    void Animasyon()
    {
        kusAnimasyon += Time.deltaTime;
        if (kusAnimasyon > 0.2f)
        {
            kusAnimasyon = 0;
            if (ileriGeriKontrol)
            {
                spriteRenderer.sprite = kusSprite[kusSayac];
                kusSayac++;
                if (kusSayac == kusSprite.Length)
                {
                    kusSayac--;
                    ileriGeriKontrol = false;
                }
            }
            else
            {
                kusSayac--;
                spriteRenderer.sprite = kusSprite[kusSayac];
                if (kusSayac == 0)
                {
                    kusSayac++;
                    ileriGeriKontrol = true;
                }

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag=="puan")
        {
            puan +=10;
            scoreTEXT.text = "Score:"+puan;
            sesler[2].Play();

            if(puan>enYuksekSkor)
            {
                enYuksekSkor = puan;
                PlayerPrefs.SetInt("enYuksekPuanKayit",enYuksekSkor);
            }

        }
        if(col.gameObject.tag=="engel")
        {
            Handheld.Vibrate();
            engelkusKontrol = false;
            sesler[1].Play();
            oyunKontrol.OyunBitti();
            GetComponent<CircleCollider2D>().enabled = false;
            //INVOKE Aşşağıdaki methodu belli bir süre içinde çağırmak için kullanılıyormuş...
            Invoke("anaMenuyeDon", 2);
        }
    }
    void anaMenuyeDon()
    {
        PlayerPrefs.SetInt("puanKayit", puan);
        SceneManager.LoadScene("anaMenu");
    }
}
