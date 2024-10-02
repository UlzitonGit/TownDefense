using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WheatAdder : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI wheatText;
    [SerializeField] private Image wheatImage;
    public int farmers = 1;
    public int warrior = 0;
    public int wheatCount = 0;
    private float curTime;
    [SerializeField] private float maxTime;
    Warriors warriors;
    // Start is called before the first frame update
    void Start()
    {
        warriors = GetComponent<Warriors>();
        curTime = maxTime;
        warrior = warriors.warrior;
        wheatText.text = wheatCount.ToString() + "(-" + warrior.ToString() + ")";
    }

    // Update is called once per frame
    void Update()
    {
        if(curTime >= 0)
        {
            curTime -= Time.deltaTime;
            wheatImage.fillAmount = curTime / maxTime;
        }
        else
        {
            StartTimer();
        }
    }
    private void StartTimer()
    {
        curTime = maxTime;
        wheatCount += (farmers * 2) - warriors.warrior / 2;
        wheatText.text = wheatCount.ToString() + "(-" + warriors.warrior.ToString() + ")";
        if (wheatCount < 0) warriors.MinusWarrior(wheatCount);
    }
    public void CountWheat(int wheat)
    {
        wheatCount += wheat;
        wheatText.text = wheatCount.ToString() + "(-" + warriors.warrior.ToString() + ")";
    }
}
