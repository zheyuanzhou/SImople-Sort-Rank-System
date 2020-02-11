using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RankManager : MonoBehaviour
{
    public List<PlayerData> playerDatas = new List<PlayerData>();
    public Group[] groups;

    private void Start()
    {
        CalHighestScore();
        Debug.Log(CalHighestScore());
    }

    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))//STEP 00 After We press the Sort button (Space button)
        //{
        //    playerDatas.Sort(SortByKillNum);//STEP 01 SROT PLAYERDATA LIST
        //    UpdateRank();//STEP 02 UPDATE ALL SLOT 
        //}

        //STEP 03 SORT BY BUBBLE
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    SortScoreByBubble();
        //    UpdateRank();
        //}

        //STEP 04 SORT BY LINQ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerDatas = SortByLINQ(playerDatas.Count);//return list
            UpdateRank();
            Debug.Log("SORT By LINQ");
        }
    }

    public void SortScoreButton()
    {
        //playerDatas.Sort(SortByScore);//STEP 01 SROT PLAYERDATA LIST
        //UpdateRank();//STEP 02 UPDATE ALL SLOT

        //STEP 03 SORTBY BuBble
        SortByBubble(playerDatas, GetPlayerScore);
        UpdateRank();
        Debug.Log("Sort score by bubble");
    }

    public void SortKillNumButton()
    {
        //playerDatas.Sort(SortByKillNum);//STEP 01 SROT PLAYERDATA LIST
        //UpdateRank();//STEP 02 UPDATE ALL SLOT

        //STEP 03 SORTBY BuBble
        SortByBubble(playerDatas, GetPlayerKillNum);
        UpdateRank();
        Debug.Log("Sort killNum by bubble");
    }

    private string CalHighestScore()
    {
        int highestScore = 0;
        string topName = "";

        for(int i = 0; i < playerDatas.Count; i++)
        {
            if(playerDatas[i].playerHighestScore > highestScore)//If one player score is greater than the record
            {
                highestScore = playerDatas[i].playerHighestScore;
                topName = playerDatas[i].playerName;
            }
        }

        return topName;
    }

    //MARKER SORT Method ICompare interface etc
    private int SortByScore(PlayerData _playerA, PlayerData _playerB)
    {
        return _playerA.playerHighestScore.CompareTo(_playerB.playerHighestScore);
    }

    //TODO DELEGATE these two functions in the future ~
    private int SortByKillNum(PlayerData _playerA, PlayerData _playerB)
    {
        return _playerA.playerKillNum.CompareTo(_playerB.playerKillNum);
    }

    private void UpdateRank()
    {
        for (int i = 0; i < playerDatas.Count; i++)
        {
            groups[i].playerData = playerDatas[i];
            groups[i].UpdateGroup();
        }
    }

    //OPTIONAL Method 2 Bubble Sort
    //private void SortScoreByBubble()
    //{
    //    bool isBubble = true;

    //    do
    //    {
    //        isBubble = false;
    //        for (int i = 0; i < playerDatas.Count - 1; i++)
    //        {
    //            if (playerDatas[i].playerHighestScore > playerDatas[i + 1].playerHighestScore)//If front data is greater than its next one
    //            {
    //                PlayerData temp = playerDatas[i];
    //                playerDatas[i] = playerDatas[i + 1];
    //                playerDatas[i + 1] = temp;

    //                isBubble = true;
    //            }
    //        }
    //    }
    //    while (isBubble);
    //}

    //MARKER CREATE Delegate function
    private int GetPlayerScore(PlayerData _playerData)
    {
        return _playerData.playerHighestScore;
    }

    private int GetPlayerKillNum(PlayerData _playerData)
    {
        return _playerData.playerKillNum;
    }

    private delegate int MyDelegate(PlayerData _playerData);

    private void SortByBubble(List<PlayerData> _list, MyDelegate _myDelegate)
    {
        bool isBubble = true;

        do
        {
            isBubble = false;
            for (int i = 0; i < _list.Count - 1; i++)
            {
                //if (_list[i].playerHighestScore > _list[i + 1].playerHighestScore)
                if(_myDelegate(_list[i]) > _myDelegate(_list[i + 1]))
                {
                    PlayerData temp = _list[i];
                    _list[i] = _list[i + 1];
                    _list[i + 1] = temp;

                    isBubble = true;
                }
            }
        }
        while (isBubble);
    }

    //STEP 04
    private List<PlayerData> SortByLINQ(int count)
    {
        return playerDatas.OrderBy(t => t.playerHighestScore).Take(count).ToList();//CORE LAMBDA Expression
    }

}
