using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public Transform spawnPoint;


    public void OnResetButtonPressed()
    {
        GameManager.instance.player.transform.position = spawnPoint.transform.position;
    }

    public void onPlayButtonPressed()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void onQuitButtonPressed()
    {
        Application.Quit();
    }
    
    public void onCreditButtonPressed()
    {
        SceneManager.LoadScene("Credits");
    }
    
    public void onMenuButtonPressed()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;

    }
}
