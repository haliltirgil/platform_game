using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public float health;
    public float damage;

    bool colliderBusy = false;

    public Slider slider;   

    void Start()
    {
        slider.maxValue= health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) // obje collider alanına giriş anında çalışan fonksiyondur
    {
        if (other.tag == "Player" && !colliderBusy) //objeye girildiği anda playerManager scriptindeki getDamage metodunu çağırıp ana karakterin canını azaltır. 
        {
            colliderBusy = true;
            other.GetComponent<playerManager>().getDamage(damage);
        }

        else if (other.tag=="Bullet")
        {
            getDamage(other.GetComponent<BulletManager>().bulletDamage);
            Destroy(other.gameObject);
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) // obje colliderının içinden çıkış anındaki framede çalışan fonksiyondur
    {
        if (other.tag == "Player") 
        {
            colliderBusy = false;
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

    void amIDead() // can değerim 0'ın altına düşerse başta belirlediğim öldüm mü değişkenini true yapan fonksiyon.
    {
        if (health <= 0)
        {
            dataManager.Instance.EnemyKilled++; // ölen düşman sayısını bu satır sayesinde veritabanımızda tutuyoruz 
            // burada sıkıntı var objeyi silmeyi engelliyor düzeltilecek.

            Destroy(gameObject); // script hangi objede kullanılırsa o obje sahneden silinir.
        }
    }


}
