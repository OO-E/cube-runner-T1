using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int scoreCount;

    public Text text;

    private void Start()
    {
        scoreCount = 0;
    }

    private void Update()
    {
        text.text = scoreCount.ToString();
    }
}
