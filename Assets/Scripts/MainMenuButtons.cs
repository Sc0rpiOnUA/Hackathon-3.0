using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private Slider _slider;


    void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.value = 0.5f;

    }

    // Update is called once per frame
    void Update()
    {
        if (_slider.value == 0) Application.Quit();
        else if (_slider.value == 1) SceneManager.LoadScene(1);

        
    }




}
