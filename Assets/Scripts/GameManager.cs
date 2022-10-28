using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [Header("UI")]
    [SerializeField] private GameObject _panelLose;


    // Start is called before the first frame update
    void Start()
    {
        _panelLose.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (isPlayerDead == true) OpenLosePanel();
    }


    public void OpenLosePanel()
    {
        _panelLose.SetActive(true);
    }
    public void RetryButton()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGameButton()
    {
        SceneManager.LoadScene(0);
    }
}
