using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class LeaderBoard : MonoBehaviour
{
    int leaderboarID = 8285;
    public TextMeshProUGUI playerNames;
    public TextMeshProUGUI playerScores;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public IEnumerator SubmitScoreRoutine(int scoreToUpload)
    {
        bool done = false;
        string playerID = PlayerPrefs.GetString("PlayerID");
        LootLockerSDKManager.SubmitScore(playerID, scoreToUpload, leaderboarID, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Successfully uploaded score");
                done = true;
            }
            else
            {
                Debug.Log("Failed " + response.Error);
                done = true;
            }
        });
        yield return new WaitWhile(() => done = false);

    }

    public IEnumerator FetchTopHighscoresRoutine()
    {
        bool done = false;
        LootLockerSDKManager.GetScoreListMain(leaderboarID, 10, 0, (response) =>
        {
            if(response.success)
            {
                string tempPlayerNames = "��'�\n\n";
                string tempPlayerScores = "�������\n\n";

                LootLockerLeaderboardMember[] members = response.items;

                for (int i = 0; i < members.Length; i++)
                {
                    tempPlayerNames += members[i].rank + ". ";
                    if (members[i].player.name != "")
                    {
                        tempPlayerNames += members[i].player.name;
                    }
                    else
                    {
                        tempPlayerNames += members[i].player.id;
                    }
                    tempPlayerScores += members[i].score + "\n";
                    tempPlayerNames += "\n";
                }
                done = true;
                playerNames.text = tempPlayerNames;
                playerScores.text = tempPlayerScores;
            }
            else
            {
                Debug.Log("Failed " + response.Error);
                done = true;
            }
        });
        yield return new WaitWhile (() => done == false);
    }

}
