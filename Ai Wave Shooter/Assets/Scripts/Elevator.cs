using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject Player;
    public Transform TopFloor;
    public Transform BottemFloor;

    public bool TF;
    public bool BF;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (TF) {Player.transform.position = BottemFloor.position; }
            if (BF) { Player.transform.position = TopFloor.position; }
            SwapFloors();
        }
    }

    public void SwapFloors()
    {
        if (TF) { BF = true; TF = false; }
        if (BF) { TF = true; BF = false; }
    }

}
