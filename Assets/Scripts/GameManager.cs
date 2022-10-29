
using LootLocker.Requests;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [Header("UI")]
    private GameObject _panelLose;


    // Start is called before the first frame update
    void Start()
    {
        //_panelLose.SetActive(false);
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
