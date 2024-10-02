using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] Transform enemySpp;
    [SerializeField] Transform warriorSpp;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject warrior;
    [SerializeField] TextMeshProUGUI raidText;
    Warriors warriors;
    [SerializeField] int enemies = 3;
    bool wave = false;
    // Start is called before the first frame update
    void Start()
    {
        warriors = GetComponent<Warriors>();
        StartCoroutine(StartRaid());
    }

    IEnumerator StartRaid()
    {
        
        for (int i = 40; i > 0; i--)
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
                warriors.warrior--;
                Instantiate(warrior, warriorSpp);
            }
        }
        StartCoroutine(StartRaid());
    }
}
