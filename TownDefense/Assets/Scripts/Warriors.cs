using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class Warriors : MonoBehaviour
{
    private WheatAdder adder;
    [SerializeField] private TextMeshProUGUI warriorText;
    [SerializeField] private TextMeshProUGUI priseText;
    [SerializeField] private Image warriorImage;
    public int warrior = 0;
    private int wheatCount = 0;
    private float curTime;
    [SerializeField] private float maxTime;
    private bool makingWarrior = false;
    // Start is called before the first frame update
    void Start()
    {
        warriorText.text = warrior.ToString();
        adder = GetComponent<WheatAdder>();
        priseText.text = (warrior * 2).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (curTime >= 0 && makingWarrior == true)
        {
            curTime -= Time.deltaTime;
            warriorImage.fillAmount = curTime / maxTime;
        }
        if (curTime <= 0 && makingWarrior == true)
        {

            MakeWarrior();
        }
    }
    public void AddWarrior()
    {
        if (makingWarrior == true) return;
        wheatCount = adder.wheatCount;
        if (wheatCount >= warrior * 2)
        {

            adder.CountWheat(warrior * -1);
            makingWarrior = true;
            curTime = maxTime;
        }
    }
    private void MakeWarrior()
    {

       // adder.farmers++;
        print("ww");
        warrior += 2;
        warriorText.text = warrior.ToString();
        warriorImage.fillAmount = 1;
        priseText.text = (warrior * 2).ToString();
        makingWarrior = false;
    }
    public void MinusWarrior(int war)
    {
        warrior += war;
        warriorText.text = warrior.ToString();
    }
}
