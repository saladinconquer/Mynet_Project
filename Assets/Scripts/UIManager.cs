using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Oyunumuz Menü ve Game sahnelerinden oluşmaktadır.
// Canvas'a ekli script...
public class UIManager : MonoBehaviour
{
    //Ekrandaki butonların aktif/pasif durumları için oluşturulmuş değişkenler...
    public Button[] buttons;
    public int canClickButtons;
    private void Update()
    {
        //Bu script hiyerarşi kısmında bulunan Canvas'a ekli olduğundan , Menü sahnesinde de  çalışacaktır.
        // Menü sahnesinde değilde Game sahnesinde butonlarımız bulunmakta dolayısıyla if yardımıyla kodumuzun çalışması gereken yeri belirttik .
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName=="Game")
        {
            //PlayerPrefs aracılığıyla Ana Obje'mizin değişken değerlerini kayıt altına aldık .
            PlayerPrefs.SetFloat("timeBetweenTwoBullets", RifleMan.instance.timeBetweenTwoBullets);
            PlayerPrefs.SetFloat("bulletSpeed", RifleMan.instance.bulletSpeed);
            //PlayerPrefs direkt olarak bool değişkeni (true-false) kaydı yapmadığından tanımlamayla kayıt altına aldık . 
            PlayerPrefs.SetInt("isTriggerSide", RifleMan.instance.isTriggerSideShoot ? 1 : 0);
            PlayerPrefs.SetInt("isTriggerFollow", RifleMan.instance.isTriggerFollow ? 1 : 0);
            foreach (var i in buttons)
            {
                // Eğer tıklanan butonların sayısı 3 ise tüm butonları pasif hale getir.
                if (canClickButtons == 3)
                {
                    i.interactable = false;
                }
            }
        }

    }
    // Başla(Menü) ve Exit(Game) butonlarına eklenmiş Method...
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    //Quit(Menü) butonuna eklenmiş Method...
    public void QuitGame()
    {
        Application.Quit();
    }
    // 5.(Klon oluşturma) butonumuza ekli Method...
    public void Spawn()
    {
        buttons[4].interactable = false;
        canClickButtons++;
    }
    // 1.(45 derecelik açıyla) butonumuza ekli Method...
    public void AngleShoot()
    {
        RifleMan.instance.isTriggerSideShoot = true;
        buttons[0].interactable = false;
        canClickButtons++;
    }
    // 2.(Peş-Peşe) butonumuza ekli Method...
    public void FollowBullet()
    {
        RifleMan.instance.isTriggerFollow = true;
        buttons[1].interactable = false;
        canClickButtons++;
    }
    // 3.(Hızı bir saniyeye düşürme) butonumuza ekli Method...
    public void OneSecond()
    {
        RifleMan.instance.timeBetweenTwoBullets = RifleMan.instance.timeBetweenTwoBullets / 2;
        buttons[2].interactable = false;
        canClickButtons++;

    }
    //4.(Hızı yüzde elli düşürme) butonumuza ekli Method...
    public void FiftyPercent()
    {
        RifleMan.instance.bulletSpeed = RifleMan.instance.bulletSpeed + (RifleMan.instance.bulletSpeed / 2);
        buttons[3].interactable = false;
        canClickButtons++;
    }
}
