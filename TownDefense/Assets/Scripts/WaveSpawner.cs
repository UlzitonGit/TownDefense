using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Transform enemySpp;
    [SerializeField] private Transform warriorSpp;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject warrior;
    [SerializeField] private GameObject bandit;
    [SerializeField] private TextMeshProUGUI raidText;
    private Warriors warriors;
    private Farmers farmer;
    [SerializeField] private int enemies = 3;
    int num = 0;
    bool wave = false;
    // Start is called before the first frame update
    void Start()
    {
        warriors = GetComponent<Warriors>();
        farmer = GetComponent<Farmers>();
        StartCoroutine(StartRaid());
    }

    IEnumerator StartRaid()
    {
        
        for (int i = 20 + num; i > 0; i--)
        {
            yield return new WaitForSeconds(1);
            raidText.text = i.ToString();
        }
        StartCoroutine(Raiding());
        
    }
    IEnumerator Raiding()
    {
        int spawned = 0;
        for (int i = 0; i < enemies; i++)
        {
            yield return new WaitForSeconds(Random.Range(0.2f, 0.5f));
            Instantiate(enemy, enemySpp);
            if(warriors.warrior > 0)
            {
                spawned++;
                warriors.MinusWarrior(-1);
                Instantiate(warrior, warriorSpp);
            }
           
            else if(spawned < enemies)
            {
                for (int j = 0; j < enemies * 2; j++)
                {
                    if (farmer.farmers > 0)
                    {
                        farmer.MinusFarmer();
                        Instantiate(bandit, warriorSpp);
                    }
                    else
                    {
                        break;
                    }
                }
            
            }
        }
        num += 3;
        StartCoroutine(StartRaid());
        enemies = enemies * 2;
        
    }
}
