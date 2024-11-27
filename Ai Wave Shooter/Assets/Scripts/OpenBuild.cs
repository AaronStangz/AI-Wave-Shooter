using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBuild : MonoBehaviour
{
    public GameObject mainManager;
    MainManager MM;

    public float buildRange;
    public bool Open;

    public Transform buildPoint;

    public GameObject WoodBuild;
    public GameObject MetalBuild;

    void Start()
    {
        mainManager = GameObject.Find("Main Manager");
        MM = mainManager.GetComponent<MainManager>();
        Open = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (mainManager = null)
        {
            mainManager = GameObject.Find("Main Manager");
        }
    }

    public void BuildWood()
    {
        Debug.Log("Built");
        if (Open == true)
        {
            Instantiate(WoodBuild, buildPoint.transform.position, buildPoint.transform.rotation);
            MM.Wood -= 1;
            Open = false;
        }
    }

    public void BuildMetal()
    {
        Debug.Log("Built");
        if (Open == true)
        {
            Instantiate(MetalBuild, buildPoint.transform.position, buildPoint.transform.rotation);
            MM.Metal -= 1;
            Open = false;
        }
    }
}
