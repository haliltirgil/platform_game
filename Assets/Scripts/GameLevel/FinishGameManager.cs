using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGameManager : MonoBehaviour
{
    playerManager playerManager;

    public GameObject winScreen;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") 
        {
            winScreen.SetActive(true);
            playerManager.inGameScreen.SetActive(false);
        }
    }
}
