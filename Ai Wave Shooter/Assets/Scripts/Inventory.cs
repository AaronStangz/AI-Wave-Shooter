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


        if (MM.Copper >= 1)
        {
            item[6].SetActive(true);
            ItemText[6].text = MM.Copper + " ";
        }
        else { item[6].SetActive(false); }


        if (MM.CopperWire >= 1)
        {
            item[7].SetActive(true);
            ItemText[7].text = MM.CopperWire + " ";
        }
        else { item[7].SetActive(false); }


        if (MM.MetalWire >= 1)
        {
            item[8].SetActive(true);
            ItemText[8].text = MM.MetalWire + " ";
        }
        else { item[8].SetActive(false); }


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


        if (MM.MetalSheet >= 1)
        {
            item[11].SetActive(true);
            ItemText[11].text = MM.MetalSheet + " ";
        }
        else { item[11].SetActive(false); }


        if (MM.ReinforcedRod >= 1)
        {
            item[12].SetActive(true);
            ItemText[12].text = MM.ReinforcedRod + " ";
        }
        else { item[12].SetActive(false); }


        if (MM.MetalBeam >= 1)
        {
            item[13].SetActive(true);
            ItemText[13].text = MM.MetalBeam + " ";
        }
        else { item[13].SetActive(false); }


        if (MM.HardenMetal >= 1)
        {
            item[14].SetActive(true);
            ItemText[14].text = MM.HardenMetal + " ";
        }
        else { item[14].SetActive(false); }


        if (MM.ReinforcedWire >= 1)
        {
            item[15].SetActive(true);
            ItemText[15].text = MM.ReinforcedWire + " ";
        }
        else { item[15].SetActive(false); }


        if (MM.ReinforcedNutsNBolts >= 1)
        {
            item[16].SetActive(true);
            ItemText[16].text = MM.ReinforcedNutsNBolts + " ";
        }
        else { item[16].SetActive(false); }


        if (MM.ReinforcedBeam >= 1)
        {
            item[17].SetActive(true);
            ItemText[17].text = MM.ReinforcedBeam + " ";
        }
        else { item[17].SetActive(false); }
    }
}

