using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ekranda bulunan Ana Obje'mize ekli script.
public class RifleMan : MonoBehaviour
{
    // instance değişkeni sayesinde dışarıdan bu koda erişim sağlarız.
    public static RifleMan instance;
    public GameObject bullet;
    public Transform spawnPoint;
    public float bulletSpeed;
    public float timeBetweenTwoBullets;
    public bool canShootFirst;
    public bool canShootSecond;
    public bool cansSideShoot;
    public bool canSpawn;
    // UIManager tarafından tetiklenmesini istediğimiz değişkenler.
    public bool isTriggerSideShoot;
    public bool isTriggerFollow;
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Mobil uygulama da denemek için FixedUpdate...
    // Sabit FPS baz aldığı için mobil platformda sorunsuz çalışır.
    void FixedUpdate()
    {
        if (canShootFirst == false && canShootSecond == false && isTriggerFollow == true)
        {
            StartCoroutine(FollowTwoBullets());
        }
        if (canShootFirst == false && cansSideShoot == false && isTriggerSideShoot == true)
        {
            StartCoroutine(RightShoot());
            StartCoroutine(LeftShoot());
        }
        if (canShootFirst == false)
        {
            StartCoroutine(TimeBetweenTwoBullets());
        }
    }
    //Her bir özelliğin Eş-zamanlı çalışma için tek bir float değişkeni(timeBetweenTwoBullets)...
    // Belirlediğim zaman aralıkları için Coroutine ...
    IEnumerator TimeBetweenTwoBullets()
    {
        canShootFirst = true;
        Shoot();
        yield return new WaitForSeconds(timeBetweenTwoBullets * Time.deltaTime);
        canShootFirst = false;
    }
    IEnumerator FollowTwoBullets()
    {
        canShootSecond =true;
        FollowBullet();
        yield return new WaitForSeconds(timeBetweenTwoBullets * Time.deltaTime);
        canShootSecond = false;
    }
    IEnumerator RightShoot()
    {
        cansSideShoot = true;
        RightSideFireShoot();
        yield return new WaitForSeconds(timeBetweenTwoBullets * Time.deltaTime);
        cansSideShoot = false;
    }
    IEnumerator LeftShoot()
    {
        cansSideShoot = true;
        LeftSideFireShoot();
        yield return new WaitForSeconds(timeBetweenTwoBullets * Time.deltaTime);
        cansSideShoot = false;
    }
    // başlangıçta merminin atılması
    private void Shoot()
    {
        GameObject bulletClone = Instantiate(bullet, spawnPoint.transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;
        Rigidbody bulletPrefabRb = bulletClone.GetComponent<Rigidbody>();
        bulletPrefabRb.AddForce(spawnPoint.transform.forward * bulletSpeed*Time.deltaTime, ForceMode.Impulse);
    }
    //Peş-peşe iki mermi
    private void FollowBullet()
    {
        GameObject bulletClone = Instantiate(bullet, spawnPoint.transform.position+new Vector3(0f,0f,-0.098f), Quaternion.Euler(90, 0, 0)) as GameObject;
        Rigidbody bulletPrefabRb = bulletClone.GetComponent<Rigidbody>();
        bulletPrefabRb.AddForce(spawnPoint.transform.forward * bulletSpeed * Time.deltaTime, ForceMode.Impulse);
    }
    //Sağ tarafa 45 derecelik açı 
    public void RightSideFireShoot()
    {
        GameObject bulletClone = Instantiate(bullet, spawnPoint.transform.position, Quaternion.Euler(90, 0, -45)) as GameObject;
        Rigidbody bulletPrefabRb = bulletClone.GetComponent<Rigidbody>();
        bulletPrefabRb.AddForce(new Vector3(45,0,45) * (bulletSpeed/100) * Time.deltaTime, ForceMode.Impulse);
    }
    //Sol tarafa 45 derecelik açı 
    private void LeftSideFireShoot()
    {
        GameObject bulletClone = Instantiate(bullet, spawnPoint.transform.position, Quaternion.Euler(90, 0, 45)) as GameObject;
        Rigidbody bulletPrefabRb = bulletClone.GetComponent<Rigidbody>();
        bulletPrefabRb.AddForce(new Vector3(-45, 0, 45) * (bulletSpeed/100)*Time.deltaTime, ForceMode.Impulse);
    }
}
