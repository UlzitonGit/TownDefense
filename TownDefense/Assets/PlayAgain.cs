using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    [SerializeField] GameObject panel;
    public void Show()
    {
        panel.SetActive(true);
    }
    public void PlayAgainButton()
    {
        SceneManager.LoadScene(0);
    }
}
