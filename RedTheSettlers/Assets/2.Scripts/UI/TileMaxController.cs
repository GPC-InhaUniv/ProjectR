using System;
using UnityEngine;
using UnityEngine.UI;

public class TileMaxController : MonoBehaviour
{
    [Header("Player's Total Resource")]
    [SerializeField]
    private Text PlayerTotalResource;

    [Header("Player's Resource")]
    [SerializeField]
    private Text PlayerCowResource;

    [SerializeField]
    private Text PlayerWaterResource;

    [SerializeField]
    private Text PlayerWheatResource;

    [SerializeField]
    private Text PlayerWoodResource;

    [SerializeField]
    private Text PlayerIronResource;

    [SerializeField]
    private Text PlayerSoilResource;

    [Header("Total Bar")]
    [SerializeField]
    private Slider totalResourceBar;

    private int cowCardNum;
    private int waterCardNum;
    private int wheatCardNum;
    private int woodCardNum;
    private int ironCardNum;
    private int soilCardNum;
    private int cardmaxNum;
    private int computeResourceNum;

    private void ComputeTotalResource()
    {
        cowCardNum = Int32.Parse(PlayerCowResource.text);
        waterCardNum = Int32.Parse(PlayerWaterResource.text);
        wheatCardNum = Int32.Parse(PlayerWheatResource.text);
        woodCardNum = Int32.Parse(PlayerWoodResource.text);
        ironCardNum = Int32.Parse(PlayerIronResource.text);
        soilCardNum = Int32.Parse(PlayerSoilResource.text);

        computeResourceNum = cowCardNum + waterCardNum + wheatCardNum + woodCardNum + ironCardNum + soilCardNum;
        PlayerTotalResource.text = computeResourceNum.ToString();

        totalResourceBar.value = (float)computeResourceNum / (float)cardmaxNum;
    }

    private void Start()
    {
        cardmaxNum = 50;
    }

    private void Update()
    {
        ComputeTotalResource();
    }
}