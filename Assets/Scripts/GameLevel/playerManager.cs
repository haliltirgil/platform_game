using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class playerManager : MonoBehaviour
{
    public float health;
    public float bulletSpeed;

    bool ıDead = false;
    bool mouseIsNotOverUI;

    Transform muzzle;  //namlu oluşturuldu

    public Transform bullet, bloodParticle; // kurşun objesi

    public Slider slider;

    public GameObject inGameScreen,pauseScreen,gameOverScreen; // winScreenKod ataması yapılacak

    dataManager dataManager;
    MenuManagerIG menuManagerIG;

    void Start()
    {
        muzzle = transform.GetChild(1); // player'ın içindeki child objesi olan muzzle'a setleme işlemi 
        slider.maxValue = health;
        slider.value = health;  
    }

    // Update is called once per frame
    void Update()
    {
        mouseIsNotOverUI = EventSystem.current.currentSelectedGameObject == null;

        if (Time.timeScale != 0) 
        {
            if (Input.GetMouseButtonDown(0) && mouseIsNotOverUI) // eğer mouse'a basılırsa ateş et. mobil için optimize de edilebilir.
            {
            

                shootBullet();

            }
        }
    }

    public void getDamage(float damage)
    {
        if ((health - damage) >= 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }

        slider.value = health;
        
        amIDead(); // her hasar alındığında hayatta mıyım diye kontrol edecek olan fonksiyon
    }

    public void amIDead() // can değerim 0'ın altına düşerse başta belirlediğim öldüm mü değişkenini true yapan fonksiyon.
    {
        if (health <= 0)
        {
            Destroy(Instantiate(bloodParticle, transform.position, Quaternion.identity), 2f);

            dataManager.Instance.loseProcess();
            ıDead = true;
            Destroy(gameObject);

            gameOverScreen.SetActive(true);
            inGameScreen.SetActive(false);
        }
    }

    void shootBullet()
    {
        Transform tempBullet;
        tempBullet=Instantiate(bullet,muzzle.position,Quaternion.identity);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * bulletSpeed);
        /*
         4 parametre alır. 
            1-> ne oluşturulsun
            2-> nerede oluşturulsun
            3-> rotasyonu ne olsun
            4-> hangi objenin childı olsun
         */
        dataManager.Instance.ShotBullet++; // tutalan datalar için öldürülen düşman sayısı takip edilsin diye arttırma işlemi yapılıyor.
    }
}
