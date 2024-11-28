using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryGUI;
    [Space]
    public GameObject mainManager;
    MainManager MM;

    [Space]
    public GameObject[] item;
    public TMP_Text[] ItemText;

    public bool InvOpen;

    void Start()
    {
        MM = mainManager.GetComponent<MainManager>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Tab) && !InvOpen)
        {
            InvOpen = true;
            inventoryGUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            gameObject.GetComponent<PlayerMovement>().enabled = false;
        }
        if (Input.GetKey(KeyCode.Escape) && InvOpen)
        {
            InvOpen = false;
            inventoryGUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            gameObject.GetComponent<PlayerMovement>().enabled = true;
        }

        if (InvOpen)
        {
            Upgrade();
        }
    }

    public void Upgrade()
    {
        if (MM.ScrapWood >= 1)
        {
            item[0].SetActive(true);
            ItemText[0].text = MM.ScrapWood + " ";
        }
        else { item[0].SetActive(false); }


        if (MM.Wood >= 1)
        {
            item[1].SetActive(true);
            ItemText[1].text = MM.Wood + " ";
        }
        else { item[1].SetActive(false); }


        if (MM.ScrapMetal >= 1)
        {
            item[2].SetActive(true);
            ItemText[2].text = MM.ScrapMetal + " ";
        }
        else { item[2].SetActive(false); }


        if (MM.Metal >= 1)
        {
            item[3].SetActive(true);
            ItemText[3].text = MM.Metal + " ";
        }
        else { item[3].SetActive(false); }


        if (MM.Rod >= 1)
        {
            item[4].SetActive(true);
            ItemText[4].text = MM.Rod + " ";
        }
        else { item[4].SetActive(false); }


        if (MM.Plate >= 1)
        {
            item[5].SetActive(true);
            ItemText[5].text = MM.Plate + " ";
        }
        else { item[5].SetActive(false); }

        if (MM.NutsNbolts >= 1)
        {
            item[9].SetActive(true);
            ItemText[9].text = MM.NutsNbolts + " ";
        }
        else { item[9].SetActive(false); }


        if (MM.ReinforcedPlate >= 1)
        {
            item[10].SetActive(true);
            ItemText[10].text = MM.ReinforcedPlate + " ";
        }
        else { item[10].SetActive(false); }
    }
}

