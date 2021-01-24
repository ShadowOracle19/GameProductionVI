using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI score;
    public GameObject player;
    int scoreNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        score.text = scoreNum.ToString();
    }

    public void AddScore()
    {
        scoreNum += 1;
        
    }
}
