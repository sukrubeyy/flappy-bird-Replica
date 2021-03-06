using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class anaMenu : MonoBehaviour
{
    public Text scoreTEXT;
    public Text puanTEXT;
    int skoreSayaci;
    int puanTutucu;
  
    void Start()
    {
        skoreSayaci = PlayerPrefs.GetInt("enYuksekPuanKayit");
        puanTutucu = PlayerPrefs.GetInt("puanKayit");
        scoreTEXT.text = "EN YÜKSEK SKOR:" + skoreSayaci;
        puanTEXT.text = "Puan:" + puanTutucu;
    }

   
    void Update()
    {
        
    }
    public void oyunaGit()
    {
        SceneManager.LoadScene("1");
    }
    
   public void Quit()
    {
        Application.Quit();
    }
    
    public void sifirla()
    {
        PlayerPrefs.DeleteAll();
    }
}
