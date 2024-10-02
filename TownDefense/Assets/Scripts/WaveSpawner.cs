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
    [SerializeField] private TextMeshProUGUI raidText;
    private Warriors warriors;
    [SerializeField] private int enemies = 3;
    int num = 0;
    bool wave = false;
    // Start is called before the first frame update
    void Start()
    {
        warriors = GetComponent<Warriors>();
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
        for (int i = 0; i < enemies; i++)
        {
            yield return new WaitForSeconds(Random.Range(0.2f, 0.5f));
            Instantiate(enemy, enemySpp);
            if(warriors.warrior > 0)
            {
                warriors.MinusWarrior(-1);
                Instantiate(warrior, warriorSpp);
            }
        }
        num += 3;
        StartCoroutine(StartRaid());
        enemies = enemies * 2;
        
    }
}
