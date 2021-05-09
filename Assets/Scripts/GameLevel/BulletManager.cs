using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public float bulletDamage;
    public float lifeTime;
    void Start()
    {
        Destroy(gameObject, lifeTime); // bu oyun objesini belirtilen ikinci parametre süresinde yok eder.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
