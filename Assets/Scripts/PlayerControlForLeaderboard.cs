using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlForLeaderboard : MonoBehaviour
{
    public LeaderBoard leaderBoard;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScore()
    {
        StartCoroutine(DieRoutine());
    }

    IEnumerator DieRoutine()
    {
        yield return leaderBoard.SubmitScoreRoutine(ScoreManager._scoreIndex);
    }


}
