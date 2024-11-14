using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] private LayerMask Interactable;
    [SerializeField] private LayerMask Collectable;
    [SerializeField] private LayerMask Built;
    [SerializeField] private LayerMask Hub;

    MainManager IM;
    public GameObject mainManager;
    public GameObject player;

    void Start()
    {
        IM = mainManager.GetComponent<MainManager>();

    }

    void Update()
    {
        if (Camera.main == null) return;

        RaycastHit hit;

        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 1000);
        if (Physics.SphereCast(ray, 0.5f, out hit, 10, Interactable + Collectable + Built + Hub))
        {
            if (Collectable.value == (1 << hit.collider.gameObject.layer))
            {

                Collect CL = hit.collider.GetComponent<Collect>();
                if (CL != null)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (hit.distance < CL.pickUpRange)
                        {
                            Debug.Log("Open");
                            CL.CollectItem();
                        }
                    }
                }

            }

            if (Hub.value == (1 << hit.collider.gameObject.layer))
            {

                Hub HB = hit.collider.GetComponent<Hub>();
                if (HB != null)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (hit.distance < HB.openRange)
                        {
                            Debug.Log("Open");
                            HB.Open();
                        }
                    }
                }

            }
        }
    }
}
