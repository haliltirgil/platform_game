using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerIG : MonoBehaviour
{
    public GameObject inGameScreen, pauseScreen;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pauseButton()
    {
        Time.timeScale = 0; // oyun içindeki süreyi durdurur
         
        inGameScreen.SetActive(false); // in game screen kapanacak 
        pauseScreen.SetActive(true); // pause screen açılacak.
    }

    public void playButton()
    {
        Time.timeScale = 1; // oyun içindeki zaman akmaya devam eder
 
        pauseScreen.SetActive(false); // pause screen açılacak.
        inGameScreen.SetActive(true); // in game screen kapanacak
    }

    public void rePlayButton()
    {
        Time.timeScale = 1; // // pause butonuna basıldığında zaman inaktif edildiği için onu aktif etmem gerekiyor

        SceneManager.LoadScene(1);
    }

    public void homeButton()
    {
        Time.timeScale = 1; // pause butonuna basıldığında zaman inaktif edildiği için onu aktif etmem gerekiyor

        dataManager.Instance.saveData();

        SceneManager.LoadScene(0);
    }
}
