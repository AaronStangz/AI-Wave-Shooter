using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public GameObject mainManager;
    MainManager MM;

    public int pickUpRange;
    [Space]
    public int GivePlanks;
    public int GiveScrapPlanks;
    public int GiveMetal;
    public int GiveScrapMetal;
    [Space]
    public int GiveXP;
    void Start()
    {
        mainManager = GameObject.Find("Main Manager");
        MM = mainManager.GetComponent<MainManager>();
    }

    public void CollectItem()
    {
        MM.Xp += GiveXP;
        MM.Metal += GiveMetal;
        MM.ScrapMetal += GiveScrapMetal;
        Destroy(gameObject);
    }
}
