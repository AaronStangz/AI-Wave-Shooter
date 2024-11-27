using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    public float DestroyRange;
    public float Timer;
    public bool UseTimer;
    void Start()
    {
        if (UseTimer) { Destroy(gameObject, Timer); }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
