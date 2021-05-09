using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineManager : MonoBehaviour
{
    playerController playerController;
   
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<playerController>().jumpMove(8f);
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<playerController>().jumpMove(8f);
        }
    }

}
