using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public Transform spawnPoint;


    public void OnResetButtonPressed()
    {
        GameManager.instance.player.transform.position = spawnPoint.transform.position;
    }
}
