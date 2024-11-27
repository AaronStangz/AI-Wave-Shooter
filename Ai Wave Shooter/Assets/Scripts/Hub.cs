using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Unity.UI;
using TMPro;

public class Hub : MonoBehaviour
{
    public int maxHealth;
    public int curHealth;
    [SerializeField] private LayerMask whatIsEnemy;
    public float attackRange;
    public bool enemyInRange;
    
    public GameObject mainManager;
    MainManager MM;

    public int openRange;
    public bool HubOpen;

    public TMP_Text[] RText;
    public GameObject[] TeirPage;
    public GameObject[] TeirButons;
    public GameObject Teir0;
    public GameObject Teir1;
    public GameObject Teir2;
    public GameObject Teir3;
    public GameObject Teir4;
    public GameObject Teir5;
    public GameObject Teir6;
    public GameObject Teir7;
    public GameObject Teir8;
    public GameObject Teir9;

    public GameObject HubGUI;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        MM = mainManager.GetComponent<MainManager>();
    }

    void Update()
    {
        enemyInRange = Physics.CheckSphere(transform.position, attackRange, whatIsEnemy);
        if (enemyInRange) { AttackEnemy(); }

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

    public void AttackEnemy()
    {
        curHealth -= 10;
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

        RText[3].text = " " + MM.ReinforcedPlate + " / " + "10 ";
        RText[4].text = " " + MM.ReinforcedRod + " / " + "25 ";
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
        if (MM.Rod >= 25 && MM.Plate >= 10)
        {
            MM.Rod -= 25;
            MM.Plate -= 10;           
            TeirButons[3].SetActive(true);
            Teir2.SetActive(true);
        }
    }

    public void UpgradeTeir3()
    {
        if (MM.Rod >= 50 && MM.ReinforcedPlate >= 10 && MM.CopperWire >= 15)
        {
            MM.Rod -= 50;
            MM.ReinforcedPlate -= 10;
            MM.CopperWire -= 15;
            Teir3.SetActive(true);
            TeirButons[4].SetActive(true);
        }
    }

    public void UpgradeTeir4()
    {
        if (MM.ReinforcedPlate >= 10 && MM.ReinforcedRod >= 25)
        {
            MM.ReinforcedPlate -= 10;
            MM.ReinforcedRod -= 25;
            Teir4.SetActive(true);
            TeirButons[5].SetActive(true);
        }
    }

    public void UpgradeTeir5()
    {
        if (MM.Rod >= 25 && MM.Plate >= 10)
        {
            MM.Rod -= 25;
            MM.Plate -= 10;
            Teir5.SetActive(true);
            TeirButons[6].SetActive(true);
        }
    }

    public void UpgradeTeir6()
    {
        if (MM.Rod >= 25 && MM.Plate >= 10)
        {
            MM.Rod -= 25;
            MM.Plate -= 10;
            Teir6.SetActive(true);
            TeirButons[7].SetActive(true);
        }
    }

    public void UpgradeTeir7()
    {
        if (MM.Rod >= 25 && MM.Plate >= 10)
        {
            MM.Rod -= 25;
            MM.Plate -= 10;
            Teir7.SetActive(true);
            TeirButons[8].SetActive(true);
        }
    }

    public void UpgradeTeir8()
    {
        if (MM.Rod >= 25 && MM.Plate >= 10)
        {
            MM.Rod -= 25;
            MM.Plate -= 10;
            Teir8.SetActive(true);
            TeirButons[9].SetActive(true);
        }
    }

    public void UpgradeTeir9()
    {
        if (MM.Rod >= 25 && MM.Plate >= 10)
        {
            MM.Rod -= 25;
            MM.Plate -= 10;
            Teir9.SetActive(true);
        }
    }
}
