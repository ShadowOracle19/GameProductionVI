using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public int aliveTime;
    private void Awake()
    {
        Destroy(gameObject, aliveTime * 2);
    }
}
