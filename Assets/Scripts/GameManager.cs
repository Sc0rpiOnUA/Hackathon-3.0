
using LootLocker.Requests;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [Header("UI")]
    [SerializeField]private GameObject _panelLose;
    [SerializeField]CameraFollower _cam;
    [SerializeField] private GameObject _gameStory;
    public bool start = false;
    private void Awake()
    {
        Time.timeScale = 1f;
    }
    public void StartGame()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        if (_panelLose != null)
        {
            _panelLose.SetActive(false);
        }

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
    private void Update()
    {
        if (_cam != null)
        {
            if (_cam.inPosition == true)
            {
                start = true;
            }


        }
    }
    public void OpenLosePanel()
    {
        if (_panelLose != null)
        {
            _panelLose.SetActive(true);
        }
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
