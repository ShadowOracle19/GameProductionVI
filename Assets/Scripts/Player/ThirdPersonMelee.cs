using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMelee : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            Attack();
        }
    }

    void Attack()
    {

    }
}
