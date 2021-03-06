using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class oyunKontrol : MonoBehaviour
{
    public GameObject gokyuzubir;
    public GameObject gokyuzuiki;
    Rigidbody2D fizikBir;
    Rigidbody2D fizikIki;
    public float arkaPlanHiz = 1.5f;
    float uzunluk;
    public GameObject engel;
    public int kactaneEngelolsun;
    GameObject[] engeller;
    Rigidbody2D engellerFizik;
    float degisimZaman = 0;
    int sayac = 0;
    bool oyunBittiKontrol= true;
    void Start()
    {
        fizikBir = gokyuzubir.GetComponent<Rigidbody2D>();
        fizikIki = gokyuzuiki.GetComponent<Rigidbody2D>();
        fizikBir.velocity = new Vector2(arkaPlanHiz, 0);
        fizikIki.velocity = new Vector2(arkaPlanHiz, 0);
        uzunluk = gokyuzubir.GetComponent<BoxCollider2D>().size.x;

        engeller = new GameObject[kactaneEngelolsun];
        for(int i =0; i<engeller.Length; i++)
        {
            engeller[i] = Instantiate(engel,new Vector2(-20,-20),Quaternion.identity);
            engellerFizik = engeller[i].AddComponent<Rigidbody2D>();
            engellerFizik.gravityScale = 0;
            engellerFizik.velocity = new Vector2(arkaPlanHiz,0);
        }
        
    }
    void Update()
    {
        
        if (oyunBittiKontrol)
        {
            if (gokyuzubir.transform.position.x <= -uzunluk)
            {
                gokyuzubir.transform.position += new Vector3(uzunluk * 2, 0);
            }
            if (gokyuzuiki.transform.position.x <= -uzunluk)
            {
                gokyuzuiki.transform.position += new Vector3(uzunluk * 2, 0);
            }
            degisimZaman += Time.deltaTime;
            if (degisimZaman > 3f)
            {
                degisimZaman = 0;
                float yEksenim = Random.Range(-0.30f, 1.29f);
                engeller[sayac].transform.position = new Vector3(11, yEksenim);
                sayac++;

                if (sayac >= engeller.Length)
                {
                    sayac = 0;
                }

            }
        }
        else
        {
            //burayı doldurcaz.
            Debug.Log("Else Durumu.");
        }
    }
    public void OyunBitti()
    {
        for (int i = 0; i <engeller.Length; i++)
        {
            engeller[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            fizikBir.velocity = Vector2.zero;
            fizikIki.velocity = Vector2.zero;
        }
        oyunBittiKontrol = false;
    }
}
