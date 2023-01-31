using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayfabManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SendLeaderBoard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest 
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate 
                {
                    StatisticName = "PlatformScore",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }
    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successful leaderboard sent");
        
    }
    void OnError(PlayFabError error)
    {
        Debug.Log("Unsuccessful leaderboard sent");
        Debug.Log(error.GenerateErrorReport());
    }
}
