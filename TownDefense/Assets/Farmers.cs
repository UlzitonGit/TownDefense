using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class Farmers : MonoBehaviour
{
    WheatAdder adder;
    [SerializeField] private TextMeshProUGUI farmerText;
    [SerializeField] private TextMeshProUGUI priseText;
    [SerializeField] private Image farmerImage;
    public int farmers = 1;
    private int wheatCount = 0;
    private float curTime;
    [SerializeField] private float maxTime;
    private bool makingFarmer = false;
    // Start is called before the first frame update
    void Start()
    {

        adder = GetComponent<WheatAdder>();
        priseText.text = (farmers * 2).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (curTime >= 0 && makingFarmer == true)
        {
            curTime -= Time.deltaTime;
            farmerImage.fillAmount = curTime / maxTime;
        }
        if(curTime <= 0 && makingFarmer == true)
        {
            
            MakeFarmer();
        }
    }
    public void AddFarmer()
    {
        if (makingFarmer == true) return;
        wheatCount = adder.wheatCount;
        if(wheatCount >= farmers * 2)
        {

            adder.CountWheat(farmers * -2);
            makingFarmer=true;
            curTime = maxTime;
        }
    }
    private void MakeFarmer()
    {

        adder.farmers++;
        print("dd");
        farmers++;
        farmerText.text = farmers.ToString();
        farmerImage.fillAmount = 1;
        priseText.text = (farmers * 2).ToString();
        makingFarmer = false;
    }
}
