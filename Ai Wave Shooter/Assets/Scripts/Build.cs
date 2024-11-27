using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    public GameObject mainManager;
    MainManager MM;

    public GameObject mainCamera;
    PlayerCam PC;

    public GameObject buildMenu;
    public GameObject buildUI;

    [SerializeField] private LayerMask Built;
    public bool Wood;
    public bool Metal;
    public bool Upgrade;

    void Start()
    {
        MM = mainManager.GetComponent<MainManager>();
        PC = mainCamera.GetComponent<PlayerCam>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Q))
        {
            buildMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            PC.enabled = false;
        }
        else
        {
            buildMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            PC.enabled = true;
        }

        if (Camera.main == null) return;

        RaycastHit hit;

        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 1000);
        if (Physics.SphereCast(ray, 0.5f, out hit, 10, Built))
        {

            if (Built.value == (1 << hit.collider.gameObject.layer))
            {

                OpenBuild OB = hit.collider.GetComponent<OpenBuild>();
                DestroyScript DS = hit.collider.GetComponent<DestroyScript>();
                if (OB != null)
                {
                    if (Wood == true)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            if (hit.distance < OB.buildRange && MM.Wood >= 1)
                            {
                                Debug.Log("Open");
                                OB.BuildWood();

                            }
                        }
                    }

                    if (Metal == true)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            if (hit.distance < OB.buildRange && MM.Metal >= 1)
                            {
                                Debug.Log("Open");
                                OB.BuildMetal();

                            }
                        }
                    }
                }
                if (DS != null)
                {
                    if (Input.GetKeyDown(KeyCode.X))
                    {
                        if (hit.distance < DS.DestroyRange)
                        {
                            Debug.Log("Destroy");
                            DS.DestroyObject();
                        }
                    }
                }
            }
        }
    }

    public void BuildObject()
    {
        Debug.Log("Built");
    }

    public void ButtonWood()
    {
        Wood = true;
        Metal = false;
    }
    public void ButtonMetal()
    {
        Wood = false;
        Metal = true;
    }
}
