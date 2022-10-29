using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public LeaderBoard leaderBoard;
    public TMP_InputField playerNameInputField;
    public static int checkIsNameSet = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetupRoutine());

    }

    public void SetPlayerName()
    {
        LootLockerSDKManager.SetPlayerName(playerNameInputField.text, (response) =>
        {
            if(response.success)
            {
                Debug.Log("Succesfully set player name");
                checkIsNameSet = 1;
                PlayerPrefs.SetInt("IsNameSet", checkIsNameSet);
            }
            else
            {
                Debug.Log("Could not set player name " + response.Error);
                
            }
        });
    }

    public IEnumerator SetupRoutine()
    {
        yield return LoginRoutine();
        yield return leaderBoard.FetchTopHighscoresRoutine();
    }

    IEnumerator LoginRoutine()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("Player was logged in");
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                done = true;
            }
            else
            {
                Debug.Log("Could not start session");
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
