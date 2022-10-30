using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    public static int _scoreIndex = 0;
    private void Awake()
    {
        _scoreIndex = 0;
    }

    void Update()
    {
        _scoreText.text = "Віджаті креслення: " + _scoreIndex.ToString();
            
    }

    public void AddScore()
    {
        _scoreIndex++;
    }
}
