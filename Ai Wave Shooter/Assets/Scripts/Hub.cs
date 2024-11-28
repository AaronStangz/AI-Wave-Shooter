using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Unity.UI;
using TMPro;

public class Hub : MonoBehaviour
{
    public GameObject mainManager;
    MainManager MM;
    [Space]
    public int openRange;
    public bool HubOpen;
    [Space]
    public TMP_Text[] RText;
    [Space]
    public GameObject[] TeirPage;
    [Space]
    public GameObject[] TeirButons;
    [Space]
    public GameObject Teir0;
    public GameObject Teir1;
    public GameObject Teir2;
    public GameObject Teir3;
    [Space]
    public GameObject HubGUI;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        MM = mainManager.GetComponent<MainManager>();
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.Escape) && HubOpen)
        {
            HubOpen = false;
            HubGUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Player.GetComponent<PlayerMovement>().enabled = true;
        }
        if (HubOpen == true )
        {
            TextUpdate();
        }
    }

    public void Open()
    {
        HubOpen = true;
        HubGUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Player.GetComponent<PlayerMovement>().enabled = false;
    }

    public void ToggleTeirPage(int indexToEnable)
    {
        for (int i = 0; i < TeirPage.Length; i++)
        {
            TeirPage[i].SetActive(indexToEnable == i);
            Debug.Log("ToggleTeirPage");
        }
    }

    public void TextUpdate()
    {
        RText[0].text = " " + MM.Metal + " / " + "10 ";

        RText[1].text = " " + MM.Rod + " / " + "25 ";
        RText[2].text = " " + MM.Plate + " / " + "10 ";

        RText[3].text = " " + MM.Plate + " / " + "20 ";
        RText[1].text = " " + MM.NutsNbolts + " / " + "60 ";

        RText[3].text = " " + MM.ReinforcedPlate + " / " + "10 ";
        RText[1].text = " " + MM.Rod + " / " + "30 ";
    }

    public void UpgradeTeir0()
    {
        if(MM.Metal >= 10)
        {
            MM.Metal -= 10;
            Teir0.SetActive(true);
            TeirButons[1].SetActive(true);
        }
    }

    public void UpgradeTeir1()
    {
        if(MM.Rod >= 25 && MM.Plate >= 10) 
        { 
            MM.Rod -= 25;
            MM.Plate -= 10;
            Teir1.SetActive(true);
            TeirButons[2].SetActive(true);
        }
    }

    public void UpgradeTeir2()
    {
        if (MM.Plate >= 20 && MM.NutsNbolts >= 60)
        {
            MM.Plate += 20;
            MM.NutsNbolts -= 60;
            TeirButons[3].SetActive(true);
            Teir2.SetActive(true);
        }
    }

    public void UpgradeTeir3()
    {
        if (MM.ReinforcedPlate >= 10 && MM.Rod >= 30)
        {
            MM.ReinforcedPlate -= 10;
            MM.Rod += 30;
            Teir3.SetActive(true);
            TeirButons[4].SetActive(true);
        }
    }
}
