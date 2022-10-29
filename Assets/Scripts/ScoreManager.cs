using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    private int _scoreIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        _scoreText.text = "Повернені креслення: " + _scoreIndex.ToString();
            
    }

    public void AddScore()
    {
        _scoreIndex++;
    }
}
