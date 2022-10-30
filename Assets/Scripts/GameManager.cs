
using LootLocker.Requests;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [Header("UI")]
    [SerializeField]private GameObject _panelLose;
    [SerializeField] private GameObject _gameStory;
    private void Awake()
    {
        Time.timeScale = 0f;
        if (!_gameStory.activeSelf) Time.timeScale = 1f;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        _panelLose?.SetActive(false);
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (!response.success)
            {
                Debug.Log("error starting LootLocker session");

                return;
            }

            Debug.Log("successfully started LootLocker session");
        });
    }
    public void OpenLosePanel()
    {
        _panelLose?.SetActive(true);
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void QuitGameButton()
    {
        SceneManager.LoadScene(0);
    }
}
