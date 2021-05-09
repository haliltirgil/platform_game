using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuManager : MonoBehaviour
{
    public GameObject dataBoard,infoBoard;

    public Button pButton, dButton, iButton, eButton;
    void Start()
    {
        /*
        dButton.interactable = true;
        infButton.interactable = true;
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playButton()
    {
        SceneManager.LoadScene(1);
    }

    public void dataBoardButton()
    {
        dataManager.Instance.loadData();

        dataBoard.transform.GetChild(1).GetComponent<Text>().text="TOTAL SHOT BULLET : " + dataManager.Instance.totalshotBullet.ToString();
        dataBoard.transform.GetChild(2).GetComponent<Text>().text ="TOTAL ENEMY KILLED : " + dataManager.Instance.totalEnemyKilled.ToString();

        pButton.interactable = false;
        iButton.interactable = false;
        eButton.interactable = false;

        dataBoard.SetActive(true);
        
     }

    public void dataBoardBackButton()
    {
        dataBoard.SetActive(false);

        pButton.interactable = true;
        iButton.interactable = true;
        eButton.interactable = true;
    }

    public void infoButton()
    {
        pButton.interactable = false;
        dButton.interactable = false;
        eButton.interactable = false;

        infoBoard.SetActive(true);
    }

    public void infoBoardBackButton()
    {
        infoBoard.SetActive(false);

        pButton.interactable = true;
        dButton.interactable = true;
        eButton.interactable = true;
    }

    public void exitButton()
    {
        Application.Quit();
    }
}
