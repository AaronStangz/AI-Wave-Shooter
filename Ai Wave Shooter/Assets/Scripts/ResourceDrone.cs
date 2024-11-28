using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using TMPro;

public class ResourceDrone : MonoBehaviour
{
    public GameObject mainManager;
    public int openRange;
    MainManager MM;
    [Space]
    public GameObject Player;
    public bool RSOpen;
    public GameObject RSGUI;
    [Space]
    public float ScrapMetalTime;
    public Slider ScrapMetalSlider;
    public int ScrapMetalAmount;
    public int ScrapMetalAmountMax;
    public TMP_Text ScrapMetalText;
    [Space]
    public float MetalTime;
    public Slider MetalSlider;
    public int MetalAmount;
    public int MetalAmountMax;
    public TMP_Text MetalText;
    [Space]
    public float ScrapWoodTime;
    public Slider ScrapWoodSlider;
    public int ScrapWoodAmount;
    public int ScrapWoodAmountMax;
    public TMP_Text ScrapWoodText;
    [Space]
    public float WoodTime;
    public Slider WoodSlider;
    public int WoodAmount;
    public int WoodAmountMax;
    public TMP_Text WoodText;

    void Start()
    {
        MM = mainManager.GetComponent<MainManager>();
        ScrapMetalF();
        MetalF();
        ScrapWoodF();
        WoodF();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && RSOpen)
        {
            RSOpen = false;
            RSGUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Player.GetComponent<PlayerMovement>().enabled = true;
        }
        if (RSOpen == true)
        {
            TextUpdate();
        }
    }

    public void Open()
    {
        RSOpen = true;
        RSGUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Player.GetComponent<PlayerMovement>().enabled = false;
    }

    public void CollectLoot()
    {
        MM.ScrapMetal += ScrapMetalAmount;
        ScrapMetalAmount = 0;
        MM.Metal += MetalAmount;
        MetalAmount = 0;
        MM.ScrapMetal += ScrapWoodAmount;
        ScrapWoodAmount = 0;
        MM.Wood += WoodAmount;
        WoodAmount = 0;
    }

    public void TextUpdate()
    {
        ScrapMetalText.text = ScrapMetalAmount + " / " + ScrapMetalAmountMax;
        MetalText.text = MetalAmount + " / " + MetalAmountMax;
        ScrapWoodText.text = ScrapWoodAmount + " / " + ScrapWoodAmountMax;
        WoodText.text = WoodAmount + " / " + WoodAmountMax;
    }

    public void ScrapMetalF()
    {
        StartCoroutine(ScrapMetalTimer());
    }
    IEnumerator ScrapMetalTimer()
    {
        float timer = 0;
        while (timer < ScrapMetalTime)
        {
            timer += Time.deltaTime;

            float realValue = timer / ScrapMetalTime;
            if (RSOpen) { ScrapMetalSlider.value = realValue; }
            yield return null;
        }
        GiveScrapMetal();
        ScrapMetalF();
    }
    public void GiveScrapMetal()
    {
        if (ScrapMetalAmountMax >= ScrapMetalAmount) { ScrapMetalAmount += 1; }
    }
    public void MetalF()
    {
        StartCoroutine(MetalTimer()); 
    }
    IEnumerator MetalTimer()
    {
        float timer = 0;
        while (timer < MetalTime)
        {
            timer += Time.deltaTime;

            float realValue = timer / MetalTime;           
            if (RSOpen) { MetalSlider.value = realValue; }
            yield return null;
        }
        GiveMetal();
        MetalF();
    }
    public void GiveMetal()
    {
        if (MetalAmountMax >= MetalAmount) { MetalAmount += 1; }
    }
    public void ScrapWoodF()
    {
        StartCoroutine(ScrapWoodTimer());
    }
    IEnumerator ScrapWoodTimer()
    {
        float timer = 0;
        while (timer < ScrapWoodTime)
        {
            timer += Time.deltaTime;

            float realValue = timer / ScrapWoodTime;
            if (RSOpen) { ScrapWoodSlider.value = realValue; }
            yield return null;
        }
        GiveScrapWood();
        ScrapWoodF();
    }
    public void GiveScrapWood()
    {
        if (ScrapWoodAmountMax >= ScrapWoodAmount) { ScrapWoodAmount += 1; }
    }
    public void WoodF()
    {
        StartCoroutine(WoodTimer());
    }
    IEnumerator WoodTimer()
    {
        float timer = 0;
        while (timer < WoodTime)
        {
            timer += Time.deltaTime;

            float realValue = timer / WoodTime;
            if (RSOpen) { WoodSlider.value = realValue; }
            yield return null;
        }
        GiveWood();
        WoodF();
    }
    public void GiveWood()
    {
        if (WoodAmountMax >= WoodAmount) { WoodAmount += 1; }
    }
}
