using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftingTable : MonoBehaviour
{
    public GameObject mainManager;
    MainManager MM;
    [Space]
    public GameObject mainCamera;
    PlayerCam PC;
    [Space]
    public GameObject[] Sidebars;
    [Space]
    public Slider ScrapWoodToWoodSlider;
    public TMP_Text ScrapWoodToWoodText;
    [Space]
    public Slider ScrapMetalToMetalSlider;
    public TMP_Text ScrapMetalToMetalText;
    [Space]
    public Slider MetalToRodSlider;
    public TMP_Text MetalToRodText;
    [Space]
    public Slider MetalToPlateSlider;
    public TMP_Text MetalToPlateText;
    [Space]
    public Slider RodToNutsNboltsSlider;
    public TMP_Text RodToNutsNboltsText;
    [Space]
    public Slider PlateToReinforcedPlateSlider;
    public TMP_Text PlateToReinforcedPlateText1;
    public TMP_Text PlateToReinforcedPlateText2;
    [Space]
    public int openRange;
    public bool TableOpen;
    public bool Crafting;
    public GameObject CraftTableGUI;
    public GameObject Player;

    void Start()
    {
        MM = mainManager.GetComponent<MainManager>();
        PC = mainCamera.GetComponent<PlayerCam>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Escape) && TableOpen)
        {
            TableOpen = false;
            CraftTableGUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Player.GetComponent<PlayerMovement>().enabled = true;
            PC.enabled = true;
        }
        if (TableOpen == true)
        {
           TextUpdate();
        }
    }

    public void Open()
    {
        TableOpen = true;
        CraftTableGUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Player.GetComponent<PlayerMovement>().enabled = false;
        PC.enabled = false;
    }

    public void TogglePages(int indexToEnable)
    {
        for (int i = 0; i < Sidebars.Length; i++)
        {
            Sidebars[i].SetActive(indexToEnable == i);
        }
    }

    public void TextUpdate()
    {
        ScrapWoodToWoodText.text = MM.ScrapWood + " / " + "2";

        ScrapMetalToMetalText.text = MM.ScrapMetal + " / " + "3";

        MetalToRodText.text = MM.Metal + " / " + "1";

        MetalToPlateText.text = MM.Metal + " / " + "1";

        RodToNutsNboltsText.text = MM.Rod + " / " + "1";

        PlateToReinforcedPlateText1.text = MM.Plate + " / " + "2";
        PlateToReinforcedPlateText2.text = MM.NutsNbolts + " / " + "8";


    }

    public void ScrapWoodToWood()
    {
        if (2 <= MM.ScrapWood && !Crafting)
        {
            MM.ScrapWood -= 2;
            Crafting = true;
            StartCoroutine(ScrapWoodToWoodTimer());
            
        }
    }

        IEnumerator ScrapWoodToWoodTimer()
        {
            float timer = 0;
            while (timer < 1)
            {
                timer += Time.deltaTime;

                float realValue = timer / 1;
                if (TableOpen) { ScrapWoodToWoodSlider.value = realValue; }
                yield return null;
            }
            MM.Wood += 1;
            Crafting = false;
         }

        public void ScrapMetalToMetal()
        {
            if (3 <= MM.ScrapMetal && !Crafting)
            {
                Crafting = true;
                MM.ScrapMetal -= 3;
                StartCoroutine(ScrapMetalToMetalTimer());
            }
        }

        IEnumerator ScrapMetalToMetalTimer()
        {
            float timer = 0;
            while (timer < 1)
            {
                timer += Time.deltaTime;

                float realValue = timer / 1;
                if (TableOpen) { ScrapMetalToMetalSlider.value = realValue; }
                yield return null;
            }
            MM.Metal += 1;
            Crafting = false;
        }

    public void MetalToRod()
    {
        if (1 <= MM.Metal && !Crafting)
        {
            Crafting = true;
            MM.Metal -= 1;
            StartCoroutine(MetalToRodTimer());
        }
    }

    IEnumerator MetalToRodTimer()
    {
        float timer = 0;
        while (timer < 2)
        {
            timer += Time.deltaTime;

            float realValue = timer / 2;
            if (TableOpen) { MetalToRodSlider.value = realValue; }
            yield return null;
        }
        MM.Rod += 1;
        Crafting = false;
    }

    public void MetalToPlate()
    {
        if (1 <= MM.Metal && !Crafting)
        {
            Crafting = true;
            MM.Metal -= 1;
            StartCoroutine(MetalToPlateTimer());
        }
    }

    IEnumerator MetalToPlateTimer()
    {
        float timer = 0;
        while (timer < 2)
        {
            timer += Time.deltaTime;

            float realValue = timer / 2;
            if (TableOpen) { MetalToPlateSlider.value = realValue; }
            yield return null;
        }
        MM.Plate += 2;
        Crafting = false;
    }

    public void RodToNutsNbolts()
    {
        if (1 <= MM.Rod && !Crafting)
        {
            Crafting = true;
            MM.Rod -= 1;
            StartCoroutine(RodToNutsNboltsTimer());
        }
    }

    IEnumerator RodToNutsNboltsTimer()
    {
        float timer = 0;
        while (timer < 2)
        {
            timer += Time.deltaTime;

            float realValue = timer / 2;
            if (TableOpen) { RodToNutsNboltsSlider.value = realValue; }
            yield return null;
        }
        MM.NutsNbolts += 4;
        Crafting = false;
    }

    public void PlateToReinforcedPlate()
    {
        if (2 <= MM.Plate && 8 <= MM.NutsNbolts && !Crafting)
        {
            Crafting = true;
            MM.Plate -= 2;
            MM.NutsNbolts -= 8;
            StartCoroutine(PlateToReinforcedPlateTimer());
        }
    }

    IEnumerator PlateToReinforcedPlateTimer()
    {
        float timer = 0;
        while (timer < 4)
        {
            timer += Time.deltaTime;

            float realValue = timer / 4;
            if (TableOpen) { PlateToReinforcedPlateSlider.value = realValue; }
            yield return null;
        }
        MM.ReinforcedPlate += 1;
        Crafting = false;
    }

}
