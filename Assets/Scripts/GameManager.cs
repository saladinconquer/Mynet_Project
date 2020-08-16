using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ekranda oluşturduğumuz boş bir GameObject'e ekli script...
public class GameManager : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public int cameraIndex;
    public GameObject rifleManOriginal;
    //Ekranda bulunan Spawn butonuna eklenmiş Method...
    public void Spawn()
    {
        // Karakterimizin kopyasını oluşturma
        GameObject rifleManClone = Instantiate(rifleManOriginal, new Vector3(-1, 0, 0), Quaternion.Euler(-90, 0, 0));
        // Ana objenin sahip olduğu değişkenlerin değer kayıtlarının clone objeye aktarılması .
        // UIManager-Update kısmında güncel olarak bilgiler kayıt edilmişti.
        rifleManClone.GetComponent<RifleMan>().bulletSpeed = PlayerPrefs.GetFloat("bulletSpeed");
        rifleManClone.GetComponent<RifleMan>().timeBetweenTwoBullets = PlayerPrefs.GetFloat("timeBetweenTwoBullets");
        rifleManClone.GetComponent<RifleMan>().isTriggerSideShoot = PlayerPrefs.GetInt("isTriggerSide") > 0;
        rifleManClone.GetComponent<RifleMan>().isTriggerFollow = PlayerPrefs.GetInt("isTriggerFollow") > 0;
    }
    // Ekranda bulunan Change Camera isimli butonumuza her tıkladığımızda kamera açısının belirlenen iki kamera arasındaki değişimi .
    public void ChangeCamera()
    {
        cameraIndex++;
        if (cameraIndex % 2 == 0)
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
        }
        else if (cameraIndex % 2 == 1)
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
        }
    }
}
