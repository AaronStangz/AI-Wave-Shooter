using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Gun : MonoBehaviour
{
    public Transform FirePoint;
    public int range;
    public GameObject FireFX;
    public GameObject HitPoint;

    [SerializeField] private LayerMask Enemy;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Shooting();
        }

        
    }

    public void Shooting()
    {
        RaycastHit hit;

        if(Physics.Raycast(FirePoint.position , transform.TransformDirection(Vector3.forward) , out hit , range))
        {
            Instantiate(FireFX, FirePoint.position , Quaternion.identity);
            Instantiate(HitPoint, hit.point, Quaternion.identity);
        }
    }

}
