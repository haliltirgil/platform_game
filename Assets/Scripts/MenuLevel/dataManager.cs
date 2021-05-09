using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TigerForge;


public class dataManager : MonoBehaviour
{
    public static dataManager Instance;



    private int shotBullet;
    public int totalshotBullet;
    private int enemyKilled;
    public int totalEnemyKilled;

    playerManager playerManager;

    EasyFileSave myFile;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            startProcess();
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int ShotBullet
    {
        get
        {
            return shotBullet;
        }
        set
        {
            shotBullet = value;
            GameObject.Find("shotBulledText").GetComponent<Text>().text = "SHOT BULLET : " + shotBullet.ToString();
        }
    }

    public int EnemyKilled
    {
        get
        {
            return enemyKilled;
        }
        set
        {
            enemyKilled = value;
            GameObject.Find("enemyKilledText").GetComponent<Text>().text = "KILLED ENEMY : " + enemyKilled.ToString();
            winProcess();
        }
    }


    //-------------------------------------------------------------------
    // buradan aşağıya açıklama eklenecek unutmamak için
    void startProcess()
    {
        myFile = new EasyFileSave();
        loadData();
    }

    public void saveData()
    {
        totalshotBullet += shotBullet;
        totalEnemyKilled += enemyKilled;

        myFile.Add("totalShotBullet", totalshotBullet);
        myFile.Add("totalEnemyKilled", totalEnemyKilled);

        myFile.Save();
    }

    public void loadData()
    {
        if (myFile.Load())
        {
            totalshotBullet = myFile.GetInt("totalShotBullet");
            totalEnemyKilled = myFile.GetInt("totalEnemyKilled");
        }
    }

    public void winProcess()
    {
        if (enemyKilled >= 44)
        {
            print("YOU WIN ! ! !");
        }
    }

    public void loseProcess()
    {

        print("YOU LOST ! ! !");

    }
}
