using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISelect : MonoBehaviour
{
    public Button primaryButton;
    public Button menuButton;
    // Start is called before the first frame update
    void Start()
    {

        primaryButton.Select();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void creditButton()
    {
        menuButton.Select();
    }
    
    public void menuButtonSelect()
    {
        primaryButton.Select();
    }
}
