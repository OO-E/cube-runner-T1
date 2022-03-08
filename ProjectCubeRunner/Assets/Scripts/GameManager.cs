using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public static GameManager instance;

    public GameObject winPanel;
    public GameObject losePanel;
    void Update()
    {
        if (Score.scoreCount <= -1)
        {
            losePanel.SetActive(true);
            Invoke("BackToMenu", 1.5f);
        }

        else if (Score.scoreCount >= 10)
        {
            winPanel.SetActive(true);
            Invoke("BackToMenu", 1.5f);
        }
    }

    public void BackToMenu()
    {
        //instance = this;
        SceneManager.LoadScene(0);
    }
}
