using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderManager : MonoBehaviour
{
    bool waitingForContinue = false;

    private void OnTriggerEnter(Collider other)
    {
        //End of Game if player fall
        if(other.CompareTag("GameOver"))
            SceneManager.LoadScene("MainScene");

        //if reach final platform wait for reload
        if (other.CompareTag("FinalPlatform"))
        {
            Time.timeScale = 0;
            waitingForContinue = true;
        }
    }

    private void Update()
    {
        if(waitingForContinue && Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("MainScene");
        }
    }
}
